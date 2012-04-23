﻿//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2012 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using Ict.Common;
using Ict.Common.IO;
using Ict.Common.DB;
using Ict.Common.Data;
using Ict.Common.Verification;
using Ict.Petra.Shared.MFinance.Gift.Data;
using Ict.Petra.Shared.MFinance.Account.Data;
using Ict.Petra.Server.MFinance.Account.Data.Access;
using Ict.Petra.Server.MFinance.Gift;
using Ict.Petra.Server.MFinance.Gift.Data.Access;
using Ict.Petra.Server.MFinance.Gift.WebConnectors;

namespace Ict.Testing.SampleDataConstructor
{
    /// <summary>
    /// tools for generating and posting gift batches with sample data
    /// </summary>
    public class SampleDataGiftBatches
    {
        static int FLedgerNumber = 43;

        /// <summary>
        /// generate the gift batches from a text file that was generated with Benerator
        /// </summary>
        /// <param name="AInputBeneratorFile"></param>
        public static void GenerateBatches(string AInputBeneratorFile)
        {
            SortedList <DateTime, List <XmlNode>>GiftsPerDate = SortGiftsByDate(AInputBeneratorFile);

            GiftBatchTDS MainDS = CreateGiftBatches(GiftsPerDate);

            TVerificationResultCollection VerificationResult;
            GiftBatchTDSAccess.SubmitChanges(MainDS, out VerificationResult);

            if (VerificationResult.HasCriticalOrNonCriticalErrors)
            {
                throw new Exception(VerificationResult.BuildVerificationResultString());
            }

            // TODO post all gift batches??? apart from last open period?
        }

        private static SortedList <DateTime, List <XmlNode>>SortGiftsByDate(string AInputBeneratorFile)
        {
            XmlDocument doc = TCsv2Xml.ParseCSV2Xml(AInputBeneratorFile, ",");

            XmlNode RecordNode = doc.FirstChild.NextSibling.FirstChild;

            SortedList <DateTime, List <XmlNode>>GiftsPerDate = new SortedList <DateTime, List <XmlNode>>();

            while (RecordNode != null)
            {
                // depending on frequency, and start date, add the gift to the batch list
                string frequency = TXMLParser.GetAttribute(RecordNode, "frequency");

                int monthStep = 0;

                DateTime startdate = Convert.ToDateTime(TXMLParser.GetAttribute(RecordNode, "startdate"));

                DateTime dateForGift = startdate;

                if (frequency == "once")
                {
                    // no further gift, leave at 0
                }
                else if (frequency == "monthly")
                {
                    monthStep = 1;
                }
                else if (frequency == "quarterly")
                {
                    monthStep = 3;
                }

                do
                {
                    if (!GiftsPerDate.ContainsKey(dateForGift))
                    {
                        GiftsPerDate.Add(dateForGift, new List <XmlNode>());
                    }

                    GiftsPerDate[dateForGift].Add(RecordNode);

                    dateForGift = dateForGift.AddMonths(monthStep);
                } while (monthStep > 0 && startdate.Year == dateForGift.Year);

                RecordNode = RecordNode.NextSibling;
            }

            return GiftsPerDate;
        }

        private static GiftBatchTDS CreateGiftBatches(SortedList <DateTime, List <XmlNode>>AGiftsPerDate)
        {
            GiftBatchTDS MainDS = new GiftBatchTDS();

            TDBTransaction ReadTransaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                // get a list of potential donors (all class FAMILY)
                string sqlGetFamilyPartnerKeys = "SELECT p_partner_key_n FROM PUB_p_family";
                DataTable FamilyKeys = DBAccess.GDBAccessObj.SelectDT(sqlGetFamilyPartnerKeys, "keys", ReadTransaction);

                // get a list of workers (all class FAMILY, with special type WORKER)
                string sqlGetWorkerPartnerKeys =
                    "SELECT PUB_p_family.p_partner_key_n FROM PUB_p_family, PUB_p_partner_type WHERE PUB_p_partner_type.p_partner_key_n = PUB_p_family.p_partner_key_n AND p_type_code_c = 'WORKER'";
                DataTable WorkerKeys = DBAccess.GDBAccessObj.SelectDT(sqlGetWorkerPartnerKeys, "keys", ReadTransaction);

                // get a list of fields (all class UNIT, with unit type F)
                string sqlGetFieldPartnerKeys = "SELECT p_partner_key_n FROM PUB_p_unit WHERE u_unit_type_code_c = 'F'";
                DataTable FieldKeys = DBAccess.GDBAccessObj.SelectDT(sqlGetFieldPartnerKeys, "keys", ReadTransaction);

                // get a list of key ministries (all class UNIT, with unit type KEY-MIN)
                string sqlGetKeyMinPartnerKeys = "SELECT p_partner_key_n FROM PUB_p_unit WHERE u_unit_type_code_c = 'KEY-MIN'";
                DataTable KeyMinKeys = DBAccess.GDBAccessObj.SelectDT(sqlGetKeyMinPartnerKeys, "keys", ReadTransaction);

                ALedgerTable LedgerTable = ALedgerAccess.LoadByPrimaryKey(FLedgerNumber, ReadTransaction);

                // create a gift batch for each day.
                // TODO: could create one batch per month, if there are not so many gifts (less than 100 per month)
                foreach (DateTime GlEffectiveDate in AGiftsPerDate.Keys)
                {
                    AGiftBatchRow giftBatch = TGiftBatchFunctions.CreateANewGiftBatchRow(ref MainDS,
                        ref ReadTransaction,
                        ref LedgerTable,
                        FLedgerNumber,
                        GlEffectiveDate);

                    giftBatch.BatchDescription = "Benerator Batch for " + GlEffectiveDate.ToShortDateString();

                    foreach (XmlNode RecordNode in AGiftsPerDate[GlEffectiveDate])
                    {
                        AGiftRow gift = MainDS.AGift.NewRowTyped();
                        gift.LedgerNumber = giftBatch.LedgerNumber;
                        gift.BatchNumber = giftBatch.BatchNumber;
                        gift.GiftTransactionNumber = giftBatch.LastGiftNumber + 1;
                        gift.DateEntered = GlEffectiveDate;

                        // set donorKey
                        int donorID = Convert.ToInt32(TXMLParser.GetAttribute(RecordNode, "donor")) % FamilyKeys.Rows.Count;
                        gift.DonorKey = Convert.ToInt64(FamilyKeys.Rows[donorID].ItemArray[0]);

                        // calculate gift detail information
                        int countDetails = Convert.ToInt32(TXMLParser.GetAttribute(RecordNode, "splitgift"));

                        for (int counter = 1; counter <= countDetails; counter++)
                        {
                            AGiftDetailRow giftDetail = MainDS.AGiftDetail.NewRowTyped();
                            giftDetail.LedgerNumber = gift.LedgerNumber;
                            giftDetail.BatchNumber = gift.BatchNumber;
                            giftDetail.GiftTransactionNumber = gift.GiftTransactionNumber;

                            giftDetail.MotivationGroupCode = "GIFT";
                            giftDetail.GiftTransactionAmount = Convert.ToDecimal(TXMLParser.GetAttribute(RecordNode, "amount_" + counter.ToString()));

                            string motivation = TXMLParser.GetAttribute(RecordNode, "motivation_" + counter.ToString());

                            if (motivation == "SUPPORT")
                            {
                                if (WorkerKeys.Rows.Count == 0)
                                {
                                    continue;
                                }

                                giftDetail.MotivationDetailCode = "SUPPORT";
                                int recipientID =
                                    Convert.ToInt32(TXMLParser.GetAttribute(RecordNode, "recipient_support_" +
                                            counter.ToString())) % WorkerKeys.Rows.Count;
                                giftDetail.RecipientKey = Convert.ToInt64(WorkerKeys.Rows[recipientID].ItemArray[0]);

                                // TODO: ignore this gift detail, if there is no valid commitment period for the worker
                                // if (InvalidCommitment(giftBatch.GlEffectiveDate)) continue;
                            }
                            else if (motivation == "FIELD")
                            {
                                if (FieldKeys.Rows.Count == 0)
                                {
                                    continue;
                                }

                                giftDetail.MotivationDetailCode = "FIELD";
                                int recipientID =
                                    Convert.ToInt32(TXMLParser.GetAttribute(RecordNode, "recipient_field_" +
                                            counter.ToString())) % FieldKeys.Rows.Count;
                                giftDetail.RecipientKey = Convert.ToInt64(FieldKeys.Rows[recipientID].ItemArray[0]);
                                giftDetail.RecipientLedgerNumber = giftDetail.RecipientKey;
                                giftDetail.CostCentreCode = (giftDetail.RecipientKey / 10000).ToString("0000");
                            }
                            else if (motivation == "KEYMIN")
                            {
                                if (KeyMinKeys.Rows.Count == 0)
                                {
                                    continue;
                                }

                                giftDetail.MotivationDetailCode = "KEYMIN";
                                int recipientID =
                                    Convert.ToInt32(TXMLParser.GetAttribute(RecordNode, "recipient_keymin_" +
                                            counter.ToString())) % KeyMinKeys.Rows.Count;
                                giftDetail.RecipientKey = Convert.ToInt64(KeyMinKeys.Rows[recipientID].ItemArray[0]);
                                giftDetail.RecipientLedgerNumber = TTransactionWebConnector.SearchRecipientLedgerKey(giftDetail.RecipientKey);
                                giftDetail.CostCentreCode = (giftDetail.RecipientLedgerNumber / 10000).ToString("0000");
                            }

                            giftDetail.DetailNumber = gift.LastDetailNumber + 1;
                            MainDS.AGiftDetail.Rows.Add(giftDetail);
                            gift.LastDetailNumber = giftDetail.DetailNumber;
                        }

                        if (gift.LastDetailNumber > 0)
                        {
                            MainDS.AGift.Rows.Add(gift);
                            giftBatch.LastGiftNumber = gift.GiftTransactionNumber;
                        }
                    }

                    if (TLogging.DebugLevel > 0)
                    {
                        TLogging.Log(
                            GlEffectiveDate.ToShortDateString() + " " + giftBatch.LastGiftNumber.ToString());
                    }
                }
            }
            finally
            {
                DBAccess.GDBAccessObj.RollbackTransaction();
            }

            return MainDS;
        }
    }
}
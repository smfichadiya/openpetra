﻿//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2020 by OM International
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
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using Ict.Common;
using Ict.Common.Data;
using Ict.Common.DB;
using Ict.Common.Verification;
using Ict.Common.Remoting.Server;
using Ict.Petra.Shared;
using Ict.Petra.Shared.MPartner;
using Ict.Petra.Shared.MPartner.Partner.Data;
using Ict.Petra.Shared.MSysMan.Data;
using Ict.Petra.Shared.MFinance;
using Ict.Petra.Shared.MFinance.Gift.Data;
using Ict.Petra.Shared.MSponsorship.Data;
using Ict.Petra.Server.MSponsorship.Data.Access;
using Ict.Petra.Server.MFinance.Gift.Data.Access;
using Ict.Petra.Server.MPartner.Partner.Data.Access;
using Ict.Petra.Server.MPartner.Common;
using Ict.Petra.Server.App.Core.Security;
using Ict.Petra.Server.MFinance.Gift.WebConnectors;
using Ict.Petra.Server.MFinance.Gift;

namespace Ict.Petra.Server.MSponsorship.WebConnectors
{

    /// <summary>
    /// webconnector for the sponsorship module
    /// </summary>
    public class TSponsorshipWebConnector
    {
        private const string TYPE_SPONSOREDCHILD = "SPONSOREDCHILD";
        private const string BATCHNAME_SPONSORSHIP = "SPONSORSHIP";

        /// <summary>
        /// find children using filters
        /// </summary>
        [RequireModulePermission("OR(SPONSORVIEW,SPONSORADMIN)")]
        public static SponsorshipFindTDSSearchResultTable FindChildren(
            string AFirstName,
            string AFamilyName,
            string APartnerStatus,
            string ASponsorshipStatus,
            string ASponsorAdmin)
        {
            TDBTransaction t = new TDBTransaction();
            TDataBase db = DBAccess.Connect("FindChildren");
            string sql = "SELECT p.p_partner_short_name_c, p.p_status_code_c, p.p_partner_key_n, p.p_user_id_c, " +
                "f.p_first_name_c, f.p_family_name_c, t.p_type_code_c " +
                "FROM PUB_p_partner p, PUB_p_family f, PUB_p_partner_type t " +
                "WHERE p.p_partner_key_n = f.p_partner_key_n " +
                "AND p.p_partner_key_n = t.p_partner_key_n";

            int CountParameters = 0;
            int Pos = 0;
            CountParameters += (AFirstName != String.Empty ? 1 : 0);
            CountParameters += (ASponsorshipStatus != String.Empty ? 1 : 0);
            CountParameters += (AFamilyName != String.Empty ? 1 : 0);
            CountParameters += (ASponsorAdmin != String.Empty ? 1 : 0);
            OdbcParameter[] parameters = new OdbcParameter[CountParameters];

            if (ASponsorshipStatus != String.Empty)
            {
                sql += " AND t.p_type_code_c = ?";
                parameters[Pos] = new OdbcParameter("ASponsorshipStatus", OdbcType.VarChar);
                parameters[Pos].Value = ASponsorshipStatus;
                Pos++;
            }
            else
            {
                sql += " AND t.p_type_code_c IN ('CHILDREN_HOME','HOME_BASED','BOARDING_SCHOOL','PREVIOUS_CHILD','CHILD_DIED')";
            }

            if (AFirstName != String.Empty)
            {
                sql += " AND f.p_first_name_c LIKE ?";
                parameters[Pos] = new OdbcParameter("FirstName", OdbcType.VarChar);
                parameters[Pos].Value = AFirstName;
                Pos++;
            }

            if (AFamilyName != String.Empty)
            {
                sql += " AND f.p_family_name_c LIKE ?";
                parameters[Pos] = new OdbcParameter("AFamilyName", OdbcType.VarChar);
                parameters[Pos].Value = AFamilyName;
                Pos++;
            }

            if (ASponsorAdmin != String.Empty)
            {
                sql += " AND p.p_user_id_c LIKE ?";
                parameters[Pos] = new OdbcParameter("ASponsorAdmin", OdbcType.VarChar);
                parameters[Pos].Value = ASponsorAdmin;
                Pos++;
            }
            SponsorshipFindTDSSearchResultTable result = new SponsorshipFindTDSSearchResultTable();

            db.ReadTransaction(ref t,
                delegate
                {
                    db.SelectDT(result, sql, t, parameters);
                });

            db.CloseDBConnection();

            return result;
        }

        /// <summary>
        /// find the users that are allowed to administrate sponsorships
        /// </summary>
        [RequireModulePermission("OR(SPONSORVIEW,SPONSORADMIN)")]
        public static SUserTable GetSponsorAdmins()
        {
            TDBTransaction t = new TDBTransaction();
            TDataBase db = DBAccess.Connect("FindSponsorAdmins");
            string sql = "SELECT u.s_user_id_c, u.s_first_name_c, u.s_last_name_c "+
                "FROM PUB_s_user_module_access_permission p "+
                "JOIN PUB_s_user u "+
                "ON u.s_user_id_c = p.s_user_id_c AND p.s_module_id_c = 'SPONSORADMIN'";

            SUserTable result = new SUserTable();

            db.ReadTransaction(ref t,
                delegate
                {
                    db.SelectDT(result, sql, t);
                });

            db.CloseDBConnection();

            return result;
        }

        /// <summary>
        /// get a partner key for a new partner
        /// </summary>
        /// <param name="AFieldPartnerKey">can be -1, then the default site key is used</param>
        private static Int64 NewPartnerKey(Int64 AFieldPartnerKey = -1)
        {
            Int64 NewPartnerKey = TNewPartnerKey.GetNewPartnerKey(AFieldPartnerKey);

            TNewPartnerKey.SubmitNewPartnerKey(NewPartnerKey - NewPartnerKey % 1000000, NewPartnerKey, ref NewPartnerKey);
            return NewPartnerKey;
        }

        /// <summary>
        /// return the dataset for a new child
        /// </summary>
        [RequireModulePermission("SPONSORADMIN")]
        private static SponsorshipTDS CreateNewChild()
        {
            Int64 SiteKey = DomainManager.GSiteKey;
            SponsorshipTDS MainDS = new SponsorshipTDS();
            Int64 PartnerKey = NewPartnerKey();
            DateTime CreationDate = DateTime.Today;
            string CreationUserID = UserInfo.GetUserInfo().UserID;

            // Create DataRow for Partner using the default values for all DataColumns
            // and then modify some.
            PPartnerRow PartnerRow = MainDS.PPartner.NewRowTyped(true);
            PartnerRow.PartnerKey = PartnerKey;
            PartnerRow.DateCreated = CreationDate;
            PartnerRow.CreatedBy = CreationUserID;
            PartnerRow.PartnerClass = SharedTypes.PartnerClassEnumToString(TPartnerClass.FAMILY);
            PartnerRow.StatusCode = SharedTypes.StdPartnerStatusCodeEnumToString(TStdPartnerStatusCode.spscACTIVE);
            PartnerRow.UserId = CreationUserID;
            MainDS.PPartner.Rows.Add(PartnerRow);

            PFamilyRow FamilyRow = MainDS.PFamily.NewRowTyped(true);
            FamilyRow.PartnerKey = PartnerKey;
            FamilyRow.DateCreated = CreationDate;
            FamilyRow.CreatedBy = CreationUserID;
            MainDS.PFamily.Rows.Add(FamilyRow);

            PPartnerTypeRow PartnerTypeRow = MainDS.PPartnerType.NewRowTyped(true);
            PartnerTypeRow.PartnerKey = PartnerKey;
            PartnerTypeRow.TypeCode = TYPE_SPONSOREDCHILD;
            MainDS.PPartnerType.Rows.Add(PartnerTypeRow);

            return MainDS;
        }

        /// make sure we have a recurring gift batch for sponsorships
        [RequireModulePermission("SPONSORADMIN")]
        public static void InitRecurringGiftBatchForSponsorship(Int32 ALedgerNumber, string ABankAccountCode)
        {
            TDataBase db = DBAccess.Connect("InitRecurringGiftBatchForSponsorship");
            TDBTransaction Transaction = new TDBTransaction();
            Int32 BatchNumber = -1;
            string CurrencyCode = String.Empty;
            GiftBatchTDS GiftDS = new GiftBatchTDS();

            DBAccess.ReadTransaction( ref Transaction,
                delegate
                {
                    BatchNumber = GetRecurringGiftBatchForSponsorship(ALedgerNumber, Transaction);

                    if ((BatchNumber == -1) && (ABankAccountCode == String.Empty))
                    {
                        // bank account is not defined: use the first active bank account by default.
                        // we don't support foreign currency accounts at the moment
                        string sql = "SELECT MAX(a.a_account_code_c) FROM a_account AS a, a_account_property AS p "+
                            "WHERE a.a_ledger_number_i = p.a_ledger_number_i " +
                            "AND a.a_account_code_c = p.a_account_code_c " +
                            "AND a.a_ledger_number_i = " + ALedgerNumber.ToString() + " " +
                            "AND p.a_property_code_c = '" + MFinanceConstants.ACCOUNT_PROPERTY_BANK_ACCOUNT + "' " +
                            "AND p.a_property_value_c = 'true' " +
                            "AND a.a_foreign_currency_flag_l = false";
                        object result = Transaction.DataBaseObj.ExecuteScalar(sql, Transaction);

                        // if no bank account exists, the result will be System.DBNull
                        if (!(result is System.DBNull))
                        {
                            ABankAccountCode = result.ToString();
                        }
                    }

                    if (CurrencyCode == String.Empty)
                    {
                        string sql = "SELECT a_base_currency_c FROM a_ledger WHERE a_ledger_number_i = " + ALedgerNumber.ToString();
                        object result = Transaction.DataBaseObj.ExecuteScalar(sql, Transaction);

                        // if no ledger exists, the result will be System.DBNull
                        if (!(result is System.DBNull))
                        {
                            CurrencyCode = result.ToString();
                        }
                    }

                    TGiftBatchFunctions.CreateANewRecurringGiftBatchRow(ref GiftDS, ref Transaction, ALedgerNumber);
                });

            if (BatchNumber != -1)
            {
                return;
            }

            ARecurringGiftBatchRow b = GiftDS.ARecurringGiftBatch[0];
            b.BankAccountCode = ABankAccountCode;
            b.BatchDescription = BATCHNAME_SPONSORSHIP;
            b.CurrencyCode = CurrencyCode;
            GiftBatchTDSAccess.SubmitChanges(GiftDS, db);

            db.CloseDBConnection();
        }

        /// returns the number of the recurring gift batch
        private static Int32 GetRecurringGiftBatchForSponsorship(Int32 ALedgerNumber, TDBTransaction ATransaction = null)
        {
            string sql = "SELECT MAX(a_batch_number_i) FROM a_recurring_gift_batch WHERE a_ledger_number_i = " + ALedgerNumber.ToString() +
                " AND a_batch_description_c LIKE '" + BATCHNAME_SPONSORSHIP + "'";
            object result = ATransaction.DataBaseObj.ExecuteScalar(sql, ATransaction);

            // if no batch exists, the result will be System.DBNull
            if (result is Int32)
            {
                return Convert.ToInt32(result);
            }

            return -1;
        }

        /// <summary>
        /// return the existing data of a child
        /// </summary>
        [RequireModulePermission("OR(SPONSORVIEW,SPONSORADMIN)")]
        public static SponsorshipTDS GetChildDetails(Int64 APartnerKey,
            Int32 ALedgerNumber,
            bool AWithPhoto,
            out string ASponsorshipStatus)
        {
            SponsorshipTDS MainDS = new SponsorshipTDS();

            TDBTransaction Transaction = new TDBTransaction();

            DBAccess.ReadTransaction( ref Transaction,
                delegate
                {
                    PPartnerAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    PFamilyAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    PPartnerTypeAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);
                    PPartnerCommentAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);
                    PPartnerReminderAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);

                    if (!AWithPhoto && (MainDS.PFamily.Rows.Count == 1))
                    {
                        MainDS.PFamily[0].Photo = "";
                    }

                    int SponsorshipBatchNumber = GetRecurringGiftBatchForSponsorship(ALedgerNumber, Transaction);

                    if (SponsorshipBatchNumber > -1)
                    {
                        ARecurringGiftBatchAccess.LoadByPrimaryKey(MainDS, ALedgerNumber, SponsorshipBatchNumber, Transaction);
                        ARecurringGiftAccess.LoadViaARecurringGiftBatch(MainDS, ALedgerNumber, SponsorshipBatchNumber, Transaction);
                        ARecurringGiftDetailAccess.LoadViaARecurringGiftBatch(MainDS, ALedgerNumber, SponsorshipBatchNumber, Transaction);

                        GiftBatchTDS GiftDS = new GiftBatchTDS();
                        TGiftTransactionWebConnector.LoadGiftDonorRelatedData(GiftDS, true, ALedgerNumber, SponsorshipBatchNumber, Transaction);

                        for (int i = 0; i < MainDS.ARecurringGiftDetail.Count;)
                        {
                            SponsorshipTDSARecurringGiftDetailRow gdr = MainDS.ARecurringGiftDetail[i];
                            // drop all recurring gift details, that are not related to this child (RecipientKey)
                            if (gdr.RecipientKey != APartnerKey)
                            {
                                MainDS.ARecurringGiftDetail.Rows.RemoveAt(i);
                            }
                            else
                            {
                                i++;
                                // set the donor key from the appropriate recurring gift
                                MainDS.ARecurringGift.DefaultView.RowFilter = String.Format("{0} = {1}",
                                    ARecurringGiftTable.GetGiftTransactionNumberDBName(),
                                    gdr.GiftTransactionNumber);

                                // there should be only one row
                                foreach (DataRowView drv in MainDS.ARecurringGift.DefaultView)
                                {
                                    ARecurringGiftRow recurrGiftRow = (ARecurringGiftRow)drv.Row;
                                    gdr.DonorKey = recurrGiftRow.DonorKey;
                                    PPartnerRow donorRow = (PPartnerRow)GiftDS.DonorPartners.Rows.Find(recurrGiftRow.DonorKey);
                                    gdr.DonorName = donorRow.PartnerShortName;
                                    gdr.CurrencyCode = MainDS.ARecurringGiftBatch[0].CurrencyCode;
                                }

                            }

                        }

                        // drop all unrelated gift rows, that don't have a detail for this child
                        for (int i = 0; i < MainDS.ARecurringGift.Count;)
                        {
                            ARecurringGiftRow gr = MainDS.ARecurringGift[0];
                            MainDS.ARecurringGiftDetail.DefaultView.RowFilter = String.Format("{0} = {1}",
                                ARecurringGiftDetailTable.GetGiftTransactionNumberDBName(),
                                gr.GiftTransactionNumber);

                            if (MainDS.ARecurringGiftDetail.DefaultView.Count == 0)
                            {
                                MainDS.ARecurringGift.Rows.RemoveAt(i);
                            }
                            else
                            {
                                i++;
                            }

                        }
                    }
                });

            bool isSponsoredChild = false;
            ASponsorshipStatus = "[N/A]";

            foreach (PPartnerTypeRow type in MainDS.PPartnerType.Rows)
            {
                if (type.TypeCode == "CHILDREN_HOME" || type.TypeCode == "HOME_BASED" || type.TypeCode == "BOARDING_SCHOOL" || type.TypeCode == "PREVIOUS_CHILD" || type.TypeCode == "CHILD_DIED")
                {
                    isSponsoredChild = true;
                }
                ASponsorshipStatus = type.TypeCode;
            }

            if (!isSponsoredChild)
            {
                return new SponsorshipTDS();
            }

            return MainDS;
        }

        /// <summary>
        /// store the currently edited child
        /// </summary>
        [RequireModulePermission("SPONSORADMIN")]
        public static bool MaintainChild(
            string ASponsorshipStatus,
            string AFirstName,
            string AFamilyName,
            DateTime? ADateOfBirth,
            string APhoto,
            bool AUploadPhoto,
            string AGender,
            string AUserId,
            Int64 APartnerKey,
            Int32 ALedgerNumber,
            out TVerificationResultCollection AVerificationResult)
        {
            SponsorshipTDS CurrentEdit;
            AVerificationResult = new TVerificationResultCollection();

            if (APartnerKey == -1)
            {
                // no partner key given, so we make a new entry
                CurrentEdit = CreateNewChild();
                if (CurrentEdit.PFamily.Count > 0) { CurrentEdit.PFamily[0].PartnerKey = CurrentEdit.PPartner[0].PartnerKey; }
            }
            else
            {
                // else we try to get a entry based on the partner key
                string dummy = "0";
                CurrentEdit = GetChildDetails(APartnerKey, ALedgerNumber, true, out dummy);
            }

            // we only save pictures if there is a value in the request
            if (AUploadPhoto)
            {
                CurrentEdit.PFamily[0].Photo = APhoto;
            }
            else
            {
                if ((ASponsorshipStatus == "") || (ASponsorshipStatus == null))
                {
                    AVerificationResult.Add(new TVerificationResult("error", "Please specify the status of the sponsorship", "",
                        "MaintainChildren.ErrMissingSponsorshipStatus", TResultSeverity.Resv_Critical));
                }

                if ((AFirstName == "") || (AFirstName == null))
                {
                    AVerificationResult.Add(new TVerificationResult("error", "Please specify the first name of the sponsored child", "",
                        "MaintainChildren.ErrMissingFirstName", TResultSeverity.Resv_Critical));
                }

                if (AVerificationResult.HasCriticalErrors)
                {
                    return false;
                }

                CurrentEdit.PFamily[0].FirstName = AFirstName;
                CurrentEdit.PFamily[0].FamilyName = AFamilyName;
                CurrentEdit.PFamily[0].DateOfBirth = ADateOfBirth;
                CurrentEdit.PFamily[0].Gender = AGender;
                CurrentEdit.PPartner[0].UserId = AUserId;

                // only on a actual change, else skip this
                if (ASponsorshipStatus != CurrentEdit.PPartnerType[0].TypeCode)
                {
                    PPartnerTypeRow OldTypeRow = CurrentEdit.PPartnerType[0];
                    OldTypeRow.Delete();

                    PPartnerTypeRow NewTypeRow = CurrentEdit.PPartnerType.NewRowTyped(true);

                    NewTypeRow.TypeCode = ASponsorshipStatus;
                    NewTypeRow.PartnerKey = CurrentEdit.PPartner[0].PartnerKey;

                    CurrentEdit.PPartnerType.Rows.Add(NewTypeRow);
                }

            }

            CurrentEdit.PPartner[0].PartnerShortName =
                    Calculations.DeterminePartnerShortName(
                        CurrentEdit.PFamily[0].FamilyName,
                        CurrentEdit.PFamily[0].Title,
                        CurrentEdit.PFamily[0].FirstName);

            try
            {
                SponsorshipTDSAccess.SubmitChanges(CurrentEdit);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }
        }

        /// maintain comments about the child
        [RequireModulePermission("SPONSORADMIN")]
        public static bool MaintainChildComments(
            string AComment,
            string ACommentType,
            Int32 AIndex,
            Int64 APartnerKey,
            out TVerificationResultCollection AVerificationResult)
        {

            SponsorshipTDS CurrentEdit;
            AVerificationResult = new TVerificationResultCollection();

            if (APartnerKey == -1)
            {
                AVerificationResult.Add(new TVerificationResult("error", "no partner key", TResultSeverity.Resv_Critical));
                return false;
            }

            string dummy = "";
            CurrentEdit = GetChildDetails(APartnerKey, -1, true, out dummy);

            PPartnerCommentRow EditCommentRow = null;

            // since we get a index from the user (and i don't know how to request one of them)
            // we loop over all comments, edit it if we found it, and if it's null we add a new one
            foreach (PPartnerCommentRow CommentRow in CurrentEdit.PPartnerComment.Rows)
            {
                if (CommentRow.Index == AIndex)
                {
                    EditCommentRow = CommentRow;
                    break;
                }
            }

            // edit
            if (EditCommentRow != null)
            {
                EditCommentRow.Comment = AComment;
            }
            else
            {
                PPartnerCommentRow NewCommentRow = CurrentEdit.PPartnerComment.NewRowTyped(true);
                NewCommentRow.PartnerKey = APartnerKey;
                NewCommentRow.Comment = AComment;
                NewCommentRow.CommentType = ACommentType;
                NewCommentRow.Index = AIndex;
                NewCommentRow.Sequence = 0; // nobody cares about this value but it must be set
                CurrentEdit.PPartnerComment.Rows.Add(NewCommentRow);
            }

            try
            {
                SponsorshipTDSAccess.SubmitChanges(CurrentEdit);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }
        }

        /// maintain reminders about the child
        [RequireModulePermission("SPONSORADMIN")]
        public static bool MaintainChildReminders(
            String AComment,
            Int32 AReminderId,
            Int64 APartnerKey,
            DateTime AEventDate,
            DateTime AFirstReminderDate,
            out TVerificationResultCollection AVerificationResult)
        {

            SponsorshipTDS CurrentEdit;
            AVerificationResult = new TVerificationResultCollection();

            if (APartnerKey == -1)
            {
                AVerificationResult.Add(new TVerificationResult("error", "no partner key", TResultSeverity.Resv_Critical));
                return false;
            }

            string dummy = "";
            CurrentEdit = GetChildDetails(APartnerKey, -1, true, out dummy);

            PPartnerReminderRow EditReminderRow = null;

            // since we get a reminder id from the user (and i don't know how to request one of them)
            // we loop over all reminders, edit it if we found it, and if it's null we add a new one
            foreach (PPartnerReminderRow ReminderRow in CurrentEdit.PPartnerReminder.Rows)
            {
                if (ReminderRow.ReminderId == AReminderId)
                {
                    EditReminderRow = ReminderRow;
                    break;
                }
            }

            // edit
            if (EditReminderRow != null)
            {
                EditReminderRow.EventDate = AEventDate;
                EditReminderRow.FirstReminderDate = AFirstReminderDate;
                EditReminderRow.Comment = AComment;
            }
            else
            {
                PPartnerReminderRow NewReminderRow = CurrentEdit.PPartnerReminder.NewRowTyped(true);
                NewReminderRow.PartnerReminderId = -1;
                NewReminderRow.PartnerKey = APartnerKey;
                NewReminderRow.EventDate = AEventDate;
                NewReminderRow.FirstReminderDate = AFirstReminderDate;
                NewReminderRow.Comment = AComment;
                NewReminderRow.ReminderId = AReminderId;
                CurrentEdit.PPartnerReminder.Rows.Add( NewReminderRow );
            }

            try
            {
                SponsorshipTDSAccess.SubmitChanges(CurrentEdit);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }
        }

        /// Add or edit details of recurring gifts
        [RequireModulePermission("SPONSORADMIN")]
        public static bool MaintainSponsorshipRecurringGifts(
            Int32 ALedgerNumber,
            Int32 ABatchNumber,
            Int32 AGiftTransactionNumber,
            Int32 ADetailNumber,
            Int64 ARecipientKey,
            Int64 ADonorKey,
            String AMotivationGroupCode,
            String AMotivationDetailCode,
            decimal AGiftAmount,
            DateTime AStartDonations,
            DateTime? AEndDonations,
            out TVerificationResultCollection AVerificationResult) 
        {
            AVerificationResult = new TVerificationResultCollection();

            if (ADonorKey <= 0)
            {
                AVerificationResult.Add(new TVerificationResult("error", "Please specify the donor", "",
                    "MaintainChildren.ErrMissingDonor", TResultSeverity.Resv_Critical));
            }

            if (AGiftAmount <= 0)
            {
                AVerificationResult.Add(new TVerificationResult("error", "Please specify a valid amount", "",
                    "MaintainChildren.ErrMissingAmount", TResultSeverity.Resv_Critical));
            }

            if ((AMotivationDetailCode == "") || (AMotivationDetailCode == null))
            {
                AVerificationResult.Add(new TVerificationResult("error", "Please specify the motivation", "",
                    "MaintainChildren.ErrMissingMotivation", TResultSeverity.Resv_Critical));
            }

            if (AVerificationResult.HasCriticalErrors)
            {
                return false;
            }

            TDBTransaction Transaction = new TDBTransaction();
            SponsorshipTDS MainDS = new SponsorshipTDS();
            TDataBase DB = DBAccess.Connect("MaintainRecurringGifts");
            bool MotivationExists = false;

            // load batches and their transactions based on their id / batch number
            DB.ReadTransaction(ref Transaction, delegate {
                // we overwrite the user input, since the user can't really send the right batch number on create
                ABatchNumber = GetRecurringGiftBatchForSponsorship(ALedgerNumber, Transaction);
                ARecurringGiftBatchAccess.LoadByPrimaryKey(MainDS, ALedgerNumber, ABatchNumber, Transaction);
                ARecurringGiftAccess.LoadViaARecurringGiftBatch(MainDS, ALedgerNumber, ABatchNumber, Transaction);
                MotivationExists = AMotivationDetailAccess.Exists(ALedgerNumber, AMotivationGroupCode, AMotivationDetailCode, Transaction);
            });

            if (!MotivationExists)
            {
                AVerificationResult.Add(new TVerificationResult("error", "Please specify a valid motivation", "",
                    "MaintainChildren.ErrMissingMotivation", TResultSeverity.Resv_Critical));
                return false;
            }

            // try to get a row with requested id, aka edit else make a new
            ARecurringGiftRow EditGiftRow = null;
            foreach (ARecurringGiftRow CheckGiftRow in MainDS.ARecurringGift.Rows)
            {
                if (CheckGiftRow.GiftTransactionNumber == AGiftTransactionNumber)
                {
                    EditGiftRow = CheckGiftRow;
                    break;
                }
            }

            // we did not find a Transaction in this Batch, so we create one
            if (EditGiftRow == null)
            {
                // TODO: we could look for a gift transaction of the same donor???
                EditGiftRow = MainDS.ARecurringGift.NewRowTyped(true);
                EditGiftRow.DonorKey = ADonorKey;
                EditGiftRow.BatchNumber = ABatchNumber;
                EditGiftRow.LedgerNumber = ALedgerNumber;
                EditGiftRow.GiftTransactionNumber = MainDS.ARecurringGiftBatch[0].LastGiftNumber + 1;
                MainDS.ARecurringGiftBatch[0].LastGiftNumber++;
                MainDS.ARecurringGift.Rows.Add(EditGiftRow);
            }

            // load stuff based on the current edit row
            DB.ReadTransaction(ref Transaction, delegate {
                    ARecurringGiftDetailAccess.LoadViaARecurringGift(MainDS, ALedgerNumber, ABatchNumber, EditGiftRow.GiftTransactionNumber, Transaction);
            });
            DB.CloseDBConnection();

            // try to get a row with requested id, aka edit else make a new
            ARecurringGiftDetailRow EditGiftDetailRow = null;
            foreach (ARecurringGiftDetailRow CheckGiftDetailRow in MainDS.ARecurringGiftDetail.Rows)
            {
                if (CheckGiftDetailRow.DetailNumber == ADetailNumber)
                {
                    EditGiftDetailRow = CheckGiftDetailRow;
                    break;
                }
            }

            // none found, make one
            if (EditGiftDetailRow == null)
            {
                EditGiftDetailRow = MainDS.ARecurringGiftDetail.NewRowTyped(true);
                EditGiftDetailRow.LedgerNumber = ALedgerNumber;
                EditGiftDetailRow.BatchNumber = ABatchNumber;
                EditGiftDetailRow.RecipientKey = ARecipientKey;
                EditGiftDetailRow.GiftTransactionNumber = EditGiftRow.GiftTransactionNumber;
                EditGiftDetailRow.DetailNumber = EditGiftRow.LastDetailNumber + 1;
                EditGiftRow.LastDetailNumber++;
                MainDS.ARecurringGiftDetail.Rows.Add(EditGiftDetailRow);
            }

            EditGiftRow.DonorKey = ADonorKey;
            EditGiftDetailRow.GiftAmount = AGiftAmount;
            EditGiftDetailRow.MotivationGroupCode = AMotivationGroupCode;
            EditGiftDetailRow.MotivationDetailCode = AMotivationDetailCode;
            EditGiftDetailRow.EndDonations = AEndDonations;
            EditGiftDetailRow.StartDonations = AStartDonations;

            try
            {
                SponsorshipTDSAccess.SubmitChanges(MainDS);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }

        }

        /// delete a detail of recurring gift
        [RequireModulePermission("SPONSORADMIN")]
        public static bool DeleteSponsorshipRecurringGift(
            Int32 ALedgerNumber,
            Int32 ABatchNumber,
            Int32 AGiftTransactionNumber,
            Int32 ADetailNumber,
            out TVerificationResultCollection AVerificationResult) 
        {
            AVerificationResult = new TVerificationResultCollection();

            TDBTransaction Transaction = new TDBTransaction();
            SponsorshipTDS MainDS = new SponsorshipTDS();
            TDataBase DB = DBAccess.Connect("DeleteRecurringGift");

            // load batches and their transactions based on their id / batch number
            DB.ReadTransaction(ref Transaction, delegate {
                ARecurringGiftBatchAccess.LoadByPrimaryKey(MainDS, ALedgerNumber, ABatchNumber, Transaction);
                ARecurringGiftAccess.LoadViaARecurringGiftBatch(MainDS, ALedgerNumber, ABatchNumber, Transaction);
                ARecurringGiftDetailAccess.LoadViaARecurringGiftBatch(MainDS, ALedgerNumber, ABatchNumber, Transaction);
            });

            try
            {
                bool LastDetail = true;
                ARecurringGiftDetailRow DetailToDelete = null;
                ARecurringGiftRow GiftToDelete = null;
                foreach (ARecurringGiftDetailRow CheckGiftDetailRow in MainDS.ARecurringGiftDetail.Rows)
                {
                    if (CheckGiftDetailRow.GiftTransactionNumber == AGiftTransactionNumber)
                    {
                        if (CheckGiftDetailRow.DetailNumber == ADetailNumber)
                        {
                            DetailToDelete = CheckGiftDetailRow;
                            DetailToDelete.DetailNumber = 20000;
                        }
                        else
                        {
                            LastDetail = false;
                            if (CheckGiftDetailRow.DetailNumber > ADetailNumber)
                            {
                                CheckGiftDetailRow.DetailNumber--;
                            }
                        }
                    }
                }

                foreach (ARecurringGiftRow CheckGiftRow in MainDS.ARecurringGift.Rows)
                {
                    if (CheckGiftRow.GiftTransactionNumber == AGiftTransactionNumber)
                    {
                        if (LastDetail)
                        {
                            GiftToDelete = CheckGiftRow;
                        }
                        else
                        {
                            CheckGiftRow.LastDetailNumber--;
                        }
                    }
                }

                // delete the detail
                if (DetailToDelete != null)
                {
                    DetailToDelete.Delete();
                }

                // delete the gift
                if (GiftToDelete != null)
                {
                    // we keep the gift transaction numbers, and live with gaps.
                    GiftToDelete.Delete();
                }

                SponsorshipTDSAccess.SubmitChanges(MainDS, DB);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }
            finally
            {
                DB.CloseDBConnection();
            }
        }
    }
}

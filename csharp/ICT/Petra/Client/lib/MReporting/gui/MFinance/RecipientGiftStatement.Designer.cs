// auto generated with nant generateWinforms from RecipientGiftStatement.yaml
//
// DO NOT edit manually, DO NOT edit with the designer
//
//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       auto generated
//
// Copyright 2004-2010 by OM International
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
using System.Windows.Forms;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonControls;

namespace Ict.Petra.Client.MReporting.Gui.MFinance
{
    partial class TFrmRecipientGiftStatement
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrmRecipientGiftStatement));

            this.tabReportSettings = new Ict.Common.Controls.TTabVersatile();
            this.tpgGeneralSettings = new System.Windows.Forms.TabPage();
            this.grpReportType = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbReportType = new Ict.Common.Controls.TCmbAutoComplete();
            this.lblReportType = new System.Windows.Forms.Label();
            this.grpDateSelection = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpFromDate = new Ict.Petra.Client.CommonControls.TtxtPetraDate();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpToDate = new Ict.Petra.Client.CommonControls.TtxtPetraDate();
            this.lblToDate = new System.Windows.Forms.Label();
            this.rgrRecipientSelection = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtAllRecipients = new System.Windows.Forms.RadioButton();
            this.rbtExtract = new System.Windows.Forms.RadioButton();
            this.txtExtract = new Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel();
            this.rbtPartner = new System.Windows.Forms.RadioButton();
            this.txtRecipient = new Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel();
            this.grpCurrencySelection = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCurrency = new Ict.Common.Controls.TCmbAutoComplete();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.tpgColumnSettings = new System.Windows.Forms.TabPage();
            this.uco_Columns = new Ict.Petra.Client.MReporting.Gui.TFrmUC_PartnerColumns();
            this.tpgAdditionalSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.rgrFormatCurrency = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtCurrencyComplete = new System.Windows.Forms.RadioButton();
            this.rbtCurrencyWithoutDecimals = new System.Windows.Forms.RadioButton();
            this.rbtCurrencyThousands = new System.Windows.Forms.RadioButton();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbGenerateReport = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveSettings = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveSettingsAs = new System.Windows.Forms.ToolStripButton();
            this.tbbLoadSettingsDialog = new System.Windows.Forms.ToolStripButton();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettingsDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.mniLoadSettings1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveSettingsAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMaintainSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniWrapColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniGenerateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpPetraHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpAboutPetra = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpDevelopmentTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.stbMain = new Ict.Common.Controls.TExtStatusBarHelp();

            this.tabReportSettings.SuspendLayout();
            this.tpgGeneralSettings.SuspendLayout();
            this.grpReportType.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpDateSelection.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.rgrRecipientSelection.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpCurrencySelection.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tpgColumnSettings.SuspendLayout();
            this.tpgAdditionalSettings.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.rgrFormatCurrency.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.stbMain.SuspendLayout();

            //
            // tpgGeneralSettings
            //
            this.tpgGeneralSettings.Location = new System.Drawing.Point(2,2);
            this.tpgGeneralSettings.Name = "tpgGeneralSettings";
            this.tpgGeneralSettings.AutoSize = true;
            this.tpgGeneralSettings.Controls.Add(this.grpCurrencySelection);
            this.tpgGeneralSettings.Controls.Add(this.rgrRecipientSelection);
            this.tpgGeneralSettings.Controls.Add(this.grpDateSelection);
            this.tpgGeneralSettings.Controls.Add(this.grpReportType);
            //
            // grpReportType
            //
            this.grpReportType.Name = "grpReportType";
            this.grpReportType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReportType.AutoSize = true;
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.AutoSize = true;
            this.grpReportType.Controls.Add(this.tableLayoutPanel1);
            //
            // cmbReportType
            //
            this.cmbReportType.Location = new System.Drawing.Point(2,2);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(150, 28);
            this.cmbReportType.Items.AddRange(new object[] {"Complete","Gifts Only","Donors Only","List","Email"});
            //
            // lblReportType
            //
            this.lblReportType.Location = new System.Drawing.Point(2,2);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.AutoSize = true;
            this.lblReportType.Text = "Report Type:";
            this.lblReportType.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblReportType.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblReportType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblReportType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbReportType, 1, 0);
            this.grpReportType.Text = "Report Type";
            //
            // grpDateSelection
            //
            this.grpDateSelection.Name = "grpDateSelection";
            this.grpDateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDateSelection.AutoSize = true;
            //
            // tableLayoutPanel2
            //
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.AutoSize = true;
            this.grpDateSelection.Controls.Add(this.tableLayoutPanel2);
            //
            // dtpFromDate
            //
            this.dtpFromDate.Location = new System.Drawing.Point(2,2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(94, 28);
            //
            // lblFromDate
            //
            this.lblFromDate.Location = new System.Drawing.Point(2,2);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Text = "From:";
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // dtpToDate
            //
            this.dtpToDate.Location = new System.Drawing.Point(2,2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(94, 28);
            //
            // lblToDate
            //
            this.lblToDate.Location = new System.Drawing.Point(2,2);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.AutoSize = true;
            this.lblToDate.Text = "To:";
            this.lblToDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblFromDate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblToDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpFromDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpToDate, 1, 1);
            this.grpDateSelection.Text = "Select Date";
            //
            // rgrRecipientSelection
            //
            this.rgrRecipientSelection.Name = "rgrRecipientSelection";
            this.rgrRecipientSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgrRecipientSelection.AutoSize = true;
            //
            // tableLayoutPanel3
            //
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.AutoSize = true;
            this.rgrRecipientSelection.Controls.Add(this.tableLayoutPanel3);
            //
            // rbtAllRecipients
            //
            this.rbtAllRecipients.Location = new System.Drawing.Point(2,2);
            this.rbtAllRecipients.Name = "rbtAllRecipients";
            this.rbtAllRecipients.AutoSize = true;
            this.rbtAllRecipients.Text = "All Recipients";
            this.rbtAllRecipients.Checked = true;
            //
            // rbtExtract
            //
            this.rbtExtract.Location = new System.Drawing.Point(2,2);
            this.rbtExtract.Name = "rbtExtract";
            this.rbtExtract.AutoSize = true;
            this.rbtExtract.Text = "From Extract";
            //
            // txtExtract
            //
            this.txtExtract.Location = new System.Drawing.Point(2,2);
            this.txtExtract.Name = "txtExtract";
            this.txtExtract.Size = new System.Drawing.Size(400, 28);
            this.txtExtract.ASpecialSetting = true;
            this.txtExtract.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtExtract.ListTable = TtxtAutoPopulatedButtonLabel.TListTableEnum.Extract;
            this.txtExtract.PartnerClass = "";
            this.txtExtract.MaxLength = 32767;
            this.txtExtract.Tag = "CustomDisableAlthoughInvisible";
            this.txtExtract.TextBoxWidth = 80;
            this.txtExtract.ButtonWidth = 40;
            this.txtExtract.ReadOnly = false;
            this.txtExtract.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtExtract.ButtonText = "Find";
            this.rbtExtract.CheckedChanged += new System.EventHandler(this.rbtExtractCheckedChanged);
            //
            // rbtPartner
            //
            this.rbtPartner.Location = new System.Drawing.Point(2,2);
            this.rbtPartner.Name = "rbtPartner";
            this.rbtPartner.AutoSize = true;
            this.rbtPartner.Text = "One Recipient";
            //
            // txtRecipient
            //
            this.txtRecipient.Location = new System.Drawing.Point(2,2);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(400, 28);
            this.txtRecipient.ASpecialSetting = true;
            this.txtRecipient.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRecipient.ListTable = TtxtAutoPopulatedButtonLabel.TListTableEnum.PartnerKey;
            this.txtRecipient.PartnerClass = "";
            this.txtRecipient.MaxLength = 32767;
            this.txtRecipient.Tag = "CustomDisableAlthoughInvisible";
            this.txtRecipient.TextBoxWidth = 80;
            this.txtRecipient.ButtonWidth = 40;
            this.txtRecipient.ReadOnly = false;
            this.txtRecipient.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtRecipient.ButtonText = "Find";
            this.rbtPartner.CheckedChanged += new System.EventHandler(this.rbtPartnerCheckedChanged);
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.SetColumnSpan(this.rbtAllRecipients, 2);
            this.tableLayoutPanel3.Controls.Add(this.rbtAllRecipients, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtExtract, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rbtPartner, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtExtract, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtRecipient, 1, 2);
            this.rgrRecipientSelection.Text = "Select Recipients";
            //
            // grpCurrencySelection
            //
            this.grpCurrencySelection.Name = "grpCurrencySelection";
            this.grpCurrencySelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCurrencySelection.AutoSize = true;
            //
            // tableLayoutPanel4
            //
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.AutoSize = true;
            this.grpCurrencySelection.Controls.Add(this.tableLayoutPanel4);
            //
            // cmbCurrency
            //
            this.cmbCurrency.Location = new System.Drawing.Point(2,2);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(150, 28);
            this.cmbCurrency.Items.AddRange(new object[] {"Base","International"});
            //
            // lblCurrency
            //
            this.lblCurrency.Location = new System.Drawing.Point(2,2);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Text = "Currency:";
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCurrency.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Controls.Add(this.lblCurrency, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbCurrency, 1, 0);
            this.grpCurrencySelection.Text = "Select Currency";
            this.tpgGeneralSettings.Text = "General Settings";
            this.tpgGeneralSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            // tpgColumnSettings
            //
            this.tpgColumnSettings.Location = new System.Drawing.Point(2,2);
            this.tpgColumnSettings.Name = "tpgColumnSettings";
            this.tpgColumnSettings.AutoSize = true;
            this.tpgColumnSettings.Controls.Add(this.uco_Columns);
            //
            // uco_Columns
            //
            this.uco_Columns.Name = "uco_Columns";
            this.uco_Columns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpgColumnSettings.Text = "Column Settings";
            this.tpgColumnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            // tpgAdditionalSettings
            //
            this.tpgAdditionalSettings.Location = new System.Drawing.Point(2,2);
            this.tpgAdditionalSettings.Name = "tpgAdditionalSettings";
            this.tpgAdditionalSettings.AutoSize = true;
            //
            // tableLayoutPanel5
            //
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.AutoSize = true;
            this.tpgAdditionalSettings.Controls.Add(this.tableLayoutPanel5);
            //
            // rgrFormatCurrency
            //
            this.rgrFormatCurrency.Location = new System.Drawing.Point(2,2);
            this.rgrFormatCurrency.Name = "rgrFormatCurrency";
            this.rgrFormatCurrency.AutoSize = true;
            //
            // tableLayoutPanel6
            //
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.AutoSize = true;
            this.rgrFormatCurrency.Controls.Add(this.tableLayoutPanel6);
            //
            // rbtCurrencyComplete
            //
            this.rbtCurrencyComplete.Location = new System.Drawing.Point(2,2);
            this.rbtCurrencyComplete.Name = "rbtCurrencyComplete";
            this.rbtCurrencyComplete.AutoSize = true;
            this.rbtCurrencyComplete.Text = "Complete";
            this.rbtCurrencyComplete.Checked = true;
            //
            // rbtCurrencyWithoutDecimals
            //
            this.rbtCurrencyWithoutDecimals.Location = new System.Drawing.Point(2,2);
            this.rbtCurrencyWithoutDecimals.Name = "rbtCurrencyWithoutDecimals";
            this.rbtCurrencyWithoutDecimals.AutoSize = true;
            this.rbtCurrencyWithoutDecimals.Text = "Without decimals";
            //
            // rbtCurrencyThousands
            //
            this.rbtCurrencyThousands.Location = new System.Drawing.Point(2,2);
            this.rbtCurrencyThousands.Name = "rbtCurrencyThousands";
            this.rbtCurrencyThousands.AutoSize = true;
            this.rbtCurrencyThousands.Text = "Only Thousands";
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Controls.Add(this.rbtCurrencyComplete, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.rbtCurrencyWithoutDecimals, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.rbtCurrencyThousands, 0, 2);
            this.rgrFormatCurrency.Text = "Format currency numbers:";
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Controls.Add(this.rgrFormatCurrency, 0, 0);
            this.tpgAdditionalSettings.Text = "Additional Settings";
            this.tpgAdditionalSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            // tabReportSettings
            //
            this.tabReportSettings.Name = "tabReportSettings";
            this.tabReportSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportSettings.Controls.Add(this.tpgGeneralSettings);
            this.tabReportSettings.Controls.Add(this.tpgColumnSettings);
            this.tabReportSettings.Controls.Add(this.tpgAdditionalSettings);
            this.tabReportSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //
            // tbbGenerateReport
            //
            this.tbbGenerateReport.Name = "tbbGenerateReport";
            this.tbbGenerateReport.AutoSize = true;
            this.tbbGenerateReport.Click += new System.EventHandler(this.actGenerateReport);
            this.tbbGenerateReport.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbGenerateReport.Glyph"));
            this.tbbGenerateReport.ToolTipText = "Generate the report";
            this.tbbGenerateReport.Text = "&Generate";
            //
            // tbbSaveSettings
            //
            this.tbbSaveSettings.Name = "tbbSaveSettings";
            this.tbbSaveSettings.AutoSize = true;
            this.tbbSaveSettings.Click += new System.EventHandler(this.actSaveSettings);
            this.tbbSaveSettings.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbSaveSettings.Glyph"));
            this.tbbSaveSettings.Text = "&Save Settings";
            //
            // tbbSaveSettingsAs
            //
            this.tbbSaveSettingsAs.Name = "tbbSaveSettingsAs";
            this.tbbSaveSettingsAs.AutoSize = true;
            this.tbbSaveSettingsAs.Click += new System.EventHandler(this.actSaveSettingsAs);
            this.tbbSaveSettingsAs.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbSaveSettingsAs.Glyph"));
            this.tbbSaveSettingsAs.Text = "Save Settings &As...";
            //
            // tbbLoadSettingsDialog
            //
            this.tbbLoadSettingsDialog.Name = "tbbLoadSettingsDialog";
            this.tbbLoadSettingsDialog.AutoSize = true;
            this.tbbLoadSettingsDialog.Click += new System.EventHandler(this.actLoadSettingsDialog);
            this.tbbLoadSettingsDialog.Text = "&Open...";
            //
            // tbrMain
            //
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbrMain.AutoSize = true;
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           tbbGenerateReport,
                        tbbSaveSettings,
                        tbbSaveSettingsAs,
                        tbbLoadSettingsDialog});
            //
            // mniLoadSettingsDialog
            //
            this.mniLoadSettingsDialog.Name = "mniLoadSettingsDialog";
            this.mniLoadSettingsDialog.AutoSize = true;
            this.mniLoadSettingsDialog.Click += new System.EventHandler(this.actLoadSettingsDialog);
            this.mniLoadSettingsDialog.Text = "&Open...";
            //
            // mniSeparator0
            //
            this.mniSeparator0.Name = "mniSeparator0";
            this.mniSeparator0.AutoSize = true;
            this.mniSeparator0.Text = "-";
            //
            // mniLoadSettings1
            //
            this.mniLoadSettings1.Name = "mniLoadSettings1";
            this.mniLoadSettings1.AutoSize = true;
            this.mniLoadSettings1.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings1.Text = "RecentSettings";
            //
            // mniLoadSettings2
            //
            this.mniLoadSettings2.Name = "mniLoadSettings2";
            this.mniLoadSettings2.AutoSize = true;
            this.mniLoadSettings2.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings2.Text = "RecentSettings";
            //
            // mniLoadSettings3
            //
            this.mniLoadSettings3.Name = "mniLoadSettings3";
            this.mniLoadSettings3.AutoSize = true;
            this.mniLoadSettings3.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings3.Text = "RecentSettings";
            //
            // mniLoadSettings4
            //
            this.mniLoadSettings4.Name = "mniLoadSettings4";
            this.mniLoadSettings4.AutoSize = true;
            this.mniLoadSettings4.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings4.Text = "RecentSettings";
            //
            // mniLoadSettings5
            //
            this.mniLoadSettings5.Name = "mniLoadSettings5";
            this.mniLoadSettings5.AutoSize = true;
            this.mniLoadSettings5.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings5.Text = "RecentSettings";
            //
            // mniLoadSettings
            //
            this.mniLoadSettings.Name = "mniLoadSettings";
            this.mniLoadSettings.AutoSize = true;
            this.mniLoadSettings.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniLoadSettingsDialog,
                        mniSeparator0,
                        mniLoadSettings1,
                        mniLoadSettings2,
                        mniLoadSettings3,
                        mniLoadSettings4,
                        mniLoadSettings5});
            this.mniLoadSettings.Text = "&Load Settings";
            //
            // mniSaveSettings
            //
            this.mniSaveSettings.Name = "mniSaveSettings";
            this.mniSaveSettings.AutoSize = true;
            this.mniSaveSettings.Click += new System.EventHandler(this.actSaveSettings);
            this.mniSaveSettings.Image = ((System.Drawing.Bitmap)resources.GetObject("mniSaveSettings.Glyph"));
            this.mniSaveSettings.Text = "&Save Settings";
            //
            // mniSaveSettingsAs
            //
            this.mniSaveSettingsAs.Name = "mniSaveSettingsAs";
            this.mniSaveSettingsAs.AutoSize = true;
            this.mniSaveSettingsAs.Click += new System.EventHandler(this.actSaveSettingsAs);
            this.mniSaveSettingsAs.Image = ((System.Drawing.Bitmap)resources.GetObject("mniSaveSettingsAs.Glyph"));
            this.mniSaveSettingsAs.Text = "Save Settings &As...";
            //
            // mniMaintainSettings
            //
            this.mniMaintainSettings.Name = "mniMaintainSettings";
            this.mniMaintainSettings.AutoSize = true;
            this.mniMaintainSettings.Click += new System.EventHandler(this.actMaintainSettings);
            this.mniMaintainSettings.Text = "&Maintain Settings...";
            //
            // mniSeparator1
            //
            this.mniSeparator1.Name = "mniSeparator1";
            this.mniSeparator1.AutoSize = true;
            this.mniSeparator1.Text = "-";
            //
            // mniWrapColumn
            //
            this.mniWrapColumn.Name = "mniWrapColumn";
            this.mniWrapColumn.AutoSize = true;
            this.mniWrapColumn.Click += new System.EventHandler(this.actWrapColumn);
            this.mniWrapColumn.Text = "&Wrap Columns";
            //
            // mniSeparator2
            //
            this.mniSeparator2.Name = "mniSeparator2";
            this.mniSeparator2.AutoSize = true;
            this.mniSeparator2.Text = "-";
            //
            // mniGenerateReport
            //
            this.mniGenerateReport.Name = "mniGenerateReport";
            this.mniGenerateReport.AutoSize = true;
            this.mniGenerateReport.Click += new System.EventHandler(this.actGenerateReport);
            this.mniGenerateReport.Image = ((System.Drawing.Bitmap)resources.GetObject("mniGenerateReport.Glyph"));
            this.mniGenerateReport.ToolTipText = "Generate the report";
            this.mniGenerateReport.Text = "&Generate";
            //
            // mniSeparator3
            //
            this.mniSeparator3.Name = "mniSeparator3";
            this.mniSeparator3.AutoSize = true;
            this.mniSeparator3.Text = "-";
            //
            // mniClose
            //
            this.mniClose.Name = "mniClose";
            this.mniClose.AutoSize = true;
            this.mniClose.Click += new System.EventHandler(this.actClose);
            this.mniClose.Image = ((System.Drawing.Bitmap)resources.GetObject("mniClose.Glyph"));
            this.mniClose.ToolTipText = "Closes this window";
            this.mniClose.Text = "&Close";
            //
            // mniFile
            //
            this.mniFile.Name = "mniFile";
            this.mniFile.AutoSize = true;
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniLoadSettings,
                        mniSaveSettings,
                        mniSaveSettingsAs,
                        mniMaintainSettings,
                        mniSeparator1,
                        mniWrapColumn,
                        mniSeparator2,
                        mniGenerateReport,
                        mniSeparator3,
                        mniClose});
            this.mniFile.Text = "&File";
            //
            // mniHelpPetraHelp
            //
            this.mniHelpPetraHelp.Name = "mniHelpPetraHelp";
            this.mniHelpPetraHelp.AutoSize = true;
            this.mniHelpPetraHelp.Text = "&Petra Help";
            //
            // mniSeparator4
            //
            this.mniSeparator4.Name = "mniSeparator4";
            this.mniSeparator4.AutoSize = true;
            this.mniSeparator4.Text = "-";
            //
            // mniHelpBugReport
            //
            this.mniHelpBugReport.Name = "mniHelpBugReport";
            this.mniHelpBugReport.AutoSize = true;
            this.mniHelpBugReport.Text = "Bug &Report";
            //
            // mniSeparator5
            //
            this.mniSeparator5.Name = "mniSeparator5";
            this.mniSeparator5.AutoSize = true;
            this.mniSeparator5.Text = "-";
            //
            // mniHelpAboutPetra
            //
            this.mniHelpAboutPetra.Name = "mniHelpAboutPetra";
            this.mniHelpAboutPetra.AutoSize = true;
            this.mniHelpAboutPetra.Text = "&About Petra";
            //
            // mniHelpDevelopmentTeam
            //
            this.mniHelpDevelopmentTeam.Name = "mniHelpDevelopmentTeam";
            this.mniHelpDevelopmentTeam.AutoSize = true;
            this.mniHelpDevelopmentTeam.Text = "&The Development Team...";
            //
            // mniHelp
            //
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.AutoSize = true;
            this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniHelpPetraHelp,
                        mniSeparator4,
                        mniHelpBugReport,
                        mniSeparator5,
                        mniHelpAboutPetra,
                        mniHelpDevelopmentTeam});
            this.mniHelp.Text = "&Help";
            //
            // mnuMain
            //
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.AutoSize = true;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniFile,
                        mniHelp});
            //
            // stbMain
            //
            this.stbMain.Name = "stbMain";
            this.stbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stbMain.AutoSize = true;

            //
            // TFrmRecipientGiftStatement
            //
            this.Font = new System.Drawing.Font("Verdana", 8.25f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(680, 480);

            this.Controls.Add(this.tabReportSettings);
            this.Controls.Add(this.tbrMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = mnuMain;
            this.Controls.Add(this.stbMain);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");

            this.Name = "TFrmRecipientGiftStatement";
            this.Text = "Recipient Gift Statement";

            this.Activated += new System.EventHandler(this.TFrmPetra_Activated);
            this.Load += new System.EventHandler(this.TFrmPetra_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TFrmPetra_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.Closed += new System.EventHandler(this.TFrmPetra_Closed);

            this.stbMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.tbrMain.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.rgrFormatCurrency.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tpgAdditionalSettings.ResumeLayout(false);
            this.tpgColumnSettings.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.grpCurrencySelection.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.rgrRecipientSelection.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpDateSelection.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpReportType.ResumeLayout(false);
            this.tpgGeneralSettings.ResumeLayout(false);
            this.tabReportSettings.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Ict.Common.Controls.TTabVersatile tabReportSettings;
        private System.Windows.Forms.TabPage tpgGeneralSettings;
        private System.Windows.Forms.GroupBox grpReportType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Ict.Common.Controls.TCmbAutoComplete cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.GroupBox grpDateSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Ict.Petra.Client.CommonControls.TtxtPetraDate dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private Ict.Petra.Client.CommonControls.TtxtPetraDate dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.GroupBox rgrRecipientSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rbtAllRecipients;
        private System.Windows.Forms.RadioButton rbtExtract;
        private Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel txtExtract;
        private System.Windows.Forms.RadioButton rbtPartner;
        private Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel txtRecipient;
        private System.Windows.Forms.GroupBox grpCurrencySelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Ict.Common.Controls.TCmbAutoComplete cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.TabPage tpgColumnSettings;
        private Ict.Petra.Client.MReporting.Gui.TFrmUC_PartnerColumns uco_Columns;
        private System.Windows.Forms.TabPage tpgAdditionalSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox rgrFormatCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.RadioButton rbtCurrencyComplete;
        private System.Windows.Forms.RadioButton rbtCurrencyWithoutDecimals;
        private System.Windows.Forms.RadioButton rbtCurrencyThousands;
        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.ToolStripButton tbbGenerateReport;
        private System.Windows.Forms.ToolStripButton tbbSaveSettings;
        private System.Windows.Forms.ToolStripButton tbbSaveSettingsAs;
        private System.Windows.Forms.ToolStripButton tbbLoadSettingsDialog;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettingsDialog;
        private System.Windows.Forms.ToolStripSeparator mniSeparator0;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings1;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings2;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings3;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings4;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings5;
        private System.Windows.Forms.ToolStripMenuItem mniSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem mniSaveSettingsAs;
        private System.Windows.Forms.ToolStripMenuItem mniMaintainSettings;
        private System.Windows.Forms.ToolStripSeparator mniSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniWrapColumn;
        private System.Windows.Forms.ToolStripSeparator mniSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniGenerateReport;
        private System.Windows.Forms.ToolStripSeparator mniSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniClose;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
        private System.Windows.Forms.ToolStripMenuItem mniHelpPetraHelp;
        private System.Windows.Forms.ToolStripSeparator mniSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mniHelpBugReport;
        private System.Windows.Forms.ToolStripSeparator mniSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniHelpAboutPetra;
        private System.Windows.Forms.ToolStripMenuItem mniHelpDevelopmentTeam;
        private Ict.Common.Controls.TExtStatusBarHelp stbMain;
    }
}

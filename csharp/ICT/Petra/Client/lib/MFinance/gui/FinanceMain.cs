// auto generated with nant generateWinforms from FinanceMain.yaml
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ict.Petra.Shared;
using System.Resources;
using System.Collections.Specialized;
using GNU.Gettext;
using Ict.Common;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.App.Core.RemoteObjects;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonForms;

namespace Ict.Petra.Client.MFinance.Gui
{

  /// auto generated: Finance Module OpenPetra.org
  public partial class TFrmFinanceMain: System.Windows.Forms.Form, Ict.Petra.Client.CommonForms.IFrmPetra
  {
    private TFrmPetraModuleUtils FPetraUtilsObject;

    /// constructor
    public TFrmFinanceMain(IntPtr AParentFormHandle) : base()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      #region CATALOGI18N

      // this code has been inserted by GenerateI18N, all changes in this region will be overwritten by GenerateI18N
      this.mniSelectLedger.Text = Catalog.GetString("&Select Ledger");
      this.mniNewLedger.Text = Catalog.GetString("&New Ledger");
      this.mniDeleteLedger.Text = Catalog.GetString("&Delete Ledger");
      this.mniClose.ToolTipText = Catalog.GetString("Closes this window");
      this.mniClose.Text = Catalog.GetString("&Close");
      this.mniFile.Text = Catalog.GetString("&File");
      this.mniSetupParameters.Text = Catalog.GetString("&Parameters");
      this.mniSetupTablesTodo.Text = Catalog.GetString("&Todo");
      this.mniSetupTables.Text = Catalog.GetString("&Tables");
      this.mniSetupCostCentres.Text = Catalog.GetString("&Cost Centres");
      this.mniSetupAccounts.Text = Catalog.GetString("&Accounts");
      this.mniLedgerSetup.Text = Catalog.GetString("&Setup");
      this.mniGLCurrentPeriod.Text = Catalog.GetString("&Current Period");
      this.mniGLPreviousPeriods.Text = Catalog.GetString("&Previous Periods");
      this.mniGLRecurring.Text = Catalog.GetString("&Recurring");
      this.mniGLImport.Text = Catalog.GetString("&Import");
      this.mniGLExport.Text = Catalog.GetString("E&xport");
      this.mniGLBatch.Text = Catalog.GetString("G&L Batch");
      this.mniMonthEndClosing.Text = Catalog.GetString("&Month End Closing");
      this.mniYearEndClosing.Text = Catalog.GetString("&Year End Closing");
      this.mniPeriodEnd.Text = Catalog.GetString("&Period End");
      this.mniImportBankStatements.Text = Catalog.GetString("Import &Bank statements");
      this.mniGiftBatch.Text = Catalog.GetString("&Gift Batch");
      this.mniRecurringGiftBatch.Text = Catalog.GetString("&Recurring Gift Batch");
      this.mniGiftImport.Text = Catalog.GetString("Gift &Import");
      this.mniGiftExport.Text = Catalog.GetString("Gift E&xport");
      this.mniGiftReceipts.Text = Catalog.GetString("&Print Receipts");
      this.mniGiftReceipting.Text = Catalog.GetString("&Gift Receipting");
      this.mniAccountsPayable.Text = Catalog.GetString("&Accounts Payable");
      this.mniBudget.Text = Catalog.GetString("&Budget");
      this.mniICHCalculation.Text = Catalog.GetString("ICH &calculation");
      this.mniICHImportFile.Text = Catalog.GetString("&Import file from field");
      this.mniICHReports.Text = Catalog.GetString("ICH &reports...");
      this.mniClearingHouse.Text = Catalog.GetString("&Clearing House");
      this.mniLedger.Text = Catalog.GetString("&Ledger");
      this.mniAccountDetail.Text = Catalog.GetString("Account Detail");
      this.mniGLReports.Text = Catalog.GetString("&GL");
      this.mniGiftReports.Text = Catalog.GetString("G&ift");
      this.mniAPReports.Text = Catalog.GetString("Accounts &Payable");
      this.mniReports.Text = Catalog.GetString("&Reports");
      this.mniConsolidations.Text = Catalog.GetString("&Consolidations");
      this.mniSetupCurrency.Text = Catalog.GetString("&Currency");
      this.mniSetupCorporateExchangeRate.Text = Catalog.GetString("C&orporate Exchange Rate");
      this.mniSetupDailyExchangeRate.Text = Catalog.GetString("&Daily Exchange Rate");
      this.mniSetupMethodOfGiving.Text = Catalog.GetString("Method of &Giving");
      this.mniSetupMethodOfPayment.Text = Catalog.GetString("Method of &Payment");
      this.mniSetupAnalysisTypes.Text = Catalog.GetString("A&nalysis Types");
      this.mniSetupLetters.Text = Catalog.GetString("&Letters");
      this.mniFinanceSetup.Text = Catalog.GetString("&Setup");
      this.mniPetraMainMenu.Text = Catalog.GetString("Petra &Main Menu");
      this.mniPetraPartnerModule.Text = Catalog.GetString("Pa&rtner");
      this.mniPetraFinanceModule.Text = Catalog.GetString("&Finance");
      this.mniPetraPersonnelModule.Text = Catalog.GetString("P&ersonnel");
      this.mniPetraConferenceModule.Text = Catalog.GetString("C&onference");
      this.mniPetraFinDevModule.Text = Catalog.GetString("Financial &Development");
      this.mniPetraSysManModule.Text = Catalog.GetString("&System Manager");
      this.mniPetraModules.Text = Catalog.GetString("&OpenPetra");
      this.mniHelpPetraHelp.Text = Catalog.GetString("&Petra Help");
      this.mniHelpBugReport.Text = Catalog.GetString("Bug &Report");
      this.mniHelpAboutPetra.Text = Catalog.GetString("&About Petra");
      this.mniHelpDevelopmentTeam.Text = Catalog.GetString("&The Development Team...");
      this.mniHelp.Text = Catalog.GetString("&Help");
      this.Text = Catalog.GetString("Finance Module OpenPetra.org");
      #endregion

      FPetraUtilsObject = new TFrmPetraModuleUtils(AParentFormHandle, this, stbMain);
      InitializeManualCode();
      FPetraUtilsObject.ActionEnablingEvent += ActionEnabledEvent;

      FPetraUtilsObject.InitActionState();

    }

    private void TFrmPetra_Activated(object sender, EventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Activated(sender, e);
    }

    private void TFrmPetra_Load(object sender, EventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Load(sender, e);
    }

    private void TFrmPetra_Closing(object sender, CancelEventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Closing(sender, e);
    }

    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        FPetraUtilsObject.Form_KeyDown(sender, e);
    }

    private void TFrmPetra_Closed(object sender, EventArgs e)
    {
        // TODO? Save Window position
    }

#region Implement interface functions

    /// auto generated
    public void RunOnceOnActivation()
    {
    }

    /// <summary>
    /// Adds event handlers for the appropiate onChange event to call a central procedure
    /// </summary>
    public void HookupAllControls()
    {
    }

    /// auto generated
    public void HookupAllInContainer(Control container)
    {
        FPetraUtilsObject.HookupAllInContainer(container);
    }

    /// auto generated
    public bool CanClose()
    {
        return FPetraUtilsObject.CanClose();
    }

    /// auto generated
    public TFrmPetraUtils GetPetraUtilsObject()
    {
        return (TFrmPetraUtils)FPetraUtilsObject;
    }
#endregion

#region Action Handling

    /// auto generated
    public void ActionEnabledEvent(object sender, ActionEventArgs e)
    {
        if (e.ActionName == "actClose")
        {
            mniClose.Enabled = e.Enabled;
        }
        if (e.ActionName == "actMainMenu")
        {
            mniPetraMainMenu.Enabled = e.Enabled;
        }
        if (e.ActionName == "actPartnerModule")
        {
            mniPetraPartnerModule.Enabled = e.Enabled;
        }
        if (e.ActionName == "actFinanceModule")
        {
            mniPetraFinanceModule.Enabled = e.Enabled;
        }
        if (e.ActionName == "actPersonnelModule")
        {
            mniPetraPersonnelModule.Enabled = e.Enabled;
        }
        if (e.ActionName == "actConferenceModule")
        {
            mniPetraConferenceModule.Enabled = e.Enabled;
        }
        if (e.ActionName == "actFinDevModule")
        {
            mniPetraFinDevModule.Enabled = e.Enabled;
        }
        if (e.ActionName == "actSysManModule")
        {
            mniPetraSysManModule.Enabled = e.Enabled;
        }
        mniSelectLedger.Enabled = false;
        mniNewLedger.Enabled = false;
        mniDeleteLedger.Enabled = false;
        mniSetupParameters.Enabled = false;
        mniSetupTablesTodo.Enabled = false;
        mniSetupCostCentres.Enabled = false;
        mniSetupAccounts.Enabled = false;
        mniGLPreviousPeriods.Enabled = false;
        mniGLRecurring.Enabled = false;
        mniGLImport.Enabled = false;
        mniGLExport.Enabled = false;
        mniMonthEndClosing.Enabled = false;
        mniYearEndClosing.Enabled = false;
        mniGiftBatch.Enabled = false;
        mniRecurringGiftBatch.Enabled = false;
        mniGiftImport.Enabled = false;
        mniGiftExport.Enabled = false;
        mniGiftReceipts.Enabled = false;
        mniBudget.Enabled = false;
        mniICHCalculation.Enabled = false;
        mniICHImportFile.Enabled = false;
        mniICHReports.Enabled = false;
        mniGiftReports.Enabled = false;
        mniAPReports.Enabled = false;
        mniConsolidations.Enabled = false;
        mniSetupCorporateExchangeRate.Enabled = false;
        mniSetupMethodOfGiving.Enabled = false;
        mniSetupMethodOfPayment.Enabled = false;
        mniSetupAnalysisTypes.Enabled = false;
        mniSetupLetters.Enabled = false;
        mniHelpPetraHelp.Enabled = false;
        mniHelpBugReport.Enabled = false;
        mniHelpAboutPetra.Enabled = false;
        mniHelpDevelopmentTeam.Enabled = false;
    }

    /// auto generated
    protected void OpenScreenGLCurrentPeriod(object sender, EventArgs e)
    {
        Ict.Petra.Client.MFinance.Gui.GL.TFrmGLBatch frm = new Ict.Petra.Client.MFinance.Gui.GL.TFrmGLBatch(this.Handle);
        frm.LedgerNumber = FLedgerNumber;
        frm.Show();
    }

    /// auto generated
    protected void OpenScreenImportBankStatements(object sender, EventArgs e)
    {
        Ict.Petra.Client.MFinance.Gui.Common.TFrmBankStatementImport frm = new Ict.Petra.Client.MFinance.Gui.Common.TFrmBankStatementImport(this.Handle);
        frm.LedgerNumber = FLedgerNumber;
        frm.Show();
    }

    /// auto generated
    protected void OpenScreenAccountsPayable(object sender, EventArgs e)
    {
        Ict.Petra.Client.MFinance.Gui.AP.TFrmAPMain frm = new Ict.Petra.Client.MFinance.Gui.AP.TFrmAPMain(this.Handle);
        frm.LedgerNumber = FLedgerNumber;
        frm.Show();
    }

    /// auto generated
    protected void OpenScreenAccountDetail(object sender, EventArgs e)
    {
        Ict.Petra.Client.MReporting.Gui.MFinance.TFrmAccountDetail frm = new Ict.Petra.Client.MReporting.Gui.MFinance.TFrmAccountDetail(this.Handle);
        frm.LedgerNumber = FLedgerNumber;
        frm.Show();
    }

    /// auto generated
    protected void OpenScreenSetupCurrency(object sender, EventArgs e)
    {
        Ict.Petra.Client.MCommon.Gui.Setup.TFrmSetupCurrency frm = new Ict.Petra.Client.MCommon.Gui.Setup.TFrmSetupCurrency(this.Handle);
        frm.Show();
    }

    /// auto generated
    protected void OpenScreenSetupDailyExchangeRate(object sender, EventArgs e)
    {
        Ict.Petra.Client.MFinance.Gui.Setup.TFrmSetupDailyExchangeRate frm = new Ict.Petra.Client.MFinance.Gui.Setup.TFrmSetupDailyExchangeRate(this.Handle);
        frm.Show();
    }

    /// auto generated
    protected void actClose(object sender, EventArgs e)
    {
        FPetraUtilsObject.ExecuteAction(eActionId.eClose);
    }

    /// auto generated
    protected void actMainMenu(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenMainScreen(sender, e);
    }

    /// auto generated
    protected void actPartnerModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenPartnerModule(sender, e);
    }

    /// auto generated
    protected void actFinanceModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenFinanceModule(sender, e);
    }

    /// auto generated
    protected void actPersonnelModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenPersonnelModule(sender, e);
    }

    /// auto generated
    protected void actConferenceModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenConferenceModule(sender, e);
    }

    /// auto generated
    protected void actFinDevModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenFinDevModule(sender, e);
    }

    /// auto generated
    protected void actSysManModule(object sender, EventArgs e)
    {
        FPetraUtilsObject.OpenSysManModule(sender, e);
    }

#endregion
  }
}

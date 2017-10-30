using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;

namespace microcosm
{
    /// <summary>
    /// 分離したから実際の名前はConfigViewControllerが正しい、けどまあいいや
    /// </summary>
    public partial class SettingsViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;

        private ViewController rootViewController;

        #region Constructors

        // Called when created from unmanaged code
        public SettingsViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingsViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingsViewController() : base("SettingsView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        public override void ViewDidLoad() 
        {
            base.ViewDidLoad();

            rootViewController = (ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController;

            config = rootViewController.config;

            for (int i = 0; i < 8; i++) {
                HouseRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.houseCalc == EHouseCalc.PLACIDUS) {
                HouseRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.KOCH) {
                HouseRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.CAMPANUS)
            {
                HouseRadioGroup.Cells[2].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.EQUAL)
            {
                HouseRadioGroup.Cells[3].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.PORPHYRY)
            {
                HouseRadioGroup.Cells[4].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.REGIOMONTANUS)
            {
                HouseRadioGroup.Cells[5].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.SOLAR)
            {
                HouseRadioGroup.Cells[6].State = NSCellStateValue.On;
            }
            else if (config.houseCalc == EHouseCalc.SOLARSIGN)
            {
                HouseRadioGroup.Cells[7].State = NSCellStateValue.On;
            }
            else 
            {
                HouseRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            for (int i = 0; i < 3; i++) {
                ProgressionRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.progression == EProgression.PRIMARY) {
                ProgressionRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.progression == EProgression.SECONDARY) {
                ProgressionRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else if (config.progression == EProgression.CPS) {
                ProgressionRadioGroup.Cells[2].State = NSCellStateValue.On;
            }
            else {
                ProgressionRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            for (int i = 0; i < 2; i++) {
                CentricRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.centric == ECentric.GEO_CENTRIC) {
                CentricRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.centric == ECentric.HELIO_CENTRIC) {
                CentricRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else {
                CentricRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            for (int i = 0; i < 2; i++) {
                SideRealRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.sidereal == Esidereal.TROPICAL) {
                SideRealRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.sidereal == Esidereal.SIDEREAL) {
                SideRealRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else {
                SideRealRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            for (int i = 0; i < 2; i++) {
                DoubleRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.decimalDisp == EDecimalDisp.DEGREE) {
                DoubleRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.decimalDisp == EDecimalDisp.DECIMAL) {
                DoubleRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else {
                DoubleRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            for (int i = 0; i < 2; i++) {
                DispTypeRadioGroup.Cells[i].State = NSCellStateValue.Off;
            }
            if (config.dispPattern2 == EDispPettern.MINI) {
                DispTypeRadioGroup.Cells[0].State = NSCellStateValue.On;
            }
            else if (config.dispPattern2 == EDispPettern.FULL) {
                DispTypeRadioGroup.Cells[1].State = NSCellStateValue.On;
            }
            else {
                DispTypeRadioGroup.Cells[0].State = NSCellStateValue.On;
            }

            /*
            SettingDetailPlanet.AllowsColumnSelection = true;
            SettingDetailPlanetTableDataSource DataSource = new SettingDetailPlanetTableDataSource();
            DataSource.dataList.Add(new SettingDetailPlanetTableData());

            SettingDetailPlanet.DataSource = DataSource;
            SettingDetailPlanet.Delegate = new SettingDetailPlanetTableDelegate(DataSource);
            SettingDetailPlanet.ReloadData();
            */

        }

        partial void SettingChanged(NSObject sender)
        {

        }

        partial void HouseChanged(NSObject sender)
        {
            nint row = ((NSMatrix)sender).SelectedRow;
            switch (row) {
                case 0:
                    config.houseCalc = EHouseCalc.PLACIDUS;
                    break;
                case 1:
                    config.houseCalc = EHouseCalc.KOCH;
                    break;
                case 2:
                    config.houseCalc = EHouseCalc.CAMPANUS;
                    break;
                case 3:
                    config.houseCalc = EHouseCalc.EQUAL;
                    break;
                case 4:
                    config.houseCalc = EHouseCalc.PORPHYRY;
                    break;
                case 5:
                    config.houseCalc = EHouseCalc.REGIOMONTANUS;
                    break;
                case 6:
                    config.houseCalc = EHouseCalc.SOLAR;
                    break;
                case 7:
                    config.houseCalc = EHouseCalc.SOLARSIGN;
                    break;
                default:
                    break;
            }
        }

        partial void ProgressionChanged(NSObject sender)
        {
            nint row = ProgressionRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.progression = EProgression.PRIMARY;
                    break;
                case 2:
                    config.progression = EProgression.SECONDARY;
                    break;
                case 3:
                    config.progression = EProgression.CPS;
                    break;
                default:
                    break;
            }

        }

        partial void CentricChanged(NSObject sender)
        {
            nint row = CentricRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.centric = ECentric.GEO_CENTRIC;
                    break;
                case 2:
                    config.centric = ECentric.HELIO_CENTRIC;
                    break;
                default:
                    break;
            }

        }

        partial void SideRealChanged(NSObject sender)
        {
            nint row = SideRealRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.sidereal = Esidereal.TROPICAL;
                    break;
                case 2:
                    config.sidereal = Esidereal.SIDEREAL;
                    break;
                default:
                    break;
            }

        }

        partial void DoubleChanged(NSObject sender)
        {
            nint row = DoubleRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.decimalDisp = EDecimalDisp.DEGREE;
                    break;
                case 2:
                    config.decimalDisp = EDecimalDisp.DECIMAL;
                    break;
                default:
                    break;
            }

        }

        partial void DispTypeChanged(NSObject sender)
        {
            nint row = DispTypeRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.dispPattern2 = EDispPettern.MINI;
                    break;
                case 2:
                    config.dispPattern2 = EDispPettern.FULL;
                    break;
                default:
                    break;
            }

        }

        partial void DispCheckBoxChanged(NSObject sender)
        {
            if (DispCheckBox.State == NSCellStateValue.On) {
                config.color29 = EColor29.CHANGE;
                try {
                    config.colorChange = int.Parse(DispCheckText.StringValue);
                }
                catch (InvalidOperationException) {
                    config.colorChange = -1;
                }
                catch (InvalidCastException) {
                    config.colorChange = -1;
                }
            }
            else {
                config.color29 = EColor29.NOCHANGE;
                config.colorChange = -1;
            }

        }

        partial void SubmitClicked(NSObject sender)
        {
            ConfigSave.SaveXml(config);
            rootViewController.config = config;
            DismissViewController(this);
        }

        partial void SettingDetailPlanetTableClicked(NSObject sender)
        {
            if (SettingDetailPlanet.SelectedColumn > 0) {
                Console.WriteLine("row");
            }
        }

        //strongly typed view accessor
        public new SettingsView View
        {
            get
            {
                return (SettingsView)base.View;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;

namespace microcosm
{
    public partial class SettingsViewController : AppKit.NSViewController
    {
        public ConfigData config;
        public SettingData[] settings;

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
            if (config.houseCalc == EHouseCalc.PLACIDUS) {
                HouseRadioGroup.SelectCell(0, 0);
            }
            else if (config.houseCalc == EHouseCalc.KOCH) {
                HouseRadioGroup.SelectCell(1, 0);
            }
            else if (config.houseCalc == EHouseCalc.CAMPANUS)
            {
                HouseRadioGroup.SelectCell(2, 0);
            }
            else if (config.houseCalc == EHouseCalc.EQUAL)
            {
                HouseRadioGroup.SelectCell(3, 0);
            }
            else if (config.houseCalc == EHouseCalc.PORPHYRY)
            {
                HouseRadioGroup.SelectCell(4, 0);
            }
            else if (config.houseCalc == EHouseCalc.REGIOMONTANUS)
            {
                HouseRadioGroup.SelectCell(5, 0);
            }
            else if (config.houseCalc == EHouseCalc.SOLAR)
            {
                HouseRadioGroup.SelectCell(6, 0);
            }
            else if (config.houseCalc == EHouseCalc.SOLARSIGN)
            {
                HouseRadioGroup.SelectCell(7, 0);
            }
            else 
            {
                HouseRadioGroup.SelectCell(0, 0);
            }
        }

        partial void SettingChanged(NSObject sender)
        {

        }

        partial void HouseChanged(NSObject sender)
        {
            nint row = HouseRadioGroup.SelectedRow;
            switch (row) {
                case 1:
                    config.houseCalc = EHouseCalc.PLACIDUS;
                    break;
                case 2:
                    config.houseCalc = EHouseCalc.KOCH;
                    break;
                case 3:
                    config.houseCalc = EHouseCalc.CAMPANUS;
                    break;
                case 4:
                    config.houseCalc = EHouseCalc.EQUAL;
                    break;
                case 5:
                    config.houseCalc = EHouseCalc.PORPHYRY;
                    break;
                case 6:
                    config.houseCalc = EHouseCalc.REGIOMONTANUS;
                    break;
                case 7:
                    config.houseCalc = EHouseCalc.SOLAR;
                    break;
                case 8:
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
                    config.centric = ESideReal.TROPICAL;
                    break;
                case 2:
                    config.centric = ESideReal.SIDEREAL;
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
                    config.dispPatern2 = EDecimalDisp.MINI;
                    break;
                case 2:
                    config.dispPatern2 = EDecimalDisp.FULL;
                    break;
                default:
                    break;
            }

        }

        partial void DispCheckBoxChanged(NSObject sender)
        {
            if (DispCheckBox.IsChecked == true) {
                config.colorChange = EColor29.CHANGE;
                config.color29 = DispCheckText.stringValue;
            }
            else {
                config.colorChange = EColor29.NOCHANGE;
                config.color29 = -1;
            }

        }

        partial void SubmitClicked(NSObject sender)
        {

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

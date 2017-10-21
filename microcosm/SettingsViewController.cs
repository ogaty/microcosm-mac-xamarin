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
            else 
            {
                HouseRadioGroup.SelectCell(0, 0);
            }
        }

        partial void SettingChanged(NSObject sender)
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

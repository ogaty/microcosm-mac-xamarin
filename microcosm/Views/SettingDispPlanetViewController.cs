using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;
using microcosm.Common;

namespace microcosm.Views
{
    public partial class SettingDispPlanetViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;
        private int settingIndex;
        private int planetIndex;

        private ViewController rootViewController;


        #region Constructors

        // Called when created from unmanaged code
        public SettingDispPlanetViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingDispPlanetViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingDispPlanetViewController() : base("SettingDispPlanetView", NSBundle.MainBundle)
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
            settings = rootViewController.settings;
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)RingsCombo.SelectedIndex;

            for (int i = 0; i < 10; i++) {
                NSString obj = new NSString(settings[i].dispName);
                SettingsCombo.Add(obj);
            }

            SettingsCombo.SelectItem(settingIndex);

            if (planetIndex == -1) {
                planetIndex = 0;
                RingsCombo.SelectItem(planetIndex);
            }

            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] == true) {
                dispPlanetSun.State = NSCellStateValue.Off;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] == true)
            {
                dispPlanetMoon.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] == true)
            {
                dispPlanetMercury.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] == true)
            {
                dispPlanetVenus.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] == true)
            {
                dispPlanetMars.State = NSCellStateValue.On;
            }
        }

        //strongly typed view accessor
        public new SettingDispPlanetView View
        {
            get
            {
                return (SettingDispPlanetView)base.View;
            }
        }
    }
}

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

            SettingsCombo.RemoveAllItems();
            for (int i = 0; i < 10; i++) {
                NSString obj = new NSString(settings[i].dispName);
                SettingsCombo.AddItem(obj);
            }

            SettingsCombo.SelectItem(settingIndex);

            if (planetIndex == -1) {
                planetIndex = 0;
                RingsCombo.SelectItem(planetIndex);
            }

            ReRender();
        }

        private void ReRender() 
        {
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)RingsCombo.SelectedIndex;

            dispPlanetSun.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMoon.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

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
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] == true)
            {
                dispPlanetJupiter.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] == true)
            {
                dispPlanetSaturn.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] == true)
            {
                dispPlanetUranus.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] == true)
            {
                dispPlanetNeptune.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] == true)
            {
                dispPlanetPluto.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] == true)
            {
                dispPlanetChiron.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] == true)
            {
                dispPlanetDh.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] == true)
            {
                dispPlanetEarth.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] == true)
            {
                dispPlanetLilith.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] == true)
            {
                dispPlanetCeres.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] == true)
            {
                dispPlanetParas.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] == true)
            {
                dispPlanetJuno.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] == true)
            {
                dispPlanetVesta.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] == true)
            {
                dispPlanetEris.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] == true)
            {
                dispPlanetSedna.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] == true)
            {
                dispPlanetHaumea.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] == true)
            {
                dispPlanetMakemake.State = NSCellStateValue.On;
            }
        }

        partial void ringsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void settingsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void SubmitClicked(NSObject sender)
        {
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)RingsCombo.SelectedIndex;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                dispPlanetSun.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                dispPlanetMoon.State == NSCellStateValue.On ? true : false;

            if (settingIndex == CommonInstance.getInstance().currentSettingIndex)
            {
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                    dispPlanetSun.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                    dispPlanetMoon.State == NSCellStateValue.On ? true : false;
            }

            SettingSave.SaveXml(settings);

            DismissViewController(this);
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

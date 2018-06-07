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

            dispPlanetMercury.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVenus.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMars.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetJupiter.State =
                 settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetSaturn.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetUranus.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetNeptune.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetPluto.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetAsc.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMc.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetChiron.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetDh.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetEarth.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetLilith.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetCeres.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetParas.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetJuno.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVesta.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetEris.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetSedna.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetHaumea.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMakemake.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVt.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetPof.State =
                settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] ?
                NSCellStateValue.On : NSCellStateValue.Off;

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
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                dispPlanetMercury.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                dispPlanetVenus.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                dispPlanetMars.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                dispPlanetJupiter.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                dispPlanetSaturn.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                dispPlanetUranus.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                dispPlanetNeptune.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                dispPlanetPluto.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                dispPlanetAsc.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                dispPlanetMc.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                dispPlanetChiron.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                dispPlanetDh.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                dispPlanetEarth.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                dispPlanetLilith.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                dispPlanetCeres.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                dispPlanetParas.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                dispPlanetJuno.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                dispPlanetVesta.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                dispPlanetEris.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                dispPlanetSedna.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                dispPlanetHaumea.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                dispPlanetMakemake.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                dispPlanetVt.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                dispPlanetPof.State == NSCellStateValue.On ? true : false;

            if (settingIndex == CommonInstance.getInstance().currentSettingIndex)
            {
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                    dispPlanetSun.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                    dispPlanetMoon.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                    dispPlanetMercury.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                    dispPlanetVenus.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                    dispPlanetMars.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                    dispPlanetJupiter.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                    dispPlanetSaturn.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                    dispPlanetUranus.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                    dispPlanetNeptune.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                    dispPlanetPluto.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                    dispPlanetAsc.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                    dispPlanetMc.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                    dispPlanetChiron.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                    dispPlanetDh.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                    dispPlanetEarth.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                    dispPlanetLilith.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                    dispPlanetCeres.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                    dispPlanetParas.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                    dispPlanetJuno.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                    dispPlanetVesta.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                    dispPlanetEris.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                    dispPlanetSedna.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                    dispPlanetHaumea.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                    dispPlanetMakemake.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                    dispPlanetVt.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                    dispPlanetPof.State == NSCellStateValue.On ? true : false;
            }

            SettingSave.SaveXml(settings);

            CommonInstance.getInstance().controller.ReRender();
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

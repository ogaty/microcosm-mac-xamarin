using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;
using microcosm.Common;

namespace microcosm.Views
{
    public partial class SettingDispAspectPlanetViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;
        private int settingIndex;
        private int planetIndex;

        private ViewController rootViewController;

        #region Constructors

        // Called when created from unmanaged code
        public SettingDispAspectPlanetViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingDispAspectPlanetViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingDispAspectPlanetViewController() : base("SettingDispAspectPlanetView", NSBundle.MainBundle)
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


            rootViewController = (ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController;

            config = rootViewController.config;
            settings = rootViewController.settings;
            settingIndex = rootViewController.settingIndex;
            if (RingsCombo == null) 
            {
                planetIndex = 0;
            }
            else {
                planetIndex = (int)RingsCombo.IndexOfSelectedItem;
            }

            SettingsCombo.RemoveAllItems();
            for (int i = 0; i < 10; i++)
            {
                NSString obj = new NSString(settings[i].dispName);
                SettingsCombo.AddItem(obj);
            }

            SettingsCombo.SelectItem(settingIndex);

            RingsCombo.SelectItem(planetIndex);

            ReRender();

        }

        public void ReRender()
        {
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] == true)
            {
                dispAspectPlanetSun.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] == true)
            {
                dispAspectPlanetMoon.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] == true)
            {
                dispAspectPlanetMercury.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] == true)
            {
                dispAspectPlanetVenus.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] == true)
            {
                dispAspectPlanetMars.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] == true)
            {
                dispAspectPlanetJupiter.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] == true)
            {
                dispAspectPlanetSaturn.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] == true)
            {
                dispAspectPlanetUranus.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] == true)
            {
                dispAspectPlanetNeptune.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] == true)
            {
                dispAspectPlanetPluto.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] == true)
            {
                dispAspectPlanetAsc.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] == true)
            {
                dispAspectPlanetMc.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] == true)
            {
                dispAspectPlanetChiron.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] == true)
            {
                dispAspectPlanetEarth.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] == true)
            {
                dispAspectPlanetLilith.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] == true)
            {
                dispAspectPlanetLilith.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] == true)
            {
                dispAspectPlanetVt.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] == true)
            {
                dispAspectPlanetPof.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] == true)
            {
                dispAspectPlanetCeres.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PARAS] == true)
            {
                dispAspectPlanetParas.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] == true)
            {
                dispAspectPlanetJuno.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] == true)
            {
                dispAspectPlanetVesta.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] == true)
            {
                dispAspectPlanetSedna.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] == true)
            {
                dispAspectPlanetEris.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] == true)
            {
                dispAspectPlanetHaumea.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] == true)
            {
                dispAspectPlanetMakemake.State = NSCellStateValue.On;
            }

        }

        partial void SettingsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void RingsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void SubmitButtonClicked(NSObject sender)
        {

        }


        //strongly typed view accessor
        public new SettingDispAspectPlanetView View
        {
            get
            {
                return (SettingDispAspectPlanetView)base.View;
            }
        }
    }
}

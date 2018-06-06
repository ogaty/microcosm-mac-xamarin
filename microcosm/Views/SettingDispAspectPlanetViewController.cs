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
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)RingsCombo.IndexOfSelectedItem;
            dispAspectPlanetSun.State = 
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMoon.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMercury.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetVenus.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMars.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetJupiter.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetSaturn.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetUranus.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetNeptune.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPluto.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetAsc.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMc.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetChiron.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetEarth.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetLilith.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetDh.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

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
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)RingsCombo.IndexOfSelectedItem;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] = 
                dispAspectPlanetSun.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                dispAspectPlanetMoon.State == NSCellStateValue.On ? true : false;

            SettingSave.SaveXml(settings);
            DismissViewController(this);
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

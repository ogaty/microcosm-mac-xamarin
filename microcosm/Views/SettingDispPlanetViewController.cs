using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;
using microcosm.Common;
using microcosm.Models;

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

            List<SettingNameList> lists = new List<SettingNameList>();
            foreach (SettingData s in settings)
            {
                lists.Add(new SettingNameList(s.dispName));
            }
            SettingNameDataSource dataSource = new SettingNameDataSource(lists);
            SettingNameDelegate settingNamesDelegate = new SettingNameDelegate(dataSource);
            settingListTbl.vc = this;
            settingListTbl.Delegate = settingNamesDelegate;
            settingListTbl.DataSource = dataSource;
            settingListTbl.ReloadData();
            settingListTbl.SelectRow(settingIndex, false);

            ReRender(settingIndex);
        }

        public void ReRender(int settingIndex) 
        {
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;

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
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] ?
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
            
            dispAspectPlanetVt.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPof.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetCeres.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPallas.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetJuno.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetVesta.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetEris.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetSedna.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetHaumea.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMakemake.State =
                settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            int aspectIndex = (int)aspectRingCombo.IndexOfSelectedItem;
            int from = 0;
            int to = 0;

            GetFromTo(aspectIndex, ref from, ref to);

            aspectConjunction.State =
                                 settings[settingIndex].aspectConjunction[from, to] ?
                                 NSCellStateValue.On : NSCellStateValue.Off;
            aspectOpposition.State =
                                 settings[settingIndex].aspectOpposition[from, to] ?
                                 NSCellStateValue.On : NSCellStateValue.Off;
            aspectTrine.State =
                                  settings[settingIndex].aspectTrine[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSquare.State =
                                  settings[settingIndex].aspectSquare[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSextile.State =
                                  settings[settingIndex].aspectSextile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectInconjunct.State =
                                  settings[settingIndex].aspectInconjunct[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSesquiquadrate.State =
                                  settings[settingIndex].aspectSesquiquadrate[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiSquare.State =
                                  settings[settingIndex].aspectSemiSquare[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiSextile.State =
                                  settings[settingIndex].aspectSemiSextile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiQuintile.State =
                                  settings[settingIndex].aspectSemiQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectNovile.State =
                                  settings[settingIndex].aspectNovile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSeptile.State =
                                  settings[settingIndex].aspectSeptile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectQuintile.State =
                                  settings[settingIndex].aspectQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectBiQuintile.State =
                                  settings[settingIndex].aspectBiQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
         }

        partial void ringsComboChanged(NSObject sender)
        {
            ReRender(rootViewController.settingIndex);
        }

        partial void settingsComboChanged(NSObject sender)
        {
            ReRender(rootViewController.settingIndex);
        }

        partial void SubmitClicked(NSObject sender)
        {
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;

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
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                dispAspectPlanetSun.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                dispAspectPlanetMoon.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                dispAspectPlanetMercury.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                dispAspectPlanetVenus.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                dispAspectPlanetMars.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                dispAspectPlanetJupiter.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                dispAspectPlanetSaturn.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                dispAspectPlanetUranus.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                dispAspectPlanetNeptune.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                dispAspectPlanetPluto.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                dispAspectPlanetChiron.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                dispAspectPlanetEarth.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                dispAspectPlanetLilith.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                dispAspectPlanetDh.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                dispAspectPlanetVt.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                dispAspectPlanetPof.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                dispAspectPlanetCeres.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                dispAspectPlanetPallas.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                dispAspectPlanetJuno.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                dispAspectPlanetVesta.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                dispAspectPlanetEris.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                dispAspectPlanetSedna.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                dispAspectPlanetHaumea.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                dispAspectPlanetMakemake.State == NSCellStateValue.On ? true : false;

            int aspectIndex = (int)aspectRingCombo.IndexOfSelectedItem;
            int from = 0;
            int to = 0;

            GetFromTo(aspectIndex, ref from, ref to);

            settings[settingIndex].aspectConjunction[from, to] =
                                      aspectConjunction.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectOpposition[from, to] =
                                      aspectOpposition.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectTrine[from, to] =
                                      aspectTrine.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSquare[from, to] =
                                      aspectSquare.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSextile[from, to] =
                                      aspectSextile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectInconjunct[from, to] =
                                      aspectInconjunct.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSesquiquadrate[from, to] =
                                      aspectSesquiquadrate.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSemiSquare[from, to] =
                                      aspectSemiSquare.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSemiQuintile[from, to] =
                                      aspectSemiQuintile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSemiSextile[from, to] =
                                      aspectSemiSextile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectNovile[from, to] =
                                      aspectNovile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectSeptile[from, to] =
                                      aspectSeptile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectQuintile[from, to] =
                                      aspectQuintile.State == NSCellStateValue.On ? true : false;
            settings[settingIndex].aspectBiQuintile[from, to] =
                                      aspectBiQuintile.State == NSCellStateValue.On ? true : false;

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
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                    dispAspectPlanetSun.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                    dispAspectPlanetMoon.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                    dispAspectPlanetMercury.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                    dispAspectPlanetVenus.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                    dispAspectPlanetMars.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                    dispAspectPlanetJupiter.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                    dispAspectPlanetSaturn.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                    dispAspectPlanetUranus.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                    dispAspectPlanetNeptune.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                    dispAspectPlanetPluto.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                    dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                    dispAspectPlanetMc.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                    dispAspectPlanetChiron.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                    dispAspectPlanetEarth.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                    dispAspectPlanetLilith.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                    dispAspectPlanetDh.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                    dispAspectPlanetVt.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                    dispAspectPlanetPof.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                    dispAspectPlanetCeres.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                    dispAspectPlanetPallas.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                    dispAspectPlanetJuno.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                    dispAspectPlanetVesta.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                    dispAspectPlanetEris.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                    dispAspectPlanetSedna.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                    dispAspectPlanetHaumea.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                    dispAspectPlanetMakemake.State == NSCellStateValue.On ? true : false;

                CommonInstance.getInstance().currentSetting.aspectConjunction[from, to] =
                          aspectConjunction.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectOpposition[from, to] =
                          aspectOpposition.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectTrine[from, to] =
                          aspectTrine.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSquare[from, to] =
                          aspectSquare.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSextile[from, to] =
                          aspectSextile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectInconjunct[from, to] =
                          aspectInconjunct.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSesquiquadrate[from, to] =
                          aspectSesquiquadrate.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSemiSquare[from, to] =
                          aspectSemiSquare.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSemiSextile[from, to] =
                          aspectSemiSextile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSemiQuintile[from, to] =
                          aspectSemiQuintile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectNovile[from, to] =
                          aspectNovile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectSeptile[from, to] =
                          aspectSeptile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectQuintile[from, to] =
                          aspectQuintile.State == NSCellStateValue.On ? true : false;
                CommonInstance.getInstance().currentSetting.aspectBiQuintile[from, to] =
                          aspectBiQuintile.State == NSCellStateValue.On ? true : false;

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

        public void GetFromTo(int aspectIndex, ref int from, ref int to)
        {
            switch (aspectIndex)
            {
                case 0:
                    from = 0;
                    to = 0;
                    break;
                case 1:
                    from = 1;
                    to = 1;
                    break;
                case 2:
                    from = 2;
                    to = 2;
                    break;
                case 3:
                    from = 0;
                    to = 1;
                    break;
                case 4:
                    from = 0;
                    to = 2;
                    break;
                case 5:
                    from = 1;
                    to = 2;
                    break;
                case 6:
                    from = 3;
                    to = 3;
                    break;
                case 7:
                    from = 4;
                    to = 4;
                    break;
                case 8:
                    from = 0;
                    to = 3;
                    break;
                case 9:
                    from = 1;
                    to = 3;
                    break;
                case 10:
                    from = 2;
                    to = 3;
                    break;
                case 11:
                    from = 0;
                    to = 4;
                    break;
                case 12:
                    from = 1;
                    to = 4;
                    break;
                case 13:
                    from = 2;
                    to = 4;
                    break;
                case 14:
                    from = 3;
                    to = 4;
                    break;
            }
        }
    }
}

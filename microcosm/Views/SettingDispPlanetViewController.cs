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
        private SettingData[] tempIndex;
        private int settingIndex;
        private int planetIndex;
        private int settingListIndex = 0;

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
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;


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

            tempIndex = new SettingData[10];
            for (int i = 0; i < 10; i++) {
                tempIndex[i] = settings[i];
            }
            ReRender(settingIndex);
        }

        public void ReRender(int settingIndex) 
        {
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;

            dispPlanetSun.State =
                             tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMoon.State =
                              tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMercury.State =
                                 tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVenus.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMars.State =
                              tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetJupiter.State =
                                 tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetSaturn.State =
                                tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetUranus.State =
                                tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetNeptune.State =
                                 tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetPluto.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetAsc.State =
                             tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMc.State =
                            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetChiron.State =
                                tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetDh.State =
                            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetEarth.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetLilith.State =
                                tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetCeres.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetParas.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetJuno.State =
                              tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVesta.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetEris.State =
                              tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetSedna.State =
                               tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetHaumea.State =
                                tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetMakemake.State =
                                  tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetVt.State =
                            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispPlanetPof.State =
                             tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetSun.State =
                                   tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMoon.State =
                                    tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMercury.State =
                                       tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetVenus.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMars.State =
                                    tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetJupiter.State =
                                       tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetSaturn.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetUranus.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetNeptune.State =
                                       tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPluto.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetAsc.State =
                                   tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMc.State =
                                  tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetChiron.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] ?
                NSCellStateValue.On : NSCellStateValue.Off;
            
            dispAspectPlanetEarth.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetLilith.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetDh.State =
                                  tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] ?
                NSCellStateValue.On : NSCellStateValue.Off;
            
            dispAspectPlanetVt.State =
                                  tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPof.State =
                                   tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetCeres.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetPallas.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetJuno.State =
                                    tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetVesta.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetEris.State =
                                    tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetSedna.State =
                                     tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetHaumea.State =
                                      tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            dispAspectPlanetMakemake.State =
                                        tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] ?
                NSCellStateValue.On : NSCellStateValue.Off;

            int aspectIndex = (int)aspectRingCombo.IndexOfSelectedItem;
            int from = 0;
            int to = 0;

            GetFromTo(aspectIndex, ref from, ref to);

            aspectConjunction.State =
                                 tempIndex[settingIndex].aspectConjunction[from, to] ?
                                 NSCellStateValue.On : NSCellStateValue.Off;
            aspectOpposition.State =
                                tempIndex[settingIndex].aspectOpposition[from, to] ?
                                 NSCellStateValue.On : NSCellStateValue.Off;
            aspectTrine.State =
                           tempIndex[settingIndex].aspectTrine[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSquare.State =
                            tempIndex[settingIndex].aspectSquare[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSextile.State =
                             tempIndex[settingIndex].aspectSextile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectInconjunct.State =
                                tempIndex[settingIndex].aspectInconjunct[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSesquiquadrate.State =
                                    tempIndex[settingIndex].aspectSesquiquadrate[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiSquare.State =
                                tempIndex[settingIndex].aspectSemiSquare[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiSextile.State =
                                 tempIndex[settingIndex].aspectSemiSextile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSemiQuintile.State =
                                  tempIndex[settingIndex].aspectSemiQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectNovile.State =
                            tempIndex[settingIndex].aspectNovile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectSeptile.State =
                             tempIndex[settingIndex].aspectSeptile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectQuintile.State =
                              tempIndex[settingIndex].aspectQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;
            aspectBiQuintile.State =
                                tempIndex[settingIndex].aspectBiQuintile[from, to] ?
                                  NSCellStateValue.On : NSCellStateValue.Off;

            OrbSunSoft1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_1ST].ToString();
            OrbSunHard1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_1ST].ToString();
            OrbMoonSoft1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_1ST].ToString();
            OrbMoonHard1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_1ST].ToString();
            OrbOtherSoft1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_SOFT_1ST].ToString();
            OrbOtherHard1st.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_HARD_1ST].ToString();
            OrbSunSoft2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_2ND].ToString();
            OrbSunHard2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_2ND].ToString();
            OrbMoonSoft2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_2ND].ToString();
            OrbMoonHard2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_2ND].ToString();
            OrbOtherSoft2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_SOFT_2ND].ToString();
            OrbOtherHard2nd.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_HARD_2ND].ToString();
            OrbSunSoft150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_150].ToString();
            OrbSunHard150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_150].ToString();
            OrbMoonSoft150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_150].ToString();
            OrbMoonHard150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_150].ToString();
            OrbOtherSoft150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_SOFT_150].ToString();
            OrbOtherHard150.StringValue = tempIndex[settingIndex].orbs[0][OrbKind.OTHER_HARD_150].ToString();

            
            if (lineRingCombo.IndexOfSelectedItem == 0) {
                dispAspect11.State = tempIndex[settingIndex].dispAspect2[0, 0] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect12.State = tempIndex[settingIndex].dispAspect2[0, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect13.State = tempIndex[settingIndex].dispAspect2[0, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect14.State = tempIndex[settingIndex].dispAspect2[0, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect15.State = tempIndex[settingIndex].dispAspect2[0, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect22.State = tempIndex[settingIndex].dispAspect2[1, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect23.State = tempIndex[settingIndex].dispAspect2[1, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect24.State = tempIndex[settingIndex].dispAspect2[1, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect25.State = tempIndex[settingIndex].dispAspect2[1, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect33.State = tempIndex[settingIndex].dispAspect2[2, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect34.State = tempIndex[settingIndex].dispAspect2[2, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect35.State = tempIndex[settingIndex].dispAspect2[2, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect44.State = tempIndex[settingIndex].dispAspect2[3, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect45.State = tempIndex[settingIndex].dispAspect2[3, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect55.State = tempIndex[settingIndex].dispAspect2[4, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
            } 
            else if (lineRingCombo.IndexOfSelectedItem == 1)
            {
                dispAspect11.State = tempIndex[settingIndex].dispAspect3[0, 0] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect12.State = tempIndex[settingIndex].dispAspect3[0, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect13.State = tempIndex[settingIndex].dispAspect3[0, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect14.State = tempIndex[settingIndex].dispAspect3[0, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect15.State = tempIndex[settingIndex].dispAspect3[0, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect22.State = tempIndex[settingIndex].dispAspect3[1, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect23.State = tempIndex[settingIndex].dispAspect3[1, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect24.State = tempIndex[settingIndex].dispAspect3[1, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect25.State = tempIndex[settingIndex].dispAspect3[1, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect33.State = tempIndex[settingIndex].dispAspect3[2, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect34.State = tempIndex[settingIndex].dispAspect3[2, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect35.State = tempIndex[settingIndex].dispAspect3[2, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect44.State = tempIndex[settingIndex].dispAspect3[3, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect45.State = tempIndex[settingIndex].dispAspect3[3, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect55.State = tempIndex[settingIndex].dispAspect3[4, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 2)
            {
                dispAspect11.State = tempIndex[settingIndex].dispAspect4[0, 0] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect12.State = tempIndex[settingIndex].dispAspect4[0, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect13.State = tempIndex[settingIndex].dispAspect4[0, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect14.State = tempIndex[settingIndex].dispAspect4[0, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect15.State = tempIndex[settingIndex].dispAspect4[0, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect22.State = tempIndex[settingIndex].dispAspect4[1, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect23.State = tempIndex[settingIndex].dispAspect4[1, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect24.State = tempIndex[settingIndex].dispAspect4[1, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect25.State = tempIndex[settingIndex].dispAspect4[1, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect33.State = tempIndex[settingIndex].dispAspect4[2, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect34.State = tempIndex[settingIndex].dispAspect4[2, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect35.State = tempIndex[settingIndex].dispAspect4[2, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect44.State = tempIndex[settingIndex].dispAspect4[3, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect45.State = tempIndex[settingIndex].dispAspect4[3, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect55.State = tempIndex[settingIndex].dispAspect4[4, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 3)
            {
                dispAspect11.State = tempIndex[settingIndex].dispAspect5[0, 0] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect12.State = tempIndex[settingIndex].dispAspect5[0, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect13.State = tempIndex[settingIndex].dispAspect5[0, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect14.State = tempIndex[settingIndex].dispAspect5[0, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect15.State = tempIndex[settingIndex].dispAspect5[0, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect22.State = tempIndex[settingIndex].dispAspect5[1, 1] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect23.State = tempIndex[settingIndex].dispAspect5[1, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect24.State = tempIndex[settingIndex].dispAspect5[1, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect25.State = tempIndex[settingIndex].dispAspect5[1, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect33.State = tempIndex[settingIndex].dispAspect5[2, 2] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect34.State = tempIndex[settingIndex].dispAspect5[2, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect35.State = tempIndex[settingIndex].dispAspect5[2, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect44.State = tempIndex[settingIndex].dispAspect5[3, 3] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect45.State = tempIndex[settingIndex].dispAspect5[3, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
                dispAspect55.State = tempIndex[settingIndex].dispAspect5[4, 4] ?
                    NSCellStateValue.On : NSCellStateValue.Off;
            }

         }

        partial void planetRingComboChanged(NSObject sender)
        {
            ReRender(rootViewController.settingIndex);
        }

        partial void aspectRingComboChanged(NSObject sender)
        {
            ReRender(rootViewController.settingIndex);
        }

        partial void lineRingComboChanged(NSObject sender)
        {
            ReRender(rootViewController.settingIndex);
        }

        // これsettingIndexに限らずplanetIndex変更時もいれたほうがいいね
        public void TempSave(int settingIndex)
        {
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] = dispPlanetSun.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] = dispPlanetMoon.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] = dispPlanetMercury.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] = dispPlanetVenus.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] = dispPlanetMars.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] = dispPlanetJupiter.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] = dispPlanetSaturn.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] = dispPlanetUranus.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] = dispPlanetNeptune.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] = dispPlanetPluto.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] = dispPlanetAsc.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] = dispPlanetMc.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] = dispPlanetChiron.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] = dispPlanetDh.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] = dispPlanetEarth.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] = dispPlanetLilith.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] = dispPlanetCeres.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] = dispPlanetParas.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] = dispPlanetJuno.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] = dispPlanetVesta.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] = dispPlanetVt.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] = dispPlanetPof.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] = dispPlanetEris.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] = dispPlanetSedna.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] = dispPlanetHaumea.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] = dispPlanetMakemake.State == NSCellStateValue.On ? true : false;

            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] = dispAspectPlanetSun.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] = dispAspectPlanetMoon.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] = dispAspectPlanetMercury.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] = dispAspectPlanetVenus.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] = dispAspectPlanetMars.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] = dispAspectPlanetJupiter.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] = dispAspectPlanetSaturn.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] = dispAspectPlanetUranus.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] = dispAspectPlanetNeptune.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] = dispAspectPlanetPluto.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] = dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] = dispAspectPlanetMc.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] = dispAspectPlanetChiron.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] = dispAspectPlanetDh.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] = dispAspectPlanetEarth.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] = dispAspectPlanetLilith.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] = dispAspectPlanetCeres.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] = dispAspectPlanetPallas.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] = dispAspectPlanetJuno.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] = dispAspectPlanetVesta.State == NSCellStateValue.On ? true : false;

            int aspectIndex = (int)aspectRingCombo.IndexOfSelectedItem;
            int from = 0;
            int to = 0;

            GetFromTo(aspectIndex, ref from, ref to);

            tempIndex[settingIndex].aspectConjunction[from, to] = aspectConjunction.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectOpposition[from, to] = aspectOpposition.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectTrine[from, to] = aspectTrine.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSquare[from, to] = aspectSquare.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSextile[from, to] = aspectSextile.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectInconjunct[from, to] = aspectInconjunct.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSesquiquadrate[from, to] = aspectSesquiquadrate.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSemiSquare[from, to] = aspectSemiSquare.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSemiSextile[from, to] = aspectSemiSextile.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectSemiQuintile[from, to] = aspectSemiQuintile.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectNovile[from, to] = aspectNovile.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectQuintile[from, to] = aspectQuintile.State == NSCellStateValue.On ? true : false;
            tempIndex[settingIndex].aspectBiQuintile[from, to] = aspectBiQuintile.State == NSCellStateValue.On ? true : false;

            if (lineRingCombo.IndexOfSelectedItem == 0)
            {
                tempIndex[settingIndex].dispAspect2[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect2[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 1)
            {
                tempIndex[settingIndex].dispAspect3[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect3[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 2)
            {
                tempIndex[settingIndex].dispAspect4[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect4[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 3)
            {
                tempIndex[settingIndex].dispAspect5[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                tempIndex[settingIndex].dispAspect5[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }

            tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_1ST] = double.Parse(OrbSunSoft1st.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_1ST] = double.Parse(OrbSunHard1st.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_2ND] = double.Parse(OrbSunSoft2nd.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_2ND] = double.Parse(OrbSunHard2nd.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.SUN_SOFT_150] = double.Parse(OrbSunSoft150.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.SUN_HARD_150] = double.Parse(OrbSunHard150.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_1ST] = double.Parse(OrbMoonSoft1st.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_1ST] = double.Parse(OrbMoonHard1st.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_2ND] = double.Parse(OrbMoonSoft2nd.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_2ND] = double.Parse(OrbMoonHard2nd.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_SOFT_150] = double.Parse(OrbMoonSoft150.StringValue);
            tempIndex[settingIndex].orbs[0][OrbKind.MOON_HARD_150] = double.Parse(OrbMoonHard150.StringValue);
            
        }

        partial void SubmitClicked(NSObject sender)
        {
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)planetRingCombo.IndexOfSelectedItem;
            settingListIndex = (int)settingListTbl.SelectedRow;

            for (int i = 0; i < 10; i++) {
                if (i == settingListIndex) continue;
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                    tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT];
                settings[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                                          tempIndex[i].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE];
                settings[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                                          tempIndex[i].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO];

            }

            settings[settingListIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                                          dispPlanetSun.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                                          dispPlanetMoon.State == NSCellStateValue.On ? true : false;

            // TODO

            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SUN] =
                dispAspectPlanetSun.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MOON] =
                dispAspectPlanetMoon.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MERCURY] =
                dispAspectPlanetMercury.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VENUS] =
                dispAspectPlanetVenus.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MARS] =
                dispAspectPlanetMars.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUPITER] =
                dispAspectPlanetJupiter.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SATURN] =
                dispAspectPlanetSaturn.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_URANUS] =
                dispAspectPlanetUranus.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_NEPTUNE] =
                dispAspectPlanetNeptune.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PLUTO] =
                dispAspectPlanetPluto.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ASC] =
                dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MC] =
                dispAspectPlanetAsc.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CHIRON] =
                dispAspectPlanetChiron.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_EARTH] =
                dispAspectPlanetEarth.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_LILITH] =
                dispAspectPlanetLilith.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_DH_TRUENODE] =
                dispAspectPlanetDh.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VT] =
                dispAspectPlanetVt.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_POF] =
                dispAspectPlanetPof.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_CERES] =
                dispAspectPlanetCeres.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_PALLAS] =
                dispAspectPlanetPallas.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_JUNO] =
                dispAspectPlanetJuno.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_VESTA] =
                dispAspectPlanetVesta.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_ERIS] =
                dispAspectPlanetEris.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_SEDNA] =
                dispAspectPlanetSedna.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_HAUMEA] =
                dispAspectPlanetHaumea.State == NSCellStateValue.On ? true : false;
            settings[settingListIndex].dispAspectPlanet[planetIndex][CommonData.ZODIAC_NUMBER_MAKEMAKE] =
                dispAspectPlanetMakemake.State == NSCellStateValue.On ? true : false;

            /*

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


            if (lineRingCombo.IndexOfSelectedItem == 0)
            {
                settings[settingIndex].dispAspect2[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect2[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 1)
            {
                settings[settingIndex].dispAspect3[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect3[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 2)
            {
                settings[settingIndex].dispAspect4[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect4[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }
            else if (lineRingCombo.IndexOfSelectedItem == 3)
            {
                settings[settingIndex].dispAspect5[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                settings[settingIndex].dispAspect5[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
            }

            settings[settingIndex].orbs[0][OrbKind.SUN_SOFT_1ST] = double.Parse(OrbSunSoft1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.SUN_HARD_1ST] = double.Parse(OrbSunHard1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_SOFT_1ST] = double.Parse(OrbMoonSoft1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_HARD_1ST] = double.Parse(OrbMoonHard1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_SOFT_1ST] = double.Parse(OrbOtherSoft1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_HARD_1ST] = double.Parse(OrbOtherHard1st.StringValue);
            settings[settingIndex].orbs[0][OrbKind.SUN_SOFT_2ND] = double.Parse(OrbSunSoft2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.SUN_HARD_2ND] = double.Parse(OrbSunHard2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_SOFT_2ND] = double.Parse(OrbMoonSoft2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_HARD_2ND] = double.Parse(OrbMoonHard2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_SOFT_2ND] = double.Parse(OrbOtherSoft2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_HARD_2ND] = double.Parse(OrbOtherHard2nd.StringValue);
            settings[settingIndex].orbs[0][OrbKind.SUN_SOFT_150] = double.Parse(OrbSunSoft150.StringValue);
            settings[settingIndex].orbs[0][OrbKind.SUN_HARD_150] = double.Parse(OrbSunHard150.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_SOFT_150] = double.Parse(OrbMoonSoft150.StringValue);
            settings[settingIndex].orbs[0][OrbKind.MOON_HARD_150] = double.Parse(OrbMoonHard150.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_SOFT_150] = double.Parse(OrbOtherSoft150.StringValue);
            settings[settingIndex].orbs[0][OrbKind.OTHER_HARD_150] = double.Parse(OrbOtherHard150.StringValue);
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

                if (lineRingCombo.IndexOfSelectedItem == 0)
                {
                    CommonInstance.getInstance().currentSetting.dispAspect2[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect2[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
                }
                else if (lineRingCombo.IndexOfSelectedItem == 1)
                {
                    CommonInstance.getInstance().currentSetting.dispAspect3[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect3[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
                }
                else if (lineRingCombo.IndexOfSelectedItem == 2)
                {
                    CommonInstance.getInstance().currentSetting.dispAspect4[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect4[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
                }
                else if (lineRingCombo.IndexOfSelectedItem == 3)
                {
                    CommonInstance.getInstance().currentSetting.dispAspect5[0, 0] = dispAspect11.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[0, 1] = dispAspect12.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[0, 2] = dispAspect13.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[0, 3] = dispAspect14.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[0, 4] = dispAspect15.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[1, 1] = dispAspect22.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[1, 2] = dispAspect23.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[1, 3] = dispAspect24.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[1, 4] = dispAspect25.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[2, 2] = dispAspect33.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[2, 3] = dispAspect34.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[2, 4] = dispAspect35.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[3, 3] = dispAspect44.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[3, 4] = dispAspect45.State == NSCellStateValue.On ? true : false;
                    CommonInstance.getInstance().currentSetting.dispAspect5[4, 4] = dispAspect55.State == NSCellStateValue.On ? true : false;
                }

                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_SOFT_1ST] = double.Parse(OrbSunSoft1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_HARD_1ST] = double.Parse(OrbSunHard1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_SOFT_1ST] = double.Parse(OrbMoonSoft1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_HARD_1ST] = double.Parse(OrbMoonHard1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_SOFT_1ST] = double.Parse(OrbOtherSoft1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_HARD_1ST] = double.Parse(OrbOtherHard1st.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_SOFT_2ND] = double.Parse(OrbSunSoft2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_HARD_2ND] = double.Parse(OrbSunHard2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_SOFT_2ND] = double.Parse(OrbMoonSoft2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_HARD_2ND] = double.Parse(OrbMoonHard2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_SOFT_2ND] = double.Parse(OrbOtherSoft2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_HARD_2ND] = double.Parse(OrbOtherHard2nd.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_SOFT_150] = double.Parse(OrbSunSoft150.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.SUN_HARD_150] = double.Parse(OrbSunHard150.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_SOFT_150] = double.Parse(OrbMoonSoft150.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.MOON_HARD_150] = double.Parse(OrbMoonHard150.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_SOFT_150] = double.Parse(OrbOtherSoft150.StringValue);
                CommonInstance.getInstance().currentSetting.orbs[0][OrbKind.OTHER_HARD_150] = double.Parse(OrbOtherHard150.StringValue);
*/

//            }

            SettingSave.SaveXml(settings);
            rootViewController.ReCalc();
            rootViewController.ReRender();

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

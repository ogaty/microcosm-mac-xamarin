using System;
using System.IO;
using System.Xml.Serialization;
using microcosm.Common;

namespace microcosm.Config
{
    public class SettingSave
    {
        /// <summary>
        /// setting配列をXmlに記録
        /// </summary>
        /// <param name="settings">setting一覧</param>
        public static void SaveXml(SettingData[] settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingXml));
            var root = Util.ContainerDirectory + "/Documents/microcosm";

            for (int i = 0; i < 10; i++)
            {
                var cfg = root + "/system/setting" + i.ToString() + ".csm";

                FileStream fs = new FileStream(cfg, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                SettingXml input = ConvertSetting(settings[i]);
                serializer.Serialize(sw, input);
                sw.Dispose();
                fs.Dispose();
            }

        }

        /// <summary>
        /// settingDataをsettingXmlに変換
        /// </summary>
        /// <returns>The setting.</returns>
        /// <param name="setting">Setting.</param>
        public static SettingXml ConvertSetting(SettingData setting)
        {
            SettingXml ret = new SettingXml();
            ret.dispname = setting.dispName;
            ret.version = 2;

            string orbs = "";
            orbs = setting.orbs[0][OrbKind.SUN_SOFT_1ST].ToString();
            ret.orb_sun_soft_1st = orbs;
            orbs = setting.orbs[0][OrbKind.SUN_HARD_1ST].ToString();
            ret.orb_sun_hard_1st = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_SOFT_1ST].ToString();
            ret.orb_moon_soft_1st = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_HARD_1ST].ToString();
            ret.orb_moon_hard_1st = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_SOFT_1ST].ToString();
            ret.orb_other_soft_1st = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_HARD_1ST].ToString();
            ret.orb_other_hard_1st = orbs;
            orbs = setting.orbs[0][OrbKind.SUN_SOFT_2ND].ToString();
            ret.orb_sun_soft_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.SUN_HARD_2ND].ToString();
            ret.orb_sun_hard_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_SOFT_2ND].ToString();
            ret.orb_moon_soft_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_HARD_2ND].ToString();
            ret.orb_moon_hard_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_SOFT_2ND].ToString();
            ret.orb_other_soft_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_HARD_2ND].ToString();
            ret.orb_other_hard_2nd = orbs;
            orbs = setting.orbs[0][OrbKind.SUN_SOFT_150].ToString();
            ret.orb_sun_soft_150 = orbs;
            orbs = setting.orbs[0][OrbKind.SUN_HARD_150].ToString();
            ret.orb_sun_hard_150 = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_SOFT_150].ToString();
            ret.orb_moon_soft_150 = orbs;
            orbs = setting.orbs[0][OrbKind.MOON_HARD_150].ToString();
            ret.orb_moon_hard_150 = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_SOFT_150].ToString();
            ret.orb_other_soft_150 = orbs;
            orbs = setting.orbs[0][OrbKind.OTHER_HARD_150].ToString();
            ret.orb_other_hard_150 = orbs;

            ret.dispPlanetSun11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_SUN];
            ret.dispPlanetSun22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_SUN];
            ret.dispPlanetSun33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_SUN];
            ret.dispPlanetSun44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_SUN];
            ret.dispPlanetSun55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_SUN];

            ret.dispPlanetMoon11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_MOON];
            ret.dispPlanetMoon22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_MOON];
            ret.dispPlanetMoon33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_MOON];
            ret.dispPlanetMoon44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_MOON];
            ret.dispPlanetMoon55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_MOON];

            ret.dispPlanetMercury11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.dispPlanetMercury22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.dispPlanetMercury33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.dispPlanetMercury44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.dispPlanetMercury55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_MERCURY];

            ret.dispPlanetVenus11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_VENUS];
            ret.dispPlanetVenus22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_VENUS];
            ret.dispPlanetVenus33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_VENUS];
            ret.dispPlanetVenus44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_VENUS];
            ret.dispPlanetVenus55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_VENUS];

            ret.dispPlanetMars11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_MARS];
            ret.dispPlanetMars22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_MARS];
            ret.dispPlanetMars33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_MARS];
            ret.dispPlanetMars44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_MARS];
            ret.dispPlanetMars55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_MARS];

            ret.dispPlanetJupiter11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.dispPlanetJupiter22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.dispPlanetJupiter33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.dispPlanetJupiter44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.dispPlanetJupiter55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_JUPITER];

            ret.dispPlanetSaturn11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_SATURN];
            ret.dispPlanetSaturn22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_SATURN];
            ret.dispPlanetSaturn33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_SATURN];
            ret.dispPlanetSaturn44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_SATURN];
            ret.dispPlanetSaturn55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_SATURN];

            ret.dispPlanetUranus11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_URANUS];
            ret.dispPlanetUranus22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_URANUS];
            ret.dispPlanetUranus33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_URANUS];
            ret.dispPlanetUranus44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_URANUS];
            ret.dispPlanetUranus55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_URANUS];

            ret.dispPlanetNeptune11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.dispPlanetNeptune22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.dispPlanetNeptune33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.dispPlanetNeptune44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.dispPlanetNeptune55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_NEPTUNE];

            ret.dispPlanetPluto11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.dispPlanetPluto22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.dispPlanetPluto33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.dispPlanetPluto44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.dispPlanetPluto55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_PLUTO];

            ret.dispPlanetAsc11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_ASC];
            ret.dispPlanetAsc22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_ASC];
            ret.dispPlanetAsc33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_ASC];
            ret.dispPlanetAsc44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_ASC];
            ret.dispPlanetAsc55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_ASC];

            ret.dispPlanetMc11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_MC];
            ret.dispPlanetMc22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_MC];
            ret.dispPlanetMc33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_MC];
            ret.dispPlanetMc44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_MC];
            ret.dispPlanetMc55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_MC];

            ret.dispPlanetChiron11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.dispPlanetChiron22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.dispPlanetChiron33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.dispPlanetChiron44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.dispPlanetChiron55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_CHIRON];

            ret.dispPlanetDh11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.dispPlanetDh22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.dispPlanetDh33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.dispPlanetDh44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.dispPlanetDh55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_DH_TRUENODE];

            ret.dispPlanetLilith11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_LILITH];
            ret.dispPlanetLilith22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_LILITH];
            ret.dispPlanetLilith33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_LILITH];
            ret.dispPlanetLilith44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_LILITH];
            ret.dispPlanetLilith55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_LILITH];

            ret.dispPlanetEarth11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_EARTH];
            ret.dispPlanetEarth22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_EARTH];
            ret.dispPlanetEarth33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_EARTH];
            ret.dispPlanetEarth44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_EARTH];
            ret.dispPlanetEarth55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_EARTH];

            ret.dispPlanetCeres11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_CERES];
            ret.dispPlanetCeres22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_CERES];
            ret.dispPlanetCeres33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_CERES];
            ret.dispPlanetCeres44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_CERES];
            ret.dispPlanetCeres55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_CERES];

            ret.dispPlanetPallas11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.dispPlanetPallas22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.dispPlanetPallas33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.dispPlanetPallas44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.dispPlanetPallas55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_PALLAS];

            ret.dispPlanetJuno11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_JUNO];
            ret.dispPlanetJuno22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_JUNO];
            ret.dispPlanetJuno33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_JUNO];
            ret.dispPlanetJuno44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_JUNO];
            ret.dispPlanetJuno55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_JUNO];

            ret.dispPlanetVesta11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_VESTA];
            ret.dispPlanetVesta22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_VESTA];
            ret.dispPlanetVesta33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_VESTA];
            ret.dispPlanetVesta44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_VESTA];
            ret.dispPlanetVesta55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_VESTA];

            ret.dispPlanetSedna11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.dispPlanetSedna22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.dispPlanetSedna33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.dispPlanetSedna44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.dispPlanetSedna55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_SEDNA];

            ret.dispPlanetEris11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_ERIS];
            ret.dispPlanetEris22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_ERIS];
            ret.dispPlanetEris33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_ERIS];
            ret.dispPlanetEris44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_ERIS];
            ret.dispPlanetEris55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_ERIS];

            ret.dispPlanetHaumea11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.dispPlanetHaumea22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.dispPlanetHaumea33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.dispPlanetHaumea44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.dispPlanetHaumea55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_HAUMEA];

            ret.dispPlanetMakemake11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.dispPlanetMakemake22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.dispPlanetMakemake33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.dispPlanetMakemake44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.dispPlanetMakemake55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_MAKEMAKE];

            ret.dispPlanetVt11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_VT];
            ret.dispPlanetVt22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_VT];
            ret.dispPlanetVt33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_VT];
            ret.dispPlanetVt44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_VT];
            ret.dispPlanetVt55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_VT];

            ret.dispPlanetPof11 = setting.dispPlanet[0][CommonData.ZODIAC_NUMBER_POF];
            ret.dispPlanetPof22 = setting.dispPlanet[1][CommonData.ZODIAC_NUMBER_POF];
            ret.dispPlanetPof33 = setting.dispPlanet[2][CommonData.ZODIAC_NUMBER_POF];
            ret.dispPlanetPof44 = setting.dispPlanet[3][CommonData.ZODIAC_NUMBER_POF];
            ret.dispPlanetPof55 = setting.dispPlanet[4][CommonData.ZODIAC_NUMBER_POF];

            ret.aspectSun11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SUN];
            ret.aspectSun22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SUN];
            ret.aspectSun33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SUN];
            ret.aspectSun44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_SUN];
            ret.aspectSun55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_SUN];

            ret.aspectMoon11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MOON];
            ret.aspectMoon22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MOON];
            ret.aspectMoon33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MOON];
            ret.aspectMoon44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_MOON];
            ret.aspectMoon55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_MOON];

            ret.aspectMercury11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.aspectMercury22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.aspectMercury33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.aspectMercury44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.aspectMercury55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_MERCURY];

            ret.aspectVenus11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VENUS];
            ret.aspectVenus22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VENUS];
            ret.aspectVenus33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VENUS];
            ret.aspectVenus44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_VENUS];
            ret.aspectVenus55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_VENUS];

            ret.aspectMars11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MARS];
            ret.aspectMars22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MARS];
            ret.aspectMars33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MARS];
            ret.aspectMars44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_MARS];
            ret.aspectMars55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_MARS];

            ret.aspectJupiter11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.aspectJupiter22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.aspectJupiter33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.aspectJupiter44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.aspectJupiter55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_JUPITER];

            ret.aspectSaturn11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SATURN];
            ret.aspectSaturn22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SATURN];
            ret.aspectSaturn33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SATURN];
            ret.aspectSaturn44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_SATURN];
            ret.aspectSaturn55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_SATURN];

            ret.aspectUranus11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_URANUS];
            ret.aspectUranus22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_URANUS];
            ret.aspectUranus33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_URANUS];
            ret.aspectUranus44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_URANUS];
            ret.aspectUranus55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_URANUS];

            ret.aspectNeptune11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.aspectNeptune22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.aspectNeptune33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.aspectNeptune44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.aspectNeptune55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_NEPTUNE];

            ret.aspectPluto11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.aspectPluto22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.aspectPluto33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.aspectPluto44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.aspectPluto55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_PLUTO];

            ret.aspectAsc11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_ASC];
            ret.aspectAsc22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_ASC];
            ret.aspectAsc33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_ASC];
            ret.aspectAsc44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_ASC];
            ret.aspectAsc55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_ASC];

            ret.aspectMc11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MC];
            ret.aspectMc22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MC];
            ret.aspectMc33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MC];
            ret.aspectMc44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_MC];
            ret.aspectMc55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_MC];

            ret.aspectChiron11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.aspectChiron22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.aspectChiron33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.aspectChiron44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.aspectChiron55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_CHIRON];

            ret.aspectEarth11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_EARTH];
            ret.aspectEarth22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_EARTH];
            ret.aspectEarth33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_EARTH];
            ret.aspectEarth44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_EARTH];
            ret.aspectEarth55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_EARTH];

            ret.aspectLilith11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_LILITH];
            ret.aspectLilith22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_LILITH];
            ret.aspectLilith33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_LILITH];
            ret.aspectLilith44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_LILITH];
            ret.aspectLilith55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_LILITH];

            ret.aspectDh11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.aspectDh22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.aspectDh33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.aspectDh44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.aspectDh55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_DH_TRUENODE];

            ret.aspectVt11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VT];
            ret.aspectVt22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VT];
            ret.aspectVt33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VT];
            ret.aspectVt44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_VT];
            ret.aspectVt55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_VT];

            ret.aspectPof11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_POF];
            ret.aspectPof22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_POF];
            ret.aspectPof33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_POF];
            ret.aspectPof44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_POF];
            ret.aspectPof55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_POF];

            ret.aspectCeres11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_CERES];
            ret.aspectCeres22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_CERES];
            ret.aspectCeres33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_CERES];
            ret.aspectCeres44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_CERES];
            ret.aspectCeres55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_CERES];

            ret.aspectPallas11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.aspectPallas22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.aspectPallas33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.aspectPallas44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_PALLAS];
            ret.aspectPallas55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_PALLAS];

            ret.aspectJuno11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_JUNO];
            ret.aspectJuno22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_JUNO];
            ret.aspectJuno33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_JUNO];
            ret.aspectJuno44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_JUNO];
            ret.aspectJuno55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_JUNO];

            ret.aspectVesta11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_VESTA];
            ret.aspectVesta22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_VESTA];
            ret.aspectVesta33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_VESTA];
            ret.aspectVesta44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_VESTA];
            ret.aspectVesta55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_VESTA];

            ret.aspectEris11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_ERIS];
            ret.aspectEris22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_ERIS];
            ret.aspectEris33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_ERIS];
            ret.aspectEris44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_ERIS];
            ret.aspectEris55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_ERIS];

            ret.aspectSedna11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.aspectSedna22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.aspectSedna33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.aspectSedna44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.aspectSedna55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_SEDNA];

            ret.aspectHaumea11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.aspectHaumea22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.aspectHaumea33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.aspectHaumea44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.aspectHaumea55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_HAUMEA];

            ret.aspectMakemake11 = setting.dispAspectPlanet[0][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.aspectMakemake22 = setting.dispAspectPlanet[1][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.aspectMakemake33 = setting.dispAspectPlanet[2][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.aspectMakemake44 = setting.dispAspectPlanet[3][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.aspectMakemake55 = setting.dispAspectPlanet[4][CommonData.ZODIAC_NUMBER_MAKEMAKE];

            ret.aspectConjunction11 =  setting.aspectConjunction[0, 0];
            ret.aspectConjunction12 = setting.aspectConjunction[0, 1];
            ret.aspectConjunction13 = setting.aspectConjunction[0, 2];
            ret.aspectConjunction14 = setting.aspectConjunction[0, 3];
            ret.aspectConjunction15 = setting.aspectConjunction[0, 4];
            ret.aspectConjunction22 = setting.aspectConjunction[1, 1];
            ret.aspectConjunction23 = setting.aspectConjunction[1, 2];
            ret.aspectConjunction24 = setting.aspectConjunction[1, 3];
            ret.aspectConjunction25 = setting.aspectConjunction[1, 4];
            ret.aspectConjunction33 = setting.aspectConjunction[2, 2];
            ret.aspectConjunction34 = setting.aspectConjunction[2, 3];
            ret.aspectConjunction35 = setting.aspectConjunction[2, 4];
            ret.aspectConjunction44 = setting.aspectConjunction[3, 3];
            ret.aspectConjunction45 = setting.aspectConjunction[3, 4];
            ret.aspectConjunction55 = setting.aspectConjunction[4, 4];

            ret.aspectOpposition11 = setting.aspectOpposition[0, 0];
            ret.aspectOpposition12 = setting.aspectOpposition[0, 1];
            ret.aspectOpposition13 = setting.aspectOpposition[0, 2];
            ret.aspectOpposition14 = setting.aspectOpposition[0, 3];
            ret.aspectOpposition15 = setting.aspectOpposition[0, 4];
            ret.aspectOpposition22 = setting.aspectOpposition[1, 1];
            ret.aspectOpposition23 = setting.aspectOpposition[1, 2];
            ret.aspectOpposition24 = setting.aspectOpposition[1, 3];
            ret.aspectOpposition25 = setting.aspectOpposition[1, 4];
            ret.aspectOpposition33 = setting.aspectOpposition[2, 2];
            ret.aspectOpposition34 = setting.aspectOpposition[2, 3];
            ret.aspectOpposition35 = setting.aspectOpposition[2, 4];
            ret.aspectOpposition44 = setting.aspectOpposition[3, 3];
            ret.aspectOpposition45 = setting.aspectOpposition[3, 4];
            ret.aspectOpposition55 = setting.aspectOpposition[4, 4];

            ret.aspectTrine11 = setting.aspectTrine[0, 0];
            ret.aspectTrine12 = setting.aspectTrine[0, 1];
            ret.aspectTrine13 = setting.aspectTrine[0, 2];
            ret.aspectTrine14 = setting.aspectTrine[0, 3];
            ret.aspectTrine15 = setting.aspectTrine[0, 4];
            ret.aspectTrine22 = setting.aspectTrine[1, 1];
            ret.aspectTrine23 = setting.aspectTrine[1, 2];
            ret.aspectTrine24 = setting.aspectTrine[1, 3];
            ret.aspectTrine25 = setting.aspectTrine[1, 4];
            ret.aspectTrine33 = setting.aspectTrine[2, 2];
            ret.aspectTrine34 = setting.aspectTrine[2, 3];
            ret.aspectTrine35 = setting.aspectTrine[2, 4];
            ret.aspectTrine44 = setting.aspectTrine[3, 3];
            ret.aspectTrine45 = setting.aspectTrine[3, 4];
            ret.aspectTrine55 = setting.aspectTrine[4, 4];

            ret.aspectSquare11 = setting.aspectSquare[0, 0];
            ret.aspectSquare12 = setting.aspectSquare[0, 1];
            ret.aspectSquare13 = setting.aspectSquare[0, 2];
            ret.aspectSquare14 = setting.aspectSquare[0, 3];
            ret.aspectSquare15 = setting.aspectSquare[0, 4];
            ret.aspectSquare22 = setting.aspectSquare[1, 1];
            ret.aspectSquare23 = setting.aspectSquare[1, 2];
            ret.aspectSquare24 = setting.aspectSquare[1, 3];
            ret.aspectSquare25 = setting.aspectSquare[1, 4];
            ret.aspectSquare33 = setting.aspectSquare[2, 2];
            ret.aspectSquare34 = setting.aspectSquare[2, 3];
            ret.aspectSquare35 = setting.aspectSquare[2, 4];
            ret.aspectSquare44 = setting.aspectSquare[3, 3];
            ret.aspectSquare45 = setting.aspectSquare[3, 4];
            ret.aspectSquare55 = setting.aspectSquare[4, 4];

            ret.aspectSextile11 = setting.aspectSextile[0, 0];
            ret.aspectSextile12 = setting.aspectSextile[0, 1];
            ret.aspectSextile13 = setting.aspectSextile[0, 2];
            ret.aspectSextile14 = setting.aspectSextile[0, 3];
            ret.aspectSextile15 = setting.aspectSextile[0, 4];
            ret.aspectSextile22 = setting.aspectSextile[1, 1];
            ret.aspectSextile23 = setting.aspectSextile[1, 2];
            ret.aspectSextile24 = setting.aspectSextile[1, 3];
            ret.aspectSextile25 = setting.aspectSextile[1, 4];
            ret.aspectSextile33 = setting.aspectSextile[2, 2];
            ret.aspectSextile34 = setting.aspectSextile[2, 3];
            ret.aspectSextile35 = setting.aspectSextile[2, 4];
            ret.aspectSextile44 = setting.aspectSextile[3, 3];
            ret.aspectSextile45 = setting.aspectSextile[3, 4];
            ret.aspectSextile55 = setting.aspectSextile[4, 4];

            ret.aspectInconjunct11 = setting.aspectInconjunct[0, 0];
            ret.aspectInconjunct12 = setting.aspectInconjunct[0, 1];
            ret.aspectInconjunct13 = setting.aspectInconjunct[0, 2];
            ret.aspectInconjunct14 = setting.aspectInconjunct[0, 3];
            ret.aspectInconjunct15 = setting.aspectInconjunct[0, 4];
            ret.aspectInconjunct22 = setting.aspectInconjunct[1, 1];
            ret.aspectInconjunct23 = setting.aspectInconjunct[1, 2];
            ret.aspectInconjunct24 = setting.aspectInconjunct[1, 3];
            ret.aspectInconjunct25 = setting.aspectInconjunct[1, 4];
            ret.aspectInconjunct33 = setting.aspectInconjunct[2, 2];
            ret.aspectInconjunct34 = setting.aspectInconjunct[2, 3];
            ret.aspectInconjunct35 = setting.aspectInconjunct[2, 4];
            ret.aspectInconjunct44 = setting.aspectInconjunct[3, 3];
            ret.aspectInconjunct45 = setting.aspectInconjunct[3, 4];
            ret.aspectInconjunct55 = setting.aspectInconjunct[4, 4];

            ret.aspectSemiSquare11 = setting.aspectSemiSquare[0, 0];
            ret.aspectSemiSquare12 = setting.aspectSemiSquare[0, 1];
            ret.aspectSemiSquare13 = setting.aspectSemiSquare[0, 2];
            ret.aspectSemiSquare14 = setting.aspectSemiSquare[0, 3];
            ret.aspectSemiSquare15 = setting.aspectSemiSquare[0, 4];
            ret.aspectSemiSquare22 = setting.aspectSemiSquare[1, 1];
            ret.aspectSemiSquare23 = setting.aspectSemiSquare[1, 2];
            ret.aspectSemiSquare24 = setting.aspectSemiSquare[1, 3];
            ret.aspectSemiSquare25 = setting.aspectSemiSquare[1, 4];
            ret.aspectSemiSquare33 = setting.aspectSemiSquare[2, 2];
            ret.aspectSemiSquare34 = setting.aspectSemiSquare[2, 3];
            ret.aspectSemiSquare35 = setting.aspectSemiSquare[2, 4];
            ret.aspectSemiSquare44 = setting.aspectSemiSquare[3, 3];
            ret.aspectSemiSquare45 = setting.aspectSemiSquare[3, 4];
            ret.aspectSemiSquare55 = setting.aspectSemiSquare[4, 4];

            ret.aspectSemiSextile11 = setting.aspectSemiSextile[0, 0];
            ret.aspectSemiSextile12 = setting.aspectSemiSextile[0, 1];
            ret.aspectSemiSextile13 = setting.aspectSemiSextile[0, 2];
            ret.aspectSemiSextile14 = setting.aspectSemiSextile[0, 3];
            ret.aspectSemiSextile15 = setting.aspectSemiSextile[0, 4];
            ret.aspectSemiSextile22 = setting.aspectSemiSextile[1, 1];
            ret.aspectSemiSextile23 = setting.aspectSemiSextile[1, 2];
            ret.aspectSemiSextile24 = setting.aspectSemiSextile[1, 3];
            ret.aspectSemiSextile25 = setting.aspectSemiSextile[1, 4];
            ret.aspectSemiSextile33 = setting.aspectSemiSextile[2, 2];
            ret.aspectSemiSextile34 = setting.aspectSemiSextile[2, 3];
            ret.aspectSemiSextile35 = setting.aspectSemiSextile[2, 4];
            ret.aspectSemiSextile44 = setting.aspectSemiSextile[3, 3];
            ret.aspectSemiSextile45 = setting.aspectSemiSextile[3, 4];
            ret.aspectSemiSextile55 = setting.aspectSemiSextile[4, 4];

            ret.aspectQuintile11 = setting.aspectQuintile[0, 0];
            ret.aspectQuintile12 = setting.aspectQuintile[0, 1];
            ret.aspectQuintile13 = setting.aspectQuintile[0, 2];
            ret.aspectQuintile14 = setting.aspectQuintile[0, 3];
            ret.aspectQuintile15 = setting.aspectQuintile[0, 4];
            ret.aspectQuintile22 = setting.aspectQuintile[1, 1];
            ret.aspectQuintile23 = setting.aspectQuintile[1, 2];
            ret.aspectQuintile24 = setting.aspectQuintile[1, 3];
            ret.aspectQuintile25 = setting.aspectQuintile[1, 4];
            ret.aspectQuintile33 = setting.aspectQuintile[2, 2];
            ret.aspectQuintile34 = setting.aspectQuintile[2, 3];
            ret.aspectQuintile35 = setting.aspectQuintile[2, 4];
            ret.aspectQuintile44 = setting.aspectQuintile[3, 3];
            ret.aspectQuintile45 = setting.aspectQuintile[3, 4];
            ret.aspectQuintile55 = setting.aspectQuintile[4, 4];

            ret.aspectBiQuintile11 = setting.aspectBiQuintile[0, 0];
            ret.aspectBiQuintile12 = setting.aspectBiQuintile[0, 1];
            ret.aspectBiQuintile13 = setting.aspectBiQuintile[0, 2];
            ret.aspectBiQuintile14 = setting.aspectBiQuintile[0, 3];
            ret.aspectBiQuintile15 = setting.aspectBiQuintile[0, 4];
            ret.aspectBiQuintile22 = setting.aspectBiQuintile[1, 1];
            ret.aspectBiQuintile23 = setting.aspectBiQuintile[1, 2];
            ret.aspectBiQuintile24 = setting.aspectBiQuintile[1, 3];
            ret.aspectBiQuintile25 = setting.aspectBiQuintile[1, 4];
            ret.aspectBiQuintile33 = setting.aspectBiQuintile[2, 2];
            ret.aspectBiQuintile34 = setting.aspectBiQuintile[2, 3];
            ret.aspectBiQuintile35 = setting.aspectBiQuintile[2, 4];
            ret.aspectBiQuintile44 = setting.aspectBiQuintile[3, 3];
            ret.aspectBiQuintile45 = setting.aspectBiQuintile[3, 4];
            ret.aspectBiQuintile55 = setting.aspectBiQuintile[4, 4];

            ret.aspectSemiQuintile11 = setting.aspectSemiQuintile[0, 0];
            ret.aspectSemiQuintile12 = setting.aspectSemiQuintile[0, 1];
            ret.aspectSemiQuintile13 = setting.aspectSemiQuintile[0, 2];
            ret.aspectSemiQuintile14 = setting.aspectSemiQuintile[0, 3];
            ret.aspectSemiQuintile15 = setting.aspectSemiQuintile[0, 4];
            ret.aspectSemiQuintile22 = setting.aspectSemiQuintile[1, 1];
            ret.aspectSemiQuintile23 = setting.aspectSemiQuintile[1, 2];
            ret.aspectSemiQuintile24 = setting.aspectSemiQuintile[1, 3];
            ret.aspectSemiQuintile25 = setting.aspectSemiQuintile[1, 4];
            ret.aspectSemiQuintile33 = setting.aspectSemiQuintile[2, 2];
            ret.aspectSemiQuintile34 = setting.aspectSemiQuintile[2, 3];
            ret.aspectSemiQuintile35 = setting.aspectSemiQuintile[2, 4];
            ret.aspectSemiQuintile44 = setting.aspectSemiQuintile[3, 3];
            ret.aspectSemiQuintile45 = setting.aspectSemiQuintile[3, 4];
            ret.aspectSemiQuintile55 = setting.aspectSemiQuintile[4, 4];


            ret.aspectNovile11 = setting.aspectNovile[0, 0];
            ret.aspectNovile12 = setting.aspectNovile[0, 1];
            ret.aspectNovile13 = setting.aspectNovile[0, 2];
            ret.aspectNovile14 = setting.aspectNovile[0, 3];
            ret.aspectNovile15 = setting.aspectNovile[0, 4];
            ret.aspectNovile22 = setting.aspectNovile[1, 1];
            ret.aspectNovile23 = setting.aspectNovile[1, 2];
            ret.aspectNovile24 = setting.aspectNovile[1, 3];
            ret.aspectNovile25 = setting.aspectNovile[1, 4];
            ret.aspectNovile33 = setting.aspectNovile[2, 2];
            ret.aspectNovile34 = setting.aspectNovile[2, 3];
            ret.aspectNovile35 = setting.aspectNovile[2, 4];
            ret.aspectNovile44 = setting.aspectNovile[3, 3];
            ret.aspectNovile45 = setting.aspectNovile[3, 4];
            ret.aspectNovile55 = setting.aspectNovile[4, 4];

            ret.aspectSeptile11 = setting.aspectSeptile[0, 0];
            ret.aspectSeptile12 = setting.aspectSeptile[0, 1];
            ret.aspectSeptile13 = setting.aspectSeptile[0, 2];
            ret.aspectSeptile14 = setting.aspectSeptile[0, 3];
            ret.aspectSeptile15 = setting.aspectSeptile[0, 4];
            ret.aspectSeptile22 = setting.aspectSeptile[1, 1];
            ret.aspectSeptile23 = setting.aspectSeptile[1, 2];
            ret.aspectSeptile24 = setting.aspectSeptile[1, 3];
            ret.aspectSeptile25 = setting.aspectSeptile[1, 4];
            ret.aspectSeptile33 = setting.aspectSeptile[2, 2];
            ret.aspectSeptile34 = setting.aspectSeptile[2, 3];
            ret.aspectSeptile35 = setting.aspectSeptile[2, 4];
            ret.aspectSeptile44 = setting.aspectSeptile[3, 3];
            ret.aspectSeptile45 = setting.aspectSeptile[3, 4];
            ret.aspectSeptile55 = setting.aspectSeptile[4, 4];

            ret.aspectSesquiquadrate11 = setting.aspectSesquiquadrate[0, 0];
            ret.aspectSesquiquadrate12 = setting.aspectSesquiquadrate[0, 1];
            ret.aspectSesquiquadrate13 = setting.aspectSesquiquadrate[0, 2];
            ret.aspectSesquiquadrate14 = setting.aspectSesquiquadrate[0, 3];
            ret.aspectSesquiquadrate15 = setting.aspectSesquiquadrate[0, 4];
            ret.aspectSesquiquadrate22 = setting.aspectSesquiquadrate[1, 1];
            ret.aspectSesquiquadrate23 = setting.aspectSesquiquadrate[1, 2];
            ret.aspectSesquiquadrate24 = setting.aspectSesquiquadrate[1, 3];
            ret.aspectSesquiquadrate25 = setting.aspectSesquiquadrate[1, 4];
            ret.aspectSesquiquadrate33 = setting.aspectSesquiquadrate[2, 2];
            ret.aspectSesquiquadrate34 = setting.aspectSesquiquadrate[2, 3];
            ret.aspectSesquiquadrate35 = setting.aspectSesquiquadrate[2, 4];
            ret.aspectSesquiquadrate44 = setting.aspectSesquiquadrate[3, 3];
            ret.aspectSesquiquadrate45 = setting.aspectSesquiquadrate[3, 4];
            ret.aspectSesquiquadrate55 = setting.aspectSesquiquadrate[4, 4];


            return ret;
        }


    }
}

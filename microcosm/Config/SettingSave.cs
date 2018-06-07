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

            return ret;
        }


    }
}

using System;
using System.IO;
using System.Xml.Serialization;
using microcosm.Common;

namespace microcosm.Config
{
    public class SettingSave
    {
        public SettingSave()
        {
        }

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

            string planets = "";
            for (int i = 0; i < 6; i++) {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_SUN];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_SUN];
            ret.dispPlanetSun = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_MOON];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_MOON];
            ret.dispPlanetMoon = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_MERCURY];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_MERCURY];
            ret.dispPlanetMercury = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_VENUS];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_VENUS];
            ret.dispPlanetVenus = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_MARS];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_MARS];
            ret.dispPlanetMars = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_JUPITER];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_JUPITER];
            ret.dispPlanetJupiter = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_SATURN];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_SATURN];
            ret.dispPlanetSaturn = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_URANUS];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_URANUS];
            ret.dispPlanetUranus = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_NEPTUNE];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_NEPTUNE];
            ret.dispPlanetNeptune = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_PLUTO];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_PLUTO];
            ret.dispPlanetPluto = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_ASC];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_ASC];
            ret.dispPlanetAsc = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_MC];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_MC];
            ret.dispPlanetMc = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_CHIRON];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_CHIRON];
            ret.dispPlanetChiron = planets;

            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_EARTH];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_EARTH];
            ret.dispPlanetEarth = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_DH_TRUENODE];
            ret.dispPlanetDh = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_LILITH];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_LILITH];
            ret.dispPlanetLilith = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_VT];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_VT];
            ret.dispPlanetVt = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_POF];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_POF];
            ret.dispPlanetPof = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_CERES];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_CERES];
            ret.dispPlanetCeres = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_PARAS];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_PARAS];
            ret.dispPlanetParas = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_JUNO];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_JUNO];
            ret.dispPlanetJuno = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_VESTA];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_VESTA];
            ret.dispPlanetVesta = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_ERIS];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_ERIS];
            ret.dispPlanetEris = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_SEDNA];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_SEDNA];
            ret.dispPlanetSedna = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_HAUMEA];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_HAUMEA];
            ret.dispPlanetHaumea = planets;
 
            for (int i = 0; i < 6; i++)
            {
                planets += setting.dispPlanet[i][CommonData.ZODIAC_NUMBER_MAKEMAKE];
                planets += ",";
            }
            planets += setting.dispPlanet[6][CommonData.ZODIAC_NUMBER_MAKEMAKE];
            ret.dispPlanetMakemake = planets;
 
            return ret;
        }


    }
}

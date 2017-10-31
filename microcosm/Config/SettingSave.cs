﻿using System;
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

            return ret;
        }


    }
}

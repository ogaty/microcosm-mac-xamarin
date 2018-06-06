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

            return ret;
        }


    }
}

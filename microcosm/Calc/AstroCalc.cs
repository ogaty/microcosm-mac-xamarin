using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using SwissEphNet;

namespace microcosm.Calc
{
    public class AstroCalc
    {
        public SwissEph s;

        public AstroCalc()
        {
            s = new SwissEph();
        }

        /// <summary>
        /// planet position calcurate.
        /// </summary>
        /// <param name="timezone">Timezone. JST=9.0</param>
        public List<PlanetData> PositionCalc(DateTime date, double timezone) 
        {
            List<PlanetData> planetList = new List<PlanetData>();

  //          s.swe_set_ephe_path(path);
            s.OnLoadFile += (sender, e) => {
                var path = Path.Combine(NSBundle.MainBundle.BundlePath, "Contents", "Resources", "ephe");
                var f = e.FileName.Split('\\');
                if (File.Exists(path + "/" + f[1]))
                {
                    e.File = new FileStream(path + "/" + f[1], FileMode.Open);
                }
            };
            int utc_year = 0;
            int utc_month = 0;
            int utc_day = 0;
            int utc_hour = 0;
            int utc_minute = 0;
            double utc_second = 0;
            double[] dret = { 0.0, 0.0 };
            double[] x = { 0, 0, 0, 0, 0, 0 };
            string serr = "";

            s.swe_utc_time_zone(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, timezone,
                                ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;

            foreach (int planet_number in Common.CommonData.target_numbers)
            {
                s.swe_calc_ut(dret[1], planet_number, flag, x, ref serr);

                PlanetData p = new PlanetData()
                {
                    no = planet_number,
                    absolute_position = x[0],
                    speed = x[3], // AMATERUでもここ使ってたからたぶん良い
                    aspects0 = new List<AspectInfo>(),
                    aspects1 = new List<AspectInfo>(),
                    aspects2 = new List<AspectInfo>(),
                    aspects3 = new List<AspectInfo>(),
                    aspects4 = new List<AspectInfo>(),
                    aspects5 = new List<AspectInfo>(),
                    aspects6 = new List<AspectInfo>()
                };
                if (planet_number == CommonData.ZODIAC_NUMBER_ASC ||
                    planet_number == CommonData.ZODIAC_NUMBER_MC ||
                    planet_number == CommonData.ZODIAC_NUMBER_DH_TRUENODE ||
                    planet_number == CommonData.ZODIAC_NUMBER_LILITH ||
                    planet_number == CommonData.ZODIAC_NUMBER_VT ||
                    planet_number == CommonData.ZODIAC_NUMBER_POF
                   ) {
                    p.sensitive = true;
                } else {
                    p.sensitive = false;
                }
                planetList.Add(p);
            }
            return planetList;
        }

        /// <summary>
        /// ハウス計算
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="d">時刻</param>
        /// <param name="lat">緯度</param>
        /// <param name="lng">経度</param>
        /// <param name="houseKind">ハウス種別
        /// 0:Placidus
        /// 1:Koch
        /// 2:Campanus
        /// 
        /// </param>
        /// 
        public double[] CuspCalc(DateTime d, double lat, double lng, EHouseCalc houseKind)
        {
            int utc_year = 0;
            int utc_month = 0;
            int utc_day = 0;
            int utc_hour = 0;
            int utc_minute = 0;
            double utc_second = 0;
            string serr = "";
            // [0]:Ephemeris Time [1]:Universal Time
            double[] dret = { 0.0, 0.0 };

            // utcに変換
            s.swe_utc_time_zone(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, 0.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            double[] cusps = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] ascmc = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (houseKind == EHouseCalc.PLACIDUS)
            {
                // Placidas
                s.swe_houses(dret[1], lat, lng, 'P', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.KOCH)
            {
                // Koch
                s.swe_houses(dret[1], lat, lng, 'K', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.CAMPANUS)
            {
                // Campanus
                s.swe_houses(dret[1], lat, lng, 'C', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.PORPHYRY)
            {
                // Porphyrious
                s.swe_houses(dret[1], lat, lng, 'O', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.REGIOMONTANUS)
            {
                // Porphyrious
                s.swe_houses(dret[1], lat, lng, 'R', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.EQUAL)
            {
                // Equal
                s.swe_houses(dret[1], lat, lng, 'E', cusps, ascmc);
            }
            else if (houseKind == EHouseCalc.SOLAR)
            {
                // Solar
                // 太陽の度数をASCとして30度
            }
            else if (houseKind == EHouseCalc.SOLARSIGN)
            {
                // SolarSign
                // 太陽のサインの0度をASCとして30度
            }
            s.swe_close();

            return cusps;
        }


        public Calcuration ReCalc(ConfigData config, SettingData setting, UserData udata)
        {
            List<PlanetData> p = PositionCalc(udata.time, udata.timezone);
            double[] cusps = CuspCalc(udata.time, udata.lat, udata.lng, config.houseCalc);
            Calcuration calcurate = new Calcuration(p, cusps);

            return calcurate;
        }
    }
}

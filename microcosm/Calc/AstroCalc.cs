﻿using System;
using System.IO;
using Foundation;
using SwissEphNet;

namespace microcosm.Calc
{
    public class AstroCalc
    {
        public SwissEph s;

        public AstroCalc(ViewController main)
        {
            s = new SwissEph();
        }

        /// <summary>
        /// planet position calcurate.
        /// </summary>
        /// <param name="timezone">Timezone. JST=9.0</param>
        public void PositionCalc(double timezone) 
        {

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

            s.swe_utc_time_zone(1980, 12, 21, 12, 0, 0, timezone,
                                ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
            s.swe_calc_ut(dret[1], 1, flag, x, ref serr);

            foreach (int planet_number in Common.CommonData.target_numbers)
            {
                s.swe_calc_ut(dret[1], planet_number, flag, x, ref serr);
                Console.WriteLine(planet_number.ToString() + " " + x[0]);
                Console.WriteLine(serr);
            }
        }
    }
}
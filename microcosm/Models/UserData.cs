using System;
using microcosm.Common;

namespace microcosm.Models
{
    /// <summary>
    /// ユーザー情報が入ったクラス
    /// </summary>
    public class UserData
    {
        public string name;
        public DateTime time;
        public double lat;
        public double lng;
        public string timezonestr;
        public double timezone;

        public UserData()
        {
            name = "現在時刻";
            time = DateTime.Now;
            lat = CommonData.defaultLat;
            lng = CommonData.defaultLng;
            timezonestr = "JST";
            timezone = 9.0;
        }
    }
}

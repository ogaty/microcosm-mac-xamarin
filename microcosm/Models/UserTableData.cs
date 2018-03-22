using System;
namespace microcosm.Models
{
    public class UserTableData
    {
        public string name;
        public DateTime date;
        public string memo;
        public string displayDate {
            get {
                return String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                                     date.Year, date.Month, date.Day,
                                     date.Hour, date.Minute, date.Second);
            }
        }

        public UserTableData()
        {
        }
    }
}

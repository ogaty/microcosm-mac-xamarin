using System;
namespace microcosm.Models
{
    public class UserTableData
    {
        public string name;
        public DateTime date;
        public string displayDate {
            get {
                return date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString() + " " +
                           date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            }
        }

        public UserTableData()
        {
        }
    }
}

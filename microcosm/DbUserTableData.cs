using System;
namespace microcosm
{
    public class DbUserTableData
    {
        public string name;
        public DateTime date;

        public DbUserTableData(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
        }
    }
}

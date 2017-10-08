using System;
using AppKit;
using System.Collections;
using System.Collections.Generic;
namespace microcosm
{
    public class DbUserTableDataSource : NSTableViewDataSource
    {
        public List<DbUserTableData> dataList = new List<DbUserTableData>();

        public DbUserTableDataSource()
        {
        }

		public override nint GetRowCount(NSTableView tableView)
		{
            return dataList.Count;
		}
    }
}

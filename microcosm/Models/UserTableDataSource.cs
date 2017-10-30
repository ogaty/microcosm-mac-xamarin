using System;
using System.Collections.Generic;
using AppKit;

namespace microcosm.Models
{
    public class UserTableDataSource : NSTableViewDataSource
    {
        public List<UserTableData> dataList = new List<UserTableData>();

        public UserTableDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return dataList.Count;
        }
    }
}

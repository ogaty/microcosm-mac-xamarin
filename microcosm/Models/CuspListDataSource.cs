using System;
using System.Collections.Generic;
using AppKit;
namespace microcosm.Models
{
    public class CuspListDataSource : NSTableViewDataSource
    {
        public List<CuspListData> list = new List<CuspListData>();

        public CuspListDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return list.Count;
        }
    }
}

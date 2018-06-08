using System;
using System.Collections.Generic;
using AppKit;

namespace microcosm.Models
{
    public class SettingNameDataSource : NSTableViewDataSource
    {
        public List<SettingNameList> DataList;
        public SettingNameDataSource(List<SettingNameList> lists)
        {
            DataList = lists;
        }
        public override nint GetRowCount(NSTableView tableView)
        {
            return DataList.Count;
        }
    }
}

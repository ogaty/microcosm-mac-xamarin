using System;
using AppKit;
using System.Collections.Generic;


namespace microcosm.Tables
{
    public class SettingDetailPlanetTableDataSource : NSTableViewDataSource
    {
        public List<SettingDetailPlanetTableData> dataList = new List<SettingDetailPlanetTableData>();

        public SettingDetailPlanetTableDataSource()
        {
        }


        public override nint GetRowCount(NSTableView tableView)
        {
            return dataList.Count;
        }

    }
}

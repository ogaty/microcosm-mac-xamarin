using System;
using System.Collections.Generic;
using AppKit;

namespace microcosm.Models
{
    public class SearchLatLngDataSource : NSTableViewDataSource
    {
        public List<SearchLatLngData> dataList = new List<SearchLatLngData>();
        public SearchLatLngDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return dataList.Count;
        }

    }
}

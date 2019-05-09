using System;
using AppKit;

namespace microcosm.Models
{
    public class SearchLatLngDelegate : NSTableViewDelegate
    {
        public SearchLatLngDataSource DataSource;
        private const string CellIdentifier = "SearchLatLngCell";
        public SearchLatLngDelegate(SearchLatLngDataSource dataSource)
        {
            this.DataSource = dataSource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            switch (tableColumn.Title)
            {
                case "場所":
                    view.StringValue = DataSource.dataList[(int)row].place;
                    break;
                case "緯度":
                    view.StringValue = DataSource.dataList[(int)row].lat.ToString();
                    break;
                case "経度":
                    view.StringValue = DataSource.dataList[(int)row].lng.ToString();
                    break;
            }

            return view;
        }
    }
}

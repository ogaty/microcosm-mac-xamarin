using System;
using AppKit;

namespace microcosm.Models
{
    public class UserTableDelegate : NSTableViewDelegate
    {
        public UserTableDataSource DataSource;

        private const string CellIdentifier = "UserTableItemCell";

        public UserTableDelegate(UserTableDataSource DataSource)
        {
            this.DataSource = DataSource;
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
                case "名前":
                    view.StringValue = DataSource.dataList[(int)row].name;
                    break;
                case "時刻":
                    view.StringValue = DataSource.dataList[(int)row].displayDate;
                    break;
            }

            return view;
        }

    }
}

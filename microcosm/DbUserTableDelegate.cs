using System;
using AppKit;
namespace microcosm
{
    public class DbUserTableDelegate : NSTableViewDelegate
    {
        private const string cellIdentifier = "cellID";

        private DbUserTableDataSource DataSource;

        public DbUserTableDelegate(DbUserTableDataSource dataSource)
        {
            this.DataSource = dataSource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(cellIdentifier, this);
			if (view == null)
			{
				view = new NSTextField();
				view.Identifier = cellIdentifier;
				view.BackgroundColor = NSColor.Clear;
				view.Bordered = false;
				view.Selectable = false;
				view.Editable = false;
			}
			switch (tableColumn.Title)
			{
				case "name":
                    view.StringValue = DataSource.dataList[(int)row].name;
					break;
				case "date":
                    view.StringValue = DataSource.dataList[(int)row].date.ToString();
					break;
			}

			return view;
        }
    }
}

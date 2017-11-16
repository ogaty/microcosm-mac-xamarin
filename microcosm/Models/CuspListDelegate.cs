using System;
using AppKit;
namespace microcosm.Models
{
    public class CuspListDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "cellID";

        private CuspListDataSource DataSource;

        public CuspListDelegate(CuspListDataSource dataSource)
        {
            DataSource = dataSource;
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

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "cusps":
                    view.StringValue = (row + 1).ToString();
                    break;
                case "1":
                    view.StringValue = DataSource.list[(int)row].Degree.ToString();
                    break;
                case "2":
                    view.StringValue = DataSource.list[(int)row].Degree.ToString();
                    break;
                case "3":
                    view.StringValue = DataSource.list[(int)row].Degree.ToString();
                    break;
            }

            return view;
        }
    }
}

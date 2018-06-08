using System;
using AppKit;
using microcosm.Views;

namespace microcosm.Models
{
    public class SettingNameDelegate : NSTableViewDelegate
    {
        public SettingNameDataSource DataSource;
        protected const string cellId = "SettingCellId";
        public SettingNameDelegate(SettingNameDataSource dataSource)
        {
            this.DataSource = dataSource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(cellId, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = cellId;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            view.StringValue = DataSource.DataList[(int)row].settingName;

            return view;
        }

    }
}

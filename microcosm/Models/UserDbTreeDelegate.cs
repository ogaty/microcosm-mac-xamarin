using System;
using AppKit;

namespace microcosm.Models
{
    public class UserDbTreeDelegate : NSOutlineViewDelegate
    {
        public UserDbTreeDataSource DataSource;
        private const string CellIdentifier = "UserDbDirItemCell";

        public UserDbTreeDelegate(UserDbTreeDataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, Foundation.NSObject item)
        {
            NSTextField view = (NSTextField)outlineView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            TreeViewItem data = (TreeViewItem)item;
            view.StringValue = data.Header;

            return view;
        }

    }
}

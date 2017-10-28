using System;
using System.Collections.Generic;
using AppKit;

namespace microcosm.Models
{
    public class UserDbTreeDataSource : NSOutlineViewDataSource
    {
        public List<TreeViewItem> list = new List<TreeViewItem>();

        public UserDbTreeDataSource()
        {
        }

        public override nint GetChildrenCount(NSOutlineView outlineView, Foundation.NSObject item)
        {
            return list.Count;
        }

        public override bool ItemExpandable(NSOutlineView outlineView, Foundation.NSObject item)
        {
            /*
            if (((TreeViewItem)item).isDir) {
                return false;
            }
            */
            return base.ItemExpandable(outlineView, item);
        }

        public override Foundation.NSObject GetChild(NSOutlineView outlineView, nint childIndex, Foundation.NSObject item)
        {
            return base.GetChild(outlineView, childIndex, item);
        }
    }
}

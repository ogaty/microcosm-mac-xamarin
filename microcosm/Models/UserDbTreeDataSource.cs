using System;
using System.Collections.Generic;
using AppKit;

namespace microcosm.Models
{
    public class UserDbTreeDataSource : NSOutlineViewDataSource
    {
        public List<TreeViewItem> list = new List<TreeViewItem>();

        public TreeViewItem treeItem;

        public UserDbTreeDataSource()
        {
        }

        public override nint GetChildrenCount(NSOutlineView outlineView, Foundation.NSObject item)
        {
            return item == null ? list.Count : ((TreeViewItem)item).Items.Count;
        }

        public override bool ItemExpandable(NSOutlineView outlineView, Foundation.NSObject item)
        {
            return ((TreeViewItem)item).isDir == true;
        }

        public override Foundation.NSObject GetChild(NSOutlineView outlineView, nint childIndex, Foundation.NSObject item)
        {
            if (item == null)
            {
                return list[(int)childIndex];
            } else {
                return ((TreeViewItem)item).Items[(int)childIndex];
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace microcosm.Models
{
    public class TreeViewItem
    {
        public object Tag;
        public string Header;
        public bool isDir;
        public List<object> Items;

        public TreeViewItem()
        {
        }
    }
}

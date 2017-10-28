using System;
using AppKit;

namespace microcosm.Models
{
    public class UserDbTreeDelegate : NSOutlineViewDelegate
    {
        public UserDbTreeDataSource DataSource;

        public UserDbTreeDelegate(UserDbTreeDataSource DataSource)
        {
            this.DataSource = DataSource;
        }

    }
}

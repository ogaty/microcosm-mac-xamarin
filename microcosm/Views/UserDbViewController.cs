using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

using microcosm.Models;
using microcosm.Common;

namespace microcosm.Views
{
    public partial class UserDbViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public UserDbViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public UserDbViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public UserDbViewController() : base("UserDbView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new UserDbView View
        {
            get
            {
                return (UserDbView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UserDbTreeDataSource dataSource = new UserDbTreeDataSource();
            List<TreeViewItem> root = new List<TreeViewItem>();
            TreeViewItem rootNode = UserDirTree.CreateDirectoryNode(new DirectoryInfo(Util.root + "/data"));
            root.Add(rootNode);
            dataSource.list = root;
            UserDbDirOutline.ScrollColumnToVisible(0);
            UserDbDirOutline.DataSource = dataSource;
            UserDbDirOutline.Delegate = new UserDbTreeDelegate(dataSource);

        }
    }
}

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
    /// <summary>
    /// データベースビューコントローラー
    /// </summary>
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

            NSMenu menu = new NSMenu();
            menu.AutoEnablesItems = true;
            EventHandler hander = new EventHandler((object sender, EventArgs e) =>
            {
                Console.WriteLine("sample");
            });
            NSMenuItem menuItem = new NSMenuItem("sample", hander);
            menuItem.Enabled = true;

            menu.AddItem(menuItem);
            UserDbDirOutline.Menu = menu;
        }

        partial void UserDbDirClick(NSObject sender)
        {
            int index = (int)UserDbDirOutline.SelectedRow;
            if (index == -1) {
                // 右クリック
                return;
            }
            TreeViewItem item = (TreeViewItem)UserDbDirOutline.ItemAtRow(index);

            if (item.isDir) {
                return;
            }

            UserTable.AllowsColumnSelection = true;
            UserTableDataSource DataSource = new UserTableDataSource();
            DataSource.dataList.Add(new UserTableData() {name = "sample", date = new DateTime()});

            UserTable.DataSource = DataSource;
            UserTable.Delegate = new UserTableDelegate(DataSource);
            UserTable.ReloadData();

        }

        /// <summary>
        /// directory追加
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void AddDirectoryClick(NSObject sender)
        {
            int row = (int)UserDbDirOutline.SelectedRow;

            if (row > 0) 
            {
                TreeViewItem item = (TreeViewItem)UserDbDirOutline.ItemAtRow(row);
                if (item.isDir && !Directory.Exists(item.FullPath + "/NewDir"))
                {
                    Directory.CreateDirectory(item.FullPath + "/NewDir");
                }
            }
            else
            {
                if (!Directory.Exists(Util.root + "/data/NewDir")) {
                    Directory.CreateDirectory(Util.root + "/data/NewDir");
                }
            }
            UserTable.ReloadData();
        }

        partial void EditDirectoryClick(NSObject sender)
        {

        }

        /// <summary>
        /// directory削除
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DeleteDirectoryClick(NSObject sender)
        {
            int row = (int)UserDbDirOutline.SelectedRow;
            if (row > 0)
            {
                TreeViewItem item = (TreeViewItem)UserDbDirOutline.ItemAtRow(row);
                if (item.isDir && Directory.Exists(item.FullPath))
                {
                    Directory.Delete(item.FullPath, true);
                }
            }
        }

        partial void UserTableClick(NSObject sender)
        {

        }
    }
}

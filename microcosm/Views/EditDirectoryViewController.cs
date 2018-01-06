using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Common;
using System.IO;

namespace microcosm.Views
{
    public partial class EditDirectoryViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EditDirectoryViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EditDirectoryViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EditDirectoryViewController() : base("EditDirectoryView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new EditDirectoryView View
        {
            get
            {
                return (EditDirectoryView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DirectoryName.StringValue = CommonInstance.getInstance().SelectedDirectoryName;
        }

        partial void submit(NSObject sender)
        {
            DirectoryInfo dir = new DirectoryInfo(CommonInstance.getInstance().SelectedDirectoryFullPath);
            Directory.Move(CommonInstance.getInstance().SelectedDirectoryFullPath, dir.Parent.FullName + @"/" + DirectoryName.StringValue);
            UserDbViewController dbvc = this.PresentingViewController as UserDbViewController;
            dbvc.ReSetDbTree();
            DismissViewController(this);
        }
    }
}

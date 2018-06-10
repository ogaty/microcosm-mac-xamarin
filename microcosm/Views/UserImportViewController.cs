using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Threading.Tasks;

namespace microcosm.Views
{
    public partial class UserImportViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public UserImportViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public UserImportViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public UserImportViewController() : base("UserImportView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new UserImportView View
        {
            get
            {
                return (UserImportView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public async Task<bool> Import()
        {
            return await Task.Run(() => 
            {
                return true;
            }); 
        }
    }
}

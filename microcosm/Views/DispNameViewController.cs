using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace microcosm.Views
{
    public partial class DispNameViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public DispNameViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public DispNameViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public DispNameViewController() : base("DispNameView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new DispNameView View
        {
            get
            {
                return (DispNameView)base.View;
            }
        }
    }
}

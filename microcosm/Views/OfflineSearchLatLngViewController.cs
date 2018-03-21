using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace microcosm.Views
{
    public partial class OfflineSearchLatLngViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public OfflineSearchLatLngViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public OfflineSearchLatLngViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public OfflineSearchLatLngViewController() : base("OfflineSearchLatLngView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new OfflineSearchLatLngView View
        {
            get
            {
                return (OfflineSearchLatLngView)base.View;
            }
        }
    }
}

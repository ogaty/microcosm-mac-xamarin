using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace microcosm.Views
{
    public partial class OfflineSearchLatLngView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public OfflineSearchLatLngView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public OfflineSearchLatLngView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}

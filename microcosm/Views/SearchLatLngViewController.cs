using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Common;

namespace microcosm.Views
{
    public partial class SearchLatLngViewController : AppKit.NSViewController
    {
        public string inputPlace = "";
        #region Constructors

        // Called when created from unmanaged code
        public SearchLatLngViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SearchLatLngViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SearchLatLngViewController() : base("SearchLatLngView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new SearchLatLngView View
        {
            get
            {
                return (SearchLatLngView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Place.StringValue = inputPlace;
        }
    }
}

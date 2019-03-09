using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Xml.Linq;
using System.Web.Services;
using System.Net;
using System.Web;
using System.Net.Http;

namespace microcosm.Views
{
    public partial class PlaceSearchViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public PlaceSearchViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public PlaceSearchViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public PlaceSearchViewController() : base("PlaceSearchView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion


        //strongly typed view accessor
        public new PlaceSearchView View
        {
            get
            {
                return (PlaceSearchView)base.View;
            }
        }
    }
}

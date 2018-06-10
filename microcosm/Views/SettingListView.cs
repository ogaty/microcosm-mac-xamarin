using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace microcosm.Views
{
    public partial class SettingListView : NSTableView
    {
        public SettingDispPlanetViewController vc;

        #region Constructors

        // Called when created from unmanaged code
        public SettingListView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingListView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        public override void MouseDown(NSEvent theEvent)
        {
            base.MouseDown(theEvent);
            vc.ReRender((int)SelectedRow);
        }

    }
}

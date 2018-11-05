using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;

namespace microcosm.Views
{
    public partial class DispNameViewController : AppKit.NSViewController
    {
        private ViewController rootViewController;
        private SettingData[] settings;

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
            rootViewController = (ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController;

            settings = rootViewController.settings;
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

        public override void ViewDidLoad()
        {
            disp0.StringValue = settings[0].dispName;
            disp1.StringValue = settings[1].dispName;
            disp2.StringValue = settings[2].dispName;
            disp3.StringValue = settings[3].dispName;
            disp4.StringValue = settings[4].dispName;
            disp5.StringValue = settings[5].dispName;
            disp6.StringValue = settings[6].dispName;
            disp7.StringValue = settings[7].dispName;
            disp8.StringValue = settings[8].dispName;
            disp9.StringValue = settings[9].dispName;
        }

        partial void SubmitClicked(NSObject sender)
        {
            settings[0].dispName = disp0.StringValue;
            settings[1].dispName = disp1.StringValue;
            settings[2].dispName = disp2.StringValue;
            settings[3].dispName = disp3.StringValue;
            settings[4].dispName = disp4.StringValue;
            settings[5].dispName = disp5.StringValue;
            settings[6].dispName = disp6.StringValue;
            settings[7].dispName = disp7.StringValue;
            settings[8].dispName = disp8.StringValue;
            settings[9].dispName = disp9.StringValue;

            rootViewController.ReSetSettingMenu();
            DismissViewController(this);

        }
    }
}

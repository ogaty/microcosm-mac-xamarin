using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;

namespace microcosm.Views
{
    public partial class SettingDispAspectPlanetViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;

        private ViewController rootViewController;

        #region Constructors

        // Called when created from unmanaged code
        public SettingDispAspectPlanetViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingDispAspectPlanetViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingDispAspectPlanetViewController() : base("SettingDispAspectPlanetView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            rootViewController = (ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController;

            config = rootViewController.config;

        }

        //strongly typed view accessor
        public new SettingDispAspectPlanetView View
        {
            get
            {
                return (SettingDispAspectPlanetView)base.View;
            }
        }
    }
}

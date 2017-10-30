using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;

namespace microcosm.Views
{
    public partial class SettingOrbsViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;
        private int settingIndex;
        private int planetIndex;

        private ViewController rootViewController;


        #region Constructors

        // Called when created from unmanaged code
        public SettingOrbsViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingOrbsViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingOrbsViewController() : base("SettingOrbsView", NSBundle.MainBundle)
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
            settings = rootViewController.settings;
            settingIndex = rootViewController.settingIndex;
            planetIndex = (int)OrbsCombo.SelectedIndex;

            for (int i = 0; i < 10; i++)
            {
                NSString obj = new NSString(settings[i].dispName);
                SettingsCombo.Add(obj);
            }

            SettingsCombo.SelectItem(settingIndex);

            if (planetIndex == -1)
            {
                planetIndex = 0;
                OrbsCombo.SelectItem(planetIndex);
            }

            ReRender();

        }

        private void ReRender()
        {
            
        }

        //strongly typed view accessor
        public new SettingOrbsView View
        {
            get
            {
                return (SettingOrbsView)base.View;
            }
        }
    }
}

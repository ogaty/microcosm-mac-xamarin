using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using microcosm.Config;
using microcosm.Common;
using microcosm.Models;

namespace microcosm.Views
{
    public partial class SettingDispAspectCategoryViewController : AppKit.NSViewController
    {
        private ConfigData config;
        private SettingData[] settings;
        private int settingIndex;
        private int planetIndex;

        private ViewController rootViewController;


        #region Constructors

        // Called when created from unmanaged code
        public SettingDispAspectCategoryViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SettingDispAspectCategoryViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SettingDispAspectCategoryViewController() : base("SettingDispAspectCategoryView", NSBundle.MainBundle)
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
            planetIndex = (int)RingsCombo.SelectedIndex;

            SettingsCombo.RemoveAllItems();
            for (int i = 0; i < 10; i++)
            {
                NSString obj = new NSString(settings[i].dispName);
                SettingsCombo.AddItem(obj);
            }

            SettingsCombo.SelectItem(settingIndex);

            if (planetIndex == -1)
            {
                planetIndex = 0;
                RingsCombo.SelectItem(planetIndex);
            }

            ReRender();

        }

        private void ReRender()
        {
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.CONJUNCTION] == true)
            {
                dispAspectConjunction.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.OPPOSITION] == true)
            {
                dispAspectOpposition.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.TRINE] == true)
            {
                dispAspectTrine.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SQUARE] == true)
            {
                dispAspectSquare.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SEXTILE] == true)
            {
                dispAspectSextile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.INCONJUNCT] == true)
            {
                dispAspectInconjunct.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SESQUIQUADRATE] == true)
            {
                dispAspectSesquiquadrate.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SEMISQUARE] == true)
            {
                dispAspectSemiSquare.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SEMISEXTILE] == true)
            {
                dispAspectSemiSextile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SEMIQINTILE] == true)
            {
                dispAspectSemiQuintile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.NOVILE] == true)
            {
                dispAspectNovile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.SEPTILE] == true)
            {
                dispAspectSeptile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.QUINTILE] == true)
            {
                dispAspectQuintile.State = NSCellStateValue.On;
            }
            if (settings[settingIndex].dispAspectCategory[planetIndex][AspectKind.BIQUINTILE] == true)
            {
                dispAspectBiQuintile.State = NSCellStateValue.On;
            }

        }

        partial void RingsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void SettingsComboChanged(NSObject sender)
        {
            ReRender();
        }

        partial void SubmitButtonClicked(NSObject sender)
        {

        }

        //strongly typed view accessor
        public new SettingDispAspectCategoryView View
        {
            get
            {
                return (SettingDispAspectCategoryView)base.View;
            }
        }
    }
}

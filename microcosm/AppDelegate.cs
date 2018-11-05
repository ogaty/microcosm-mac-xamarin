using System;
using AppKit;
using Foundation;
using microcosm.Common;
using microcosm.Config;

namespace microcosm
{
    [Register("AppDelegate")]
    public partial class AppDelegate : NSApplicationDelegate
    {
        public NSWindow window;
        public SettingsViewController settingWindow;
        public ConfigData config;
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        public override bool ApplicationShouldHandleReopen(NSApplication sender, bool hasVisibleWindows)
        {
			if (hasVisibleWindows) {
//                var mainWindow = new ViewController();
//                sender.MainWindow. .ShowWindow(this);
			}

            return true;
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
			return true;
        }

        public override NSApplicationTerminateReply ApplicationShouldTerminate(NSApplication sender)
        {
            return NSApplicationTerminateReply.Now;
        }

        partial void SettingMenuClick(NSObject sender)
        {
            
        }

        partial void SingleRingClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.SingleRingClicked();
        }

        partial void SingleRingTClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.SingleRingTClicked();
        }

        partial void DualRingNNClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.DualRingNNClicked();
        }

        partial void DualRingNTClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.DualRingNTClicked();
        }

        partial void TripleRingClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.TripleRingClicked();
        }

        partial void TripleRingNTTClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.TripleRingNTTClicked();
        }

        partial void FourthRingNPTTClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.FourthRingNPTTClicked();
        }

        partial void FifthRingNPNPTClicked(NSObject sender)
        {
            CommonInstance.getInstance().controller.FifthRingNPNPTClicked();
        }

    }
}

using AppKit;
using Foundation;
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


    }
}

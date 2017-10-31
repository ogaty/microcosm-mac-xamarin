using System;
using System.IO;
using System.IO.IsolatedStorage;
using AppKit;
using Foundation;
using microcosm.Calc;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using SwissEphNet;

namespace microcosm
{
    public partial class ViewController : NSViewController
    {
        NSObject NSWindowDidResizeNotificationObject;

        public AstroCalc calc;
        public ConfigData config;
        public SettingData[] settings;
        public int settingIndex = 0;

        public UserData udata1 = new UserData();
        public UserData udata2 = new UserData();
        public UserData edata1 = new UserData();
        public UserData edata2 = new UserData();

        public Calcuration[] ringsData = new Calcuration[7];


        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSWindowDidResizeNotificationObject = NSNotificationCenter.DefaultCenter.AddObserver(new NSString("NSWindowDidResizeNotification"), ResizeObserver, null);
            MainInit();
        }

        public void ResizeObserver(NSNotification notify)
        {
            var r = this.View.Frame;
            Console.WriteLine("{0}:{1}:{2}", notify.Name, r.Height, r.Width);
        }

        /// <summary>
        /// 初期化周り
        /// </summary>
        private void MainInit() 
        {
            var root = Util.root;
            if (!Directory.Exists(root + "/system"))
            {
                Directory.CreateDirectory(root + "/system");
            }
            if (!Directory.Exists(root + "/data"))
            {
                Directory.CreateDirectory(root + "/data");
            }

            var bundle = Path.Combine(NSBundle.MainBundle.BundlePath, "Contents", "Resources", "system");

            if (!File.Exists(root + "/system/config.csm"))
            {
                File.Copy(bundle + "/config.csm", root + "/system/config.csm");
            }

            for (int i = 0; i < 10; i++)
            {
                if (!File.Exists(root + "/system/setting" + i.ToString() + ".csm"))
                {
                    File.Copy(bundle + "/setting" + i.ToString() + ".csm", root + "/system/setting" + i.ToString() + ".csm");
                }
            }

            config = ConfigFromXml.GetConfigFromXml(root + "/system/config.csm");
            settings = new SettingData[10];
            for (int i = 0; i < 10; i++) {
                settings[i] = SettingFromXml.GetSettingFromXml(root + "/system/setting" + i.ToString() + ".csm", i);
            }
            /*
            CommonInstance.getInstance().config = config;
            CommonInstance.getInstance().settings = settings;
            */

            calc = new AstroCalc();
            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] = 
                calc.ReCalc(config, settings[0], new UserData());

//            Console.WriteLine(config.defaultPlace);
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        public override void AwakeFromNib()
        {
			base.AwakeFromNib();

            testButton.Activated += (object sender, EventArgs e) =>
            {
                DbUserTableDataSource dataSource = userDbTable.DataSource as DbUserTableDataSource;
                dataSource.dataList.RemoveAt(0);
                dataSource.dataList.Add(new DbUserTableData("bbb", DateTime.Now));
                userDbTable.ReloadData();
			};
			
            DbUserTableDataSource DataSource = new DbUserTableDataSource();
            DataSource.dataList.Add(new DbUserTableData("aaa", DateTime.Now));

            userDbTable.DataSource = DataSource;
            userDbTable.Delegate = new DbUserTableDelegate(DataSource);
        }

        //public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);
        //    switch (segue.Identifier)
        //    {
        //        case "SettingSegue":
        //            var settingWindow = segue.DestinationController as SettingsViewController;
        //            settingWindow.Title = "設定";
        //            settingWindow.config = config;
        //            settingWindow.settings = settings;
        //            break;
        //    }
        //}


    }
}

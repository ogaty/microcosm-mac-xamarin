using System;
using System.IO;
using System.IO.IsolatedStorage;
using AppKit;
using Foundation;
using microcosm.Calc;
using microcosm.Common;
using microcosm.Config;
using SwissEphNet;

namespace microcosm
{
    public partial class ViewController : NSViewController
    {
        public AstroCalc calc;
        public ConfigData config;
        public SettingData[] settings;


        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            MainInit();
            /*
            Console.WriteLine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));


            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var directoryname = Path.Combine(documents, "Library/Containers/jp.ogatism.microcosm/Data/Documents/NewDir");
            Console.WriteLine(directoryname);

            var directoryname2 = Path.Combine(documents, "NewDir");
            Directory.CreateDirectory(directoryname2);

            string fileName = "semo18.se1";
            string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);

            Console.WriteLine(localHtmlUrl);
            this.calc = new AstroCalc(this);
            calc.PositionCalc(9.0);

            var file = IsolatedStorageFile.GetUserStoreForApplication();


            var path = Path.Combine(NSBundle.MainBundle.BundlePath, "Contents", "Resources", "system");
            System.IO.File.ReadAllText(path + "/config.csm");

            var path2 = Util.ContainerDirectory + "/Documents";
            Console.WriteLine("dir:" + path2);
            Directory.CreateDirectory(path2 + "/testDir");
            */
        }

        /// <summary>
        /// 初期化周り
        /// </summary>
        private void MainInit() 
        {
            var root = Util.ContainerDirectory + "/Documents/microcosm";
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
            ((AppDelegate)NSApplication.SharedApplication.Delegate).config = config;

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

        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            switch (segue.Identifier)
            {
                case "SettingSegue":
                    var settingWindow = segue.DestinationController as SettingsViewController;
                    settingWindow.Title = "設定";
                    settingWindow.config = config;
                    settingWindow.settings = settings;
                    break;
            }
        }


    }
}

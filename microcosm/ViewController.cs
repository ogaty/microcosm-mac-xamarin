using System;
using System.IO;
using System.IO.IsolatedStorage;
using AppKit;
using Foundation;
using microcosm.Calc;
using microcosm.Common;
using microcosm.Config;
using microcosm.Models;
using microcosm.Views;
using SkiaSharp;
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

        /// <summary>
        /// Resize event
        /// </summary>
        /// <param name="notify">Notify.</param>
        public void ResizeObserver(NSNotification notify)
        {
            var r = this.View.Frame;
            Console.WriteLine("{0}:{1}:{2}", notify.Name, r.Height, r.Width);

            NSTextView v = new NSTextView();

//            ChartBox.SetFrameSize(new CoreGraphics.CGSize(200, 200));
//            ChartBoxView.SetFrameSize(new CoreGraphics.CGSize(200, 200));

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

            User1Name.StringValue = "現在時刻";
            User1Date.StringValue = DateTime.Now.ToString();
            User2Name.StringValue = "現在時刻";
            User2Date.StringValue = DateTime.Now.ToString();
            Event1Name.StringValue = "現在時刻";
            Event1Date.StringValue = DateTime.Now.ToString();
            Event2Name.StringValue = "現在時刻";
            Event2Date.StringValue = DateTime.Now.ToString();
            CuspListDataSource CDataSource = new CuspListDataSource();
            for (int i = 1; i <= 12; i++)
            {
                CDataSource.list.Add(new CuspListData() {
                    Degree1 = ringsData[0].cusps[i],
                    Degree2 = ringsData[1].cusps[i],
                    Degree3 = ringsData[2].cusps[i]
                });
            }

            CuspList.DataSource = CDataSource;
            CuspList.Delegate = new CuspListDelegate(CDataSource);

            canvas.AddSubview(new CanvasView());


            SKImageInfo info = new SKImageInfo(200, 200);
            SKSurface surface = SKSurface.Create(info);
            SKCanvas canvas1 = surface.Canvas;

            canvas1.Clear();

            // Translate to center
            canvas1.Translate(info.Width / 2, info.Height / 2);

            // Draw the circle
            float radius = Math.Min(info.Width, info.Height) / 3;
            canvas1.DrawCircle(0, 0, radius, new SKPaint());
            SKData d = surface.Snapshot().Encode();

            string html = "";
            using (StreamReader reader = new StreamReader(bundle + "/canvas.html")) {
                html = reader.ReadToEnd();
            }
            web.LoadHtmlString(html, null);
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

        partial void scriptButtonClicked(NSObject sender)
        {
            web.EvaluateJavaScript((NSString)@"msg();", (result, error) =>
            {

            });

        }

    }
}

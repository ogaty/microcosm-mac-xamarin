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
using Newtonsoft.Json;
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

        public Calculation[] ringsData = new Calculation[7];


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

            ReSetUserBox();
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

            /*
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
            */

            // ホロスコープ描画
            string html = "";
            using (StreamReader reader = new StreamReader(bundle + "/canvas.html")) {
                html = reader.ReadToEnd();
            }
            var sunJson = JsonConvert.SerializeObject(ringsData[0].planetData[0]);
            var moonJson = JsonConvert.SerializeObject(ringsData[0].planetData[1]);
            var mercuryJson = JsonConvert.SerializeObject(ringsData[0].planetData[2]);
            var venusJson = JsonConvert.SerializeObject(ringsData[0].planetData[3]);
            var marsJson = JsonConvert.SerializeObject(ringsData[0].planetData[4]);
            var jupiterJson = JsonConvert.SerializeObject(ringsData[0].planetData[5]);
            var saturnJson = JsonConvert.SerializeObject(ringsData[0].planetData[6]);
            var uranusJson = JsonConvert.SerializeObject(ringsData[0].planetData[7]);
            var neptuneJson = JsonConvert.SerializeObject(ringsData[0].planetData[8]);
            var plutoJson = JsonConvert.SerializeObject(ringsData[0].planetData[9]);
            string planetDegrees = "{" +
                "sun: " + sunJson + "," +
                "moon: " + moonJson + "," +
                "marcury: " + mercuryJson + "," +
                "venus: " + venusJson + "," +
                "mars: " + marsJson + "," +
                "jupiter: " + jupiterJson + "," +
                "saturn: " + saturnJson + "," +
                "uranus: " + uranusJson + "," +
                "neptune: " + neptuneJson + "," +
                "pluto: " + plutoJson + "" +
                "}";

            html = html.Replace("##planetDegrees##", planetDegrees);


            web.LoadHtmlString(html, new NSUrl(new NSString(bundle), true));
            Console.WriteLine(@"file://" + bundle);

            DateSetterDatePicker.DateValue = new NSDate();
            DateSetterCombo.SelectItem(0);

            ReRender();
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

        public void ReRender() 
        {
            web.EvaluateJavaScript((NSString)@"setPlanet(0, 300);", (result, error) =>
            {

            });

            web.EvaluateJavaScript((NSString)@"reRender();", (result, error) =>
            {

            });
        }

        partial void scriptButtonClicked(NSObject sender)
        {
            ReRender();
        }

        public void ReSetUserBox() 
        {
            User1Name.StringValue = udata1.name;
            User1Date.StringValue = udata1.time.ToString("yyyy/MM/dd HH:mm:ss JST");
            User2Name.StringValue = udata2.name;
            User2Date.StringValue = udata2.time.ToString("yyyy/MM/dd HH:mm:ss JST");
            Event1Name.StringValue = edata1.name;
            Event1Date.StringValue = edata1.time.ToString("yyyy/MM/dd HH:mm:ss JST");
            Event2Name.StringValue = edata2.name;
            Event2Date.StringValue = edata2.time.ToString("yyyy/MM/dd HH:mm:ss JST");
        }

        private void DateSetterTime(DateTime date) 
        {
            if (DateSetterCombo.SelectedItem.Title == "ユーザー1")
            {
                udata1.time = date;
            }
            else if (DateSetterCombo.SelectedItem.Title == "ユーザー2")
            {
                udata2.time = date;
            }
            else if (DateSetterCombo.SelectedItem.Title == "イベント1")
            {
                edata1.time = date;
            }
            else if (DateSetterCombo.SelectedItem.Title == "イベント2")
            {
                edata2.time = date;
            }
        }

        partial void DateSetterLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null) {
                return;
            }
            try 
            {
                int day = -1 * int.Parse(DateSetterDay.StringValue);
                int hour = -1 * int.Parse(DateSetterHour.StringValue);
                int minute = -1 * int.Parse(DateSetterMinute.StringValue);
                double second = -1 * double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);
                date = date.AddMinutes(minute);
                date = date.AddHours(hour);
                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        partial void DateSetterRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = int.Parse(DateSetterDay.StringValue);
                int hour = int.Parse(DateSetterHour.StringValue);
                int minute = int.Parse(DateSetterMinute.StringValue);
                double second = double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);
                date = date.AddMinutes(minute);
                date = date.AddHours(hour);
                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        partial void DateSetterDayLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = -1 * int.Parse(DateSetterDay.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        partial void DateSetterDayRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int day = int.Parse(DateSetterDay.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddDays(day);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// 時刻左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterHourLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int hour = -1 * int.Parse(DateSetterHour.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddHours(hour);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        /// <summary>
        /// 時刻右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void DateSetterHourRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int hour = int.Parse(DateSetterHour.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddHours(hour);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
        }

        partial void DateSetterMinuteLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int minute = -1 * int.Parse(DateSetterMinute.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddMinutes(minute);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        partial void DateSetterMinuteRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                int minute = int.Parse(DateSetterMinute.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddMinutes(minute);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }
        }

        partial void DateSetterSecondLeft(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                double second = -1 * double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }

        }

        partial void DateSetterSecondRight(NSObject sender)
        {
            if (DateSetterDatePicker.DateValue == null)
            {
                return;
            }
            try
            {
                double second = double.Parse(DateSetterSecond.StringValue);

                NSDate nsd = DateSetterDatePicker.DateValue;
                DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

                date = date.AddSeconds(second);

                DateSetterTime(date);

                DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
                DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
                ReSetUserBox();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: format error.");
                return;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("ERROR: invalid cast.");
                return;
            }
            if (DateSetterDay.StringValue == "")
            {
                return;
            }

        }

        partial void DateSetterNow(NSObject sender)
        {
            DateTime date = DateTime.Now;
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
            ReSetUserBox();
        }

        partial void DateSetterSet(NSObject sender)
        {
            NSDate nsd = DateSetterDatePicker.DateValue;
            DateTime date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            date = date.AddSeconds(nsd.SecondsSinceReferenceDate);

            DateSetterTime(date);

            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
            DateSetterDatePicker.DateValue = NSDate.FromTimeIntervalSinceReferenceDate((date - reference).TotalSeconds);
            ReSetUserBox();

        }
    }
}

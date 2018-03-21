using System;
using System.Collections.Generic;
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
using SkiaSharp.Views.Mac;
using CoreGraphics;
using System.Linq;

namespace microcosm
{
    public partial class ViewController : NSViewController
    {
        NSObject NSWindowDidResizeNotificationObject;

        public AstroCalc calc;
        public AspectCalc aspect;
        public ConfigData config;
        public SettingData[] settings;
        public int settingIndex = 0;

        public UserData udata1 = new UserData();
        public UserData udata2 = new UserData();
        public UserData edata1 = new UserData();
        public UserData edata2 = new UserData();

        public Calculation[] ringsData = new Calculation[7];
        public List<AspectInfo>[,] aspectsData = new List<AspectInfo>[7,7];


        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSWindowDidResizeNotificationObject = NSNotificationCenter.DefaultCenter.AddObserver(new NSString("NSWindowDidResizeNotification"), ResizeObserver, null);
            MainInit();
            CommonInstance.getInstance().controller = this;
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
                settings[i].bands = 1;
            }
            CommonInstance.getInstance().config = config;
            CommonInstance.getInstance().settings = settings;
            CommonInstance.getInstance().currentSetting = settings[0];

            calc = new AstroCalc();
            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] = 
                calc.ReCalc(config, settings[0], new UserData());

            //            Console.WriteLine(config.defaultPlace);

            // aspect calc
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++) {
                    aspectsData[i,j] = new List<AspectInfo>();
                }
            }
            aspect = new AspectCalc();
            int ringIndexFrom = 0;
            int ringIndexTo = 0;
            aspectsData[ringIndexFrom, ringIndexTo] = aspect.AspectCalcSame(ringsData[0].planetData, ringIndexFrom);

            ReSetUserBox();

            // cuspList
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
            SKCanvasView sk = new SKCanvasView(new CGRect(0, 0, 690, 720));
            sk.PaintSurface += CanvasPaint;
            horoscopeCanvas.AddSubview(sk);
*/

            // time setter
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

        public void CanvasPaint(object sender, SKPaintSurfaceEventArgs e) 
        {
            int CenterX = 580;
            int CenterY = 580;
            float radius = 580;
            float zodiacWidth = 60;
            float centerRadius = 360;
            string[] signs = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };
            string[] planets = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "O", "L" };
            var surface = e.Surface;
            var surfaceWidth = e.Info.Width;
            var surfaceHeight = e.Info.Height;
            SKCanvas cvs = e.Surface.Canvas;
            cvs.Clear();
            SKRect bg = new SKRect(0, 0, CenterX * 2, CenterY * 2);
            SKPaint bgStyle = new SKPaint();
            bgStyle.Color = new SKColor(255, 255, 255, 255);
            cvs.DrawRect(bg, bgStyle);
//            cvs.Translate(50, 50);
            SKPaint lineStyle = new SKPaint();
            lineStyle.Style = SKPaintStyle.Stroke;

            SKPaint p = new SKPaint();
            p.Style = SKPaintStyle.Fill;
            // outer
            cvs.DrawCircle(CenterX, CenterY, radius, lineStyle);
            // inner
            cvs.DrawCircle(CenterX, CenterY, radius - zodiacWidth, lineStyle);

            double offset = 0;
            if (CommonInstance.getInstance().currentSetting.bands == 1) 
            {
                // center
                cvs.DrawCircle(CenterX, CenterY, centerRadius, lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 2) 
            {
                // center
                centerRadius = centerRadius - 80;
                cvs.DrawCircle(CenterX, CenterY, centerRadius, lineStyle);

                offset = (radius - zodiacWidth - centerRadius) / 2;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 3)
            {
                // center
                centerRadius = centerRadius - 80;
                cvs.DrawCircle(CenterX, CenterY, centerRadius, lineStyle);

                offset = (radius - zodiacWidth - centerRadius) / 3;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 2), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 4)
            {
                // center
                centerRadius = centerRadius - 80;
                cvs.DrawCircle(CenterX, CenterY, centerRadius, lineStyle);

                offset = (radius - zodiacWidth - centerRadius) / 4;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 2), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 3), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 5)
            {
                // center
                centerRadius = centerRadius - 80;
                cvs.DrawCircle(CenterX, CenterY, centerRadius, lineStyle);

                offset = (radius - zodiacWidth - centerRadius) / 5;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 2), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 3), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerRadius + offset * 4), lineStyle);
            }


            // house cusps
            Position housePt;
            Position housePtEnd;
            SKPaint lineStyle1 = new SKPaint();
            lineStyle1.StrokeWidth = 2.5F;
            SKPaint lineStyle2 = new SKPaint();
            lineStyle2.PathEffect = SKPathEffect.CreateDash(new[] { 5F, 2F }, 1.0F);
            lineStyle2.StrokeWidth = 1.5F;
            for (int i = 1; i <= 12; i++) 
            {
                housePt = Util.Rotate(radius - zodiacWidth, 0, ringsData[0].cusps[i] - ringsData[0].cusps[1]);
                housePt.x = housePt.x + CenterX;
                housePt.y = -1 * housePt.y + CenterY;
                housePtEnd = Util.Rotate(centerRadius, 0, ringsData[0].cusps[i] - ringsData[0].cusps[1]);
                housePtEnd.x = housePtEnd.x + CenterX;
                housePtEnd.y = -1 * housePtEnd.y + CenterY;
                if (i == 1 || i == 4 || i == 7 || i == 10)
                {
                    cvs.DrawLine((float)housePt.x, (float)housePt.y, (float)housePtEnd.x, (float)housePtEnd.y, lineStyle1);
                }
                else 
                {
                    cvs.DrawLine((float)housePt.x, (float)housePt.y, (float)housePtEnd.x, (float)housePtEnd.y, lineStyle2);
                }
            }

            // sign cusps
            Position signPt;
            Position signPtEnd;
            for (int i = 1; i <= 12; i++)
            {
                signPt = Util.Rotate(radius, 0, 30 * i - ringsData[0].cusps[1]);
                signPt.x = signPt.x + CenterX;
                signPt.y = -1 * signPt.y + CenterY;
                signPtEnd = Util.Rotate(radius - zodiacWidth, 0, 30 * i - ringsData[0].cusps[1]);
                signPtEnd.x = signPtEnd.x + CenterX;
                signPtEnd.y = -1 * signPtEnd.y + CenterY;
                cvs.DrawLine((float)signPt.x, (float)signPt.y, (float)signPtEnd.x, (float)signPtEnd.y, lineStyle);
            }




            // ♈〜♓までのシンボル
            System.Reflection.Assembly asm =
                System.Reflection.Assembly.GetExecutingAssembly();
            SKManagedStream stream = new SKManagedStream(asm.GetManifestResourceStream("microcosm.system.AstroDotBasic.ttf"));
            p.Typeface = SKTypeface.FromStream(stream);
            p.TextSize = 48;
            Position signValuePt;
            SKColor pink = SKColors.Pink;
            p.Color = pink;

            for (int i = 0; i < signs.Length; i++)
            {
                signValuePt = Util.Rotate(radius - 30, 0, 15 + 30 * i - ringsData[0].cusps[1]);
                signValuePt.x = signValuePt.x + CenterX - 15;
                signValuePt.y = -1 * signValuePt.y + CenterY + 20;
                p.Color = CommonData.getSignColor(30 * i);
                cvs.DrawText(signs[i], (float)signValuePt.x, (float)signValuePt.y, p);
            }
            p.Color = SKColors.Black;

            // 天体そのもの
            // 天体度数
            SKPaint degreeText = new SKPaint()
            {
                TextSize = 24,
                Style = SKPaintStyle.Fill
            };
            Position planetPt;
//            Position planetRing;
            Position planetDegreePt;
            int[] box = new int[72];
            int planetOffset = 0;
            IOrderedEnumerable<PlanetData> sortPlanetData = ringsData[0].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
            foreach (PlanetData planet in sortPlanetData)
            {
                if (!CommonInstance.getInstance().currentSetting.dispPlanet[0][planet.no]) 
                {
                    continue;
                }

                // 重ならないようにずらしを入れる
                // 1サインに6度単位5個までデータが入る
                int index = (int)(planet.absolute_position / 5);
                if (box[index] == 1)
                {
                    while (box[index] == 1)
                    {
                        index++;
                        if (index == 72)
                        {
                            index = 0;
                        }
                    }
                    box[index] = 1;
                }
                else
                {
                    box[index] = 1;
                }

                // 天体そのもの
                if (CommonInstance.getInstance().currentSetting.bands == 1)
                {
                    planetOffset = 120;
                }
                else if (CommonInstance.getInstance().currentSetting.bands == 2)
                {
                    planetOffset = 90;
                }
                else if (CommonInstance.getInstance().currentSetting.bands == 3)
                {
                    planetOffset = 240;
                }
                else if (CommonInstance.getInstance().currentSetting.bands == 4)
                {
                    planetOffset = 90;
                }
                else if (CommonInstance.getInstance().currentSetting.bands == 5)
                {
                    planetOffset = 90;
                }

                planetPt = Util.Rotate(radius - planetOffset, 0, 5 * index - ringsData[0].cusps[1]);
//                planetRing = Util.Rotate(radius - 120, 0, planet.absolute_position - ringsData[0].cusps[1] + 3);
                planetPt.x = planetPt.x + CenterX - 5;
                planetPt.y = -1 * planetPt.y + CenterY + 20;
                p.Color = CommonData.getPlanetColor(planet.no);
                cvs.DrawText(CommonData.getPlanetSymbol(planet.no), (float)planetPt.x, (float)planetPt.y, p);

                // 天体度数
                planetDegreePt = Util.Rotate(radius - (planetOffset + 40), 0, 5 * index - ringsData[0].cusps[1]);
                planetDegreePt.x = planetDegreePt.x + CenterX - 10;
                planetDegreePt.y = -1 * planetDegreePt.y + CenterY + 10;
                p.Color = SKColors.Black;
                cvs.DrawText(((int)(planet.absolute_position % 30)).ToString(), (float)planetDegreePt.x, (float)planetDegreePt.y, degreeText);
            }
//            cvs.DrawText(ringsData[0].cusps[1].ToString(), 80, 250, new SKPaint());
            if (CommonInstance.getInstance().currentSetting.bands > 1)
            {
                int[] box2 = new int[72];
                IOrderedEnumerable<PlanetData> sortPlanetData2 = ringsData[1].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
                foreach (PlanetData planet in sortPlanetData2)
                {
                    if (!CommonInstance.getInstance().currentSetting.dispPlanet[0][planet.no])
                    {
                        continue;
                    }

                    // 重ならないようにずらしを入れる
                    // 1サインに6度単位5個までデータが入る
                    int index = (int)(planet.absolute_position / 5);
                    if (box2[index] == 1)
                    {
                        while (box2[index] == 1)
                        {
                            index++;
                            if (index == 72)
                            {
                                index = 0;
                            }
                        }
                        box2[index] = 1;
                    }
                    else
                    {
                        box2[index] = 1;
                    }

                    if (CommonInstance.getInstance().currentSetting.bands == 2)
                    {
                        planetOffset = 90;
                    }
                    else if (CommonInstance.getInstance().currentSetting.bands == 3)
                    {
                        planetOffset = 170;
                    }
                    else if (CommonInstance.getInstance().currentSetting.bands == 4)
                    {
                        planetOffset = 90;
                    }
                    else if (CommonInstance.getInstance().currentSetting.bands == 5)
                    {
                        planetOffset = 90;
                    }


                    planetPt = Util.Rotate(radius - planetOffset, 0, 5 * index - ringsData[0].cusps[1]);
                    //                planetRing = Util.Rotate(radius - 120, 0, planet.absolute_position - ringsData[0].cusps[1] + 3);
                    planetPt.x = planetPt.x + CenterX - 10;
                    planetPt.y = -1 * planetPt.y + CenterY + 20;
                    p.Color = CommonData.getPlanetColor(planet.no);
                    cvs.DrawText(CommonData.getPlanetSymbol(planet.no), (float)planetPt.x, (float)planetPt.y, p);

                    // 天体度数
                    planetDegreePt = Util.Rotate(radius - (planetOffset + 35), 0, 5 * index - ringsData[0].cusps[1]);
                    planetDegreePt.x = planetDegreePt.x + CenterX - 15;
                    planetDegreePt.y = -1 * planetDegreePt.y + CenterY + 10;
                    p.Color = SKColors.Black;
                    cvs.DrawText(((int)(planet.absolute_position % 30)).ToString(), (float)planetDegreePt.x, (float)planetDegreePt.y, degreeText);
                }
            }

            if (CommonInstance.getInstance().currentSetting.bands > 2)
            {
                int[] box3 = new int[72];
                IOrderedEnumerable<PlanetData> sortPlanetData3 = ringsData[2].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
                foreach (PlanetData planet in sortPlanetData3)
                {
                    if (!CommonInstance.getInstance().currentSetting.dispPlanet[0][planet.no])
                    {
                        continue;
                    }

                    // 重ならないようにずらしを入れる
                    // 1サインに6度単位5個までデータが入る
                    int index = (int)(planet.absolute_position / 5);
                    if (box3[index] == 1)
                    {
                        while (box3[index] == 1)
                        {
                            index++;
                            if (index == 72)
                            {
                                index = 0;
                            }
                        }
                        box3[index] = 1;
                    }
                    else
                    {
                        box3[index] = 1;
                    }

                    if (CommonInstance.getInstance().currentSetting.bands == 3)
                    {
                        planetOffset = 90;
                    }
                    else if (CommonInstance.getInstance().currentSetting.bands == 4)
                    {
                        planetOffset = 90;
                    }
                    else if (CommonInstance.getInstance().currentSetting.bands == 5)
                    {
                        planetOffset = 90;
                    }


                    planetPt = Util.Rotate(radius - planetOffset, 0, 5 * index - ringsData[0].cusps[1]);
                    //                planetRing = Util.Rotate(radius - 120, 0, planet.absolute_position - ringsData[0].cusps[1] + 3);
                    planetPt.x = planetPt.x + CenterX - 10;
                    planetPt.y = -1 * planetPt.y + CenterY + 20;
                    p.Color = CommonData.getPlanetColor(planet.no);
                    cvs.DrawText(CommonData.getPlanetSymbol(planet.no), (float)planetPt.x, (float)planetPt.y, p);

                    // 天体度数
                    planetDegreePt = Util.Rotate(radius - (planetOffset + 35), 0, 5 * index - ringsData[0].cusps[1]);
                    planetDegreePt.x = planetDegreePt.x + CenterX - 15;
                    planetDegreePt.y = -1 * planetDegreePt.y + CenterY + 10;
                    p.Color = SKColors.Black;
                    cvs.DrawText(((int)(planet.absolute_position % 30)).ToString(), (float)planetDegreePt.x, (float)planetDegreePt.y, degreeText);
                }
            }

            // aspects
            Position aspectPt;
            Position aspectPtEnd;
            Position aspectSymbolPt;
            SKColor black = SKColors.Black;
            SKColor crimson = SKColors.Crimson;
            SKColor orange = SKColors.Orange;
            SKColor purple = SKColors.Purple;
            SKColor green = SKColors.Green;
            SKPaint aspectLine = new SKPaint();
            aspectLine.Style = SKPaintStyle.Stroke;
            aspectLine.StrokeWidth = 2.0F;
            SKPaint aspectSymboolText = new SKPaint()
            {
                TextSize = 24,
                Style = SKPaintStyle.Fill,
                Typeface = SKTypeface.FromStream(stream)
            };
            for (int i = 0; i < aspectsData[0, 0].Count; i++)
            {
                if (!aspectsData[0, 0][i].isDisp)
                {
                    continue;
                }
                aspectPt = Util.Rotate(centerRadius, 0, aspectsData[0, 0][i].absoluteDegree - ringsData[0].cusps[1]);
                aspectPt.x = aspectPt.x + CenterX;
                aspectPt.y = -1 * aspectPt.y + CenterY;

                aspectPtEnd = Util.Rotate(centerRadius, 0, aspectsData[0, 0][i].targetDegree - ringsData[0].cusps[1]);
                aspectPtEnd.x = aspectPtEnd.x + CenterX;
                aspectPtEnd.y = -1 * aspectPtEnd.y + CenterY;

                aspectSymbolPt = Util.Rotate(radius - 160, 0, aspectsData[0, 0][i].targetDegree - ringsData[0].cusps[1]);
                aspectSymbolPt.x = aspectSymbolPt.x + CenterX;
                aspectSymbolPt.y = -1 * aspectSymbolPt.y + CenterY + 10;


                if (aspectsData[0, 0][i].aspectKind == AspectKind.OPPOSITION)
                {
                    aspectLine.Color = crimson;
                    aspectSymboolText.Color = crimson;
                    cvs.DrawLine((float)aspectPt.x, (float)aspectPt.y, (float)aspectPtEnd.x, (float)aspectPtEnd.y, aspectLine);
                    cvs.DrawText(CommonData.getAspectSymbol(aspectsData[0, 0][i].aspectKind),
                                 (float)((aspectPt.x + aspectPtEnd.x) / 2), (float)((aspectPt.y + aspectPtEnd.y) / 2), aspectSymboolText);
                }
                else if (aspectsData[0, 0][i].aspectKind == AspectKind.TRINE)
                {
                    aspectLine.Color = orange;
                    aspectSymboolText.Color = orange;
                    cvs.DrawLine((float)aspectPt.x, (float)aspectPt.y, (float)aspectPtEnd.x, (float)aspectPtEnd.y, aspectLine);
                    cvs.DrawText(CommonData.getAspectSymbol(aspectsData[0, 0][i].aspectKind),
                                 (float)((aspectPt.x + aspectPtEnd.x) / 2), (float)((aspectPt.y + aspectPtEnd.y) / 2), aspectSymboolText);
                }
                else if (aspectsData[0, 0][i].aspectKind == AspectKind.SQUARE) 
                {
                    aspectLine.Color = purple;
                    aspectSymboolText.Color = purple;
                    cvs.DrawLine((float)aspectPt.x, (float)aspectPt.y, (float)aspectPtEnd.x, (float)aspectPtEnd.y, aspectLine);
                    cvs.DrawText(CommonData.getAspectSymbol(aspectsData[0, 0][i].aspectKind),
                                 (float)((aspectPt.x + aspectPtEnd.x) / 2), (float)((aspectPt.y + aspectPtEnd.y) / 2), aspectSymboolText);
                }
                else if (aspectsData[0, 0][i].aspectKind == AspectKind.SEXTILE)
                {
                    aspectLine.Color = green;
                    aspectSymboolText.Color = green;
                    cvs.DrawLine((float)aspectPt.x, (float)aspectPt.y, (float)aspectPtEnd.x, (float)aspectPtEnd.y, aspectLine);
                    cvs.DrawText(CommonData.getAspectSymbol(aspectsData[0, 0][i].aspectKind),
                                 (float)((aspectPt.x + aspectPtEnd.x) / 2), (float)((aspectPt.y + aspectPtEnd.y) / 2), aspectSymboolText);
                }
                else 
                {
                    aspectSymboolText.Color = green;
                    cvs.DrawLine((float)aspectPt.x, (float)aspectPt.y, (float)aspectPtEnd.x, (float)aspectPtEnd.y, lineStyle);
                    cvs.DrawText(CommonData.getAspectSymbol(aspectsData[0, 0][i].aspectKind),
                                 (float)((aspectPt.x + aspectPtEnd.x) / 2), (float)((aspectPt.y + aspectPtEnd.y) / 2), aspectSymboolText);
                }
            }
            cvs.Flush();

        }

        public void ReRender() 
        {
            if (horoscopeCanvas.Subviews.Count() > 0) 
            {
                horoscopeCanvas.Subviews[0].RemoveFromSuperview();
            }
            SKCanvasView sk = new SKCanvasView(new CGRect(0, 0, 580, 580));
            sk.PaintSurface += CanvasPaint;
            horoscopeCanvas.AddSubview(sk);
        }

        partial void scriptButtonClicked(NSObject sender)
        {

//            ReRender();
        }

        /// <summary>
        /// ユーザーボックスに再度バインディング
        /// </summary>
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

        /// <summary>
        /// ユーザーデータにデータを設定
        /// </summary>
        /// <param name="date">Date.</param>
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

        /// <summary>
        /// 左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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

        /// <summary>
        /// 右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
        /// Day 左ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
        /// Day 右ボタン
        /// </summary>
        /// <param name="sender">Sender.</param>
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
                ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                    calc.ReCalc(config, settings[0], udata1);
                ReRender();
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
            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] =
                calc.ReCalc(config, settings[0], udata1);
            ReRender();

        }

        public void SingleRingClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 1;
            ReRender();
        }

        public void TripleRingClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 3;
            ReRender();
        }
    }
}

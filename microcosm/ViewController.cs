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
        const int USER1 = 1;
        const int USER2 = 2;
        const int EVENT1 = 3;
        const int EVENT2 = 4;

        public int CenterX = 580;
        public int CenterY = 580;
        // 外側の直径
        public float diameter = 580;
        public float zodiacWidth = 60;
        // 中心円
        public float centerDiameterBase = 360;


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
            CommonInstance.getInstance().currentSettingIndex = 0;

            ReSetSettingMenu();

            calc = new AstroCalc();
            ringsData[0] = ringsData[1] = ringsData[2] = ringsData[3] = ringsData[4] = ringsData[5] = ringsData[6] = 
                calc.ReCalc(config, settings[0], new UserData());

            //            Console.WriteLine(config.defaultPlace);

            // aspect calc
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    aspectsData[i,j] = new List<AspectInfo>();
                }
            }
            aspect = new AspectCalc();
            foreach (int i in Enumerable.Range(0, 4))
            {
                aspectsData[i, i] = aspect.AspectCalcSame(ringsData[i].planetData, i);
            }

            int ringIndexFrom = 0;
            int ringIndexTo = 0;
            for (ringIndexFrom = 0; ringIndexFrom < 5; ringIndexFrom++)
            {
                for (ringIndexTo = 0; ringIndexTo < 5; ringIndexTo++)
                {
                    if (ringIndexFrom == ringIndexTo) continue;
                    aspectsData[ringIndexFrom, ringIndexTo] =
                        aspect.AspectCalcOther(ringsData[ringIndexFrom].planetData,
                                               ringsData[ringIndexTo].planetData, 
                                               ringIndexFrom,
                                               ringIndexTo);
                }
            }

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
            cvs.DrawCircle(CenterX, CenterY, diameter, lineStyle);
            // inner
            cvs.DrawCircle(CenterX, CenterY, diameter - zodiacWidth, lineStyle);

            double offset = 0;
            float centerDiameter = centerDiameterBase;
            // ring描画
            if (CommonInstance.getInstance().currentSetting.bands == 1) 
            {
                // center
                cvs.DrawCircle(CenterX, CenterY, centerDiameter, lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 2) 
            {
                // center
                // 中心円を少し縮める
                centerDiameter = centerDiameterBase - 80;
                cvs.DrawCircle(CenterX, CenterY, centerDiameter, lineStyle);

                offset = (diameter - zodiacWidth - centerDiameter) / 2;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 3)
            {
                // center
                // 中心円を少し縮める
                centerDiameter = centerDiameterBase - 80;
                cvs.DrawCircle(CenterX, CenterY, centerDiameter, lineStyle);

                offset = (diameter - zodiacWidth - centerDiameter) / 3;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 2), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 4)
            {
                // center
                // 中心円を少し縮める
                centerDiameter = centerDiameterBase - 80;
                cvs.DrawCircle(CenterX, CenterY, centerDiameter, lineStyle);

                offset = (diameter - zodiacWidth - centerDiameter) / 4;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 2), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 3), lineStyle);
            }
            else if (CommonInstance.getInstance().currentSetting.bands == 5)
            {
                // center
                // 中心円を少し縮める
                centerDiameter = centerDiameterBase - 80;
                cvs.DrawCircle(CenterX, CenterY, centerDiameter, lineStyle);

                offset = (diameter - zodiacWidth - centerDiameter) / 5;
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 2), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 3), lineStyle);
                cvs.DrawCircle(CenterX, CenterY, (float)(centerDiameter + offset * 4), lineStyle);
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
                housePt = Util.Rotate(diameter - zodiacWidth, 0, ringsData[0].cusps[i] - ringsData[0].cusps[1]);
                housePt.x = housePt.x + CenterX;
                housePt.y = -1 * housePt.y + CenterY;
                housePtEnd = Util.Rotate(centerDiameter, 0, ringsData[0].cusps[i] - ringsData[0].cusps[1]);
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
                signPt = Util.Rotate(diameter, 0, 30 * i - ringsData[0].cusps[1]);
                signPt.x = signPt.x + CenterX;
                signPt.y = -1 * signPt.y + CenterY;
                signPtEnd = Util.Rotate(diameter - zodiacWidth, 0, 30 * i - ringsData[0].cusps[1]);
                signPtEnd.x = signPtEnd.x + CenterX;
                signPtEnd.y = -1 * signPtEnd.y + CenterY;
                cvs.DrawLine((float)signPt.x, (float)signPt.y, (float)signPtEnd.x, (float)signPtEnd.y, lineStyle);
            }

            System.Reflection.Assembly asm =
                System.Reflection.Assembly.GetExecutingAssembly();
            SKManagedStream stream = new SKManagedStream(asm.GetManifestResourceStream("microcosm.system.AstroDotBasic.ttf"));
            {
                // ♈〜♓までのシンボル
                p.Typeface = SKTypeface.FromStream(stream);
                p.TextSize = 48;
                Position signValuePt;
                SKColor pink = SKColors.Pink;
                p.Color = pink;
                for (int i = 0; i < signs.Length; i++)
                {
                    signValuePt = Util.Rotate(diameter - 30, 0, 15 + 30 * i - ringsData[0].cusps[1]);
                    signValuePt.x = signValuePt.x + CenterX - 15;
                    signValuePt.y = -1 * signValuePt.y + CenterY + 20;
                    p.Color = CommonData.getSignColor(30 * i);
                    cvs.DrawText(signs[i], (float)signValuePt.x, (float)signValuePt.y, p);
                }
                p.Color = SKColors.Black;
            }

 
            // 天体そのもの
            // 天体度数
            SKPaint degreeText = new SKPaint()
            {
                TextSize = 24,
                Style = SKPaintStyle.Fill
            };
            int[] box = new int[72];
            int planetOffset = 0;
            IOrderedEnumerable<PlanetData> sortPlanetData = ringsData[0].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
            foreach (PlanetData planet in sortPlanetData)
            {
                if (!CommonInstance.getInstance().currentSetting.dispPlanet[0][planet.no]) 
                {
                    continue;
                }

                #region createbox1
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
                #endregion

                // 天体そのもの
                planetOffset = GetPlanetOffset(1);
                DrawPlanetText(index, ringsData[0].cusps[1], planet, p, cvs, degreeText, planetOffset, 40, 5, 20, 10, 10);
            }
//            cvs.DrawText(ringsData[0].cusps[1].ToString(), 80, 250, new SKPaint());
            // 二重円
            if (CommonInstance.getInstance().currentSetting.bands > 1)
            {
                int[] box2 = new int[72];
                IOrderedEnumerable<PlanetData> sortPlanetData2 = ringsData[1].planetData.OrderBy(planetTmp => planetTmp.absolute_position);
                foreach (PlanetData planet in sortPlanetData2)
                {
                    if (!CommonInstance.getInstance().currentSetting.dispPlanet[1][planet.no])
                    {
                        continue;
                    }

                    #region createbox2
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
                    #endregion

                    planetOffset = GetPlanetOffset(2);
                    DrawPlanetText(index, ringsData[1].cusps[1], planet, p, cvs, degreeText, planetOffset, 35, 10, 20, 15, 10);
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
                    #region create box3
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
                    #endregion

                    planetOffset = GetPlanetOffset(3);
                    DrawPlanetText(index, ringsData[2].cusps[1], planet, p, cvs, degreeText, planetOffset, 35, 10, 20, 15, 10);
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
                Style = SKPaintStyle.Fill
            };
            // aspectsData[0, 0] => natal-natal
            for (int i = 0; i < aspectsData[0, 0].Count; i++)
            {
                if (!aspectsData[0, 0][i].isDisp)
                {
                    Console.WriteLine(String.Format("{0} nodisp", i.ToString()));
                    continue;
                }
                aspectPt = Util.Rotate(centerDiameter, 0, aspectsData[0, 0][i].absoluteDegree - ringsData[0].cusps[1]);
                aspectPt.x = aspectPt.x + CenterX;
                aspectPt.y = -1 * aspectPt.y + CenterY;

                aspectPtEnd = Util.Rotate(centerDiameter, 0, aspectsData[0, 0][i].targetDegree - ringsData[0].cusps[1]);
                aspectPtEnd.x = aspectPtEnd.x + CenterX;
                aspectPtEnd.y = -1 * aspectPtEnd.y + CenterY;

                aspectSymbolPt = Util.Rotate(diameter - 160, 0, aspectsData[0, 0][i].targetDegree - ringsData[0].cusps[1]);
                aspectSymbolPt.x = aspectSymbolPt.x + CenterX;
                aspectSymbolPt.y = -1 * aspectSymbolPt.y + CenterY + 10;

                GetAspectLineAndText(aspectsData[0, 0][i].aspectKind, ref aspectLine, ref aspectSymboolText);
                DrawAspect(cvs, aspectsData[0, 1][i], aspectPt, aspectPtEnd, aspectLine, degreeText);

            }
            if (CommonInstance.getInstance().currentSetting.bands > 1)
            {
                offset = (diameter - zodiacWidth - centerDiameter) / CommonInstance.getInstance().currentSetting.bands;

                // aspectsData[0, 1] => natal-progress
                for (int i = 0; i < aspectsData[0, 1].Count; i++)
                {
                    if (!aspectsData[0, 1][i].isDisp)
                    {
                        Console.WriteLine(String.Format("{0} nodisp", i.ToString()));
                        continue;
                    }
                    aspectPt = Util.Rotate(centerDiameter, 0, aspectsData[0, 1][i].absoluteDegree - ringsData[0].cusps[1]);
                    aspectPt.x = aspectPt.x + CenterX;
                    aspectPt.y = -1 * aspectPt.y + CenterY;

                    aspectPtEnd = Util.Rotate(centerDiameter + offset, 0, aspectsData[0, 1][i].targetDegree - ringsData[0].cusps[1]);
                    aspectPtEnd.x = aspectPtEnd.x + CenterX;
                    aspectPtEnd.y = -1 * aspectPtEnd.y + CenterY;

                    aspectSymbolPt = Util.Rotate(diameter - 160, 0, aspectsData[0, 1][i].targetDegree - ringsData[0].cusps[1]);
                    aspectSymbolPt.x = aspectSymbolPt.x + CenterX;
                    aspectSymbolPt.y = -1 * aspectSymbolPt.y + CenterY + 10;


                    GetAspectLineAndText(aspectsData[0, 1][i].aspectKind, ref aspectLine, ref aspectSymboolText);
                    DrawAspect(cvs, aspectsData[0, 1][i], aspectPt, aspectPtEnd, aspectLine, degreeText);
                }
                for (int i = 0; i < aspectsData[1, 1].Count; i++)
                {
                    if (!aspectsData[1, 1][i].isDisp)
                    {
                        Console.WriteLine(String.Format("{0} nodisp", i.ToString()));
                        continue;
                    }
                    aspectPt = Util.Rotate(centerDiameter + offset, 0, aspectsData[0, 1][i].absoluteDegree - ringsData[0].cusps[1]);
                    aspectPt.x = aspectPt.x + CenterX;
                    aspectPt.y = -1 * aspectPt.y + CenterY;

                    aspectPtEnd = Util.Rotate(centerDiameter + offset, 0, aspectsData[0, 1][i].targetDegree - ringsData[0].cusps[1]);
                    aspectPtEnd.x = aspectPtEnd.x + CenterX;
                    aspectPtEnd.y = -1 * aspectPtEnd.y + CenterY;

                    aspectSymbolPt = Util.Rotate(diameter - 160, 0, aspectsData[0, 1][i].targetDegree - ringsData[0].cusps[1]);
                    aspectSymbolPt.x = aspectSymbolPt.x + CenterX;
                    aspectSymbolPt.y = -1 * aspectSymbolPt.y + CenterY + 10;


                    GetAspectLineAndText(aspectsData[1, 1][i].aspectKind, ref aspectLine, ref aspectSymboolText);
                    DrawAspect(cvs, aspectsData[1, 1][i], aspectPt, aspectPtEnd, aspectLine, degreeText);
                }

            }
            cvs.Flush();

        }

        public void GetAspectLineAndText(AspectKind kind, ref SKPaint line, ref SKPaint symbol)
        {
            if (kind == AspectKind.OPPOSITION)
            {
                line.Color = SKColors.Crimson;
                symbol.Color = SKColors.Crimson;
            }
            else if (kind == AspectKind.TRINE)
            {
                line.Color = SKColors.Orange;
                symbol.Color = SKColors.Orange;
            }
            else if (kind == AspectKind.SQUARE)
            {
                line.Color = SKColors.Purple;
                symbol.Color = SKColors.Purple;
            }
            else if (kind == AspectKind.SEXTILE)
            {
                line.Color = SKColors.Green;
                symbol.Color = SKColors.Green;
            }
        }

        public void DrawAspect(SKCanvas cvs, AspectInfo info, Position from, Position to, SKPaint aspectLine, SKPaint symbol)
        {
            cvs.DrawLine((float)from.x, (float)from.y, (float)to.x, (float)to.y, aspectLine);
            cvs.DrawText(CommonData.getAspectSymbol(info.aspectKind),
             (float)((from.x + to.x) / 2), (float)((from.y + to.y) / 2), symbol);
            
        }

        public void ReRender() 
        {
            if (horoscopeCanvas.Subviews.Count() > 0) 
            {
                horoscopeCanvas.Subviews[0].RemoveFromSuperview();
            }
            CanvasView sk = new CanvasView(new CGRect(0, 0, 580, 580));
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

        public void ReCalcAll()
        {
            ringsData[0] = ringsData[3] = 
                ringsData[4] = ringsData[5] = ringsData[6] = calc.ReCalc(config, settings[0], udata1);

            ReCalcUserDbProgress(1, EVENT1);
            ReCalcUserDb(2, EVENT1);

            foreach (int i in Enumerable.Range(0, 4))
            {
                aspectsData[i, i] = aspect.AspectCalcSame(ringsData[i].planetData, i);
            }

            int ringIndexFrom = 0;
            int ringIndexTo = 0;
            for (ringIndexFrom = 0; ringIndexFrom < 5; ringIndexFrom++)
            {
                for (ringIndexTo = 0; ringIndexTo < 5; ringIndexTo++)
                {
                    if (ringIndexFrom == ringIndexTo) continue;
                    aspectsData[ringIndexFrom, ringIndexTo] = 
                        aspect.AspectCalcOther(ringsData[ringIndexFrom].planetData, 
                                               ringsData[ringIndexTo].planetData, 
                                               ringIndexFrom, ringIndexTo);
                }
            }
        }

        /// <summary>
        /// DBからReCalcを受ける
        /// </summary>
        /// <param name="index">ring index</param>
        /// <param name="type">1:u1 2:u2 3:e1 4:e2</param>
        public void ReCalcUserDb(int index, int type) 
        {
            switch (type) {
                case USER1:
                    ringsData[index] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
                    break;
                case USER2:
                    ringsData[index] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata2);
                    break;
                case EVENT1:
                    ringsData[index] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
                    break;
                case EVENT2:
                    ringsData[index] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata2);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// DBからReCalcを受ける(プログレス)
        /// </summary>
        /// <param name="index">ring index</param>
        /// <param name="type">1:u1 2:u2 3:e1 4:e2</param>
        public void ReCalcUserDbProgress(int index, int type)
        {
            switch (type)
            {
                case USER1:
                    ringsData[index] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, udata1);
                    break;
                case USER2:
                    ringsData[index] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, udata2);
                    break;
                case EVENT1:
                    ringsData[index] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata1);
                    break;
                case EVENT2:
                    ringsData[index] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata2);
                    break;
                default:
                    break;
            }
        }

        public void SingleRingClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 1;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ReRender();
        }

        public void SingleRingTClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 1;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ReRender();
        }

        public void DualRingNNClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 2;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata2);
            ReRender();
        }

        public void DualRingNTClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 2;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ReRender();
        }

        public void TripleRingClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 3;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata1);
            ringsData[2] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ReRender();
        }

        public void TripleRingNTTClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 3;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ringsData[2] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata2);
            ReRender();
        }

        public void FourthRingNPTTClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 4;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata1);
            ringsData[2] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ringsData[3] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata2);
            ReRender();
        }

        public void FifthRingNPNPTClicked()
        {
            CommonInstance.getInstance().currentSetting.bands = 5;
            ringsData[0] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata1);
            ringsData[1] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata1);
            ringsData[2] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, udata2);
            ringsData[3] = calc.ReCalcProgress(config, CommonInstance.getInstance().currentSetting, edata2);
            ringsData[4] = calc.ReCalc(config, CommonInstance.getInstance().currentSetting, edata1);
            ReRender();
        }

        public void SetUserData(UserTableData tableData, int type)
        {
            switch (type)
            {
                case 1:
                    udata1.name = tableData.name;
                    udata1.time = tableData.date;
                    break;
                case 2:
                    udata2.name = tableData.name;
                    udata2.time = tableData.date;
                    break;
                case 3:
                    edata1.name = tableData.name;
                    edata1.time = tableData.date;
                    break;
                case 4:
                    edata2.name = tableData.name;
                    edata2.time = tableData.date;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 天体表示
        /// </summary>
        /// <param name="index">boxIndex</param>
        /// <param name="cusp0">cusps[0]</param>
        /// <param name="planet">Planet.</param>
        /// <param name="p">SKPaintインスタンス</param>
        /// <param name="cvs">SKCanvasインスタンス</param>
        /// <param name="degreeText">Degree text.</param>
        /// <param name="planetOffset">Planet offset.</param>
        /// <param name="planetROffset">Planet RO ffset.</param>
        /// <param name="textXoffset">Text xoffset.</param>
        /// <param name="textYoffset">Text yoffset.</param>
        /// <param name="degreeXoffset">Degree xoffset.</param>
        /// <param name="degreeYoffset">Degree yoffset.</param>
        public void DrawPlanetText(int index, double cusp0, PlanetData planet, SKPaint p, SKCanvas cvs, SKPaint degreeText,
                                   int planetOffset, int planetROffset, 
                                   int textXoffset, int textYoffset, int degreeXoffset, int degreeYoffset)
        {
            Position planetPt;
            Position planetDegreePt;
            Position planetRetrogradePt;

            planetPt = Util.Rotate(diameter - planetOffset, 0, 5 * index - cusp0);
            planetPt.x = planetPt.x + CenterX - textXoffset;
            planetPt.y = -1 * planetPt.y + CenterY + textYoffset;
            p.Color = CommonData.getPlanetColor(planet.no);
            cvs.DrawText(CommonData.getPlanetSymbol(planet.no), (float)planetPt.x, (float)planetPt.y, p);

            // 天体度数
            planetDegreePt = Util.Rotate(diameter - (planetOffset + planetROffset), 0, 5 * index - cusp0);
            planetDegreePt.x = planetDegreePt.x + CenterX - degreeXoffset;
            planetDegreePt.y = -1 * planetDegreePt.y + CenterY + degreeYoffset;
            p.Color = SKColors.Black;
            cvs.DrawText(((int)(planet.absolute_position % 30)).ToString(), (float)planetDegreePt.x, (float)planetDegreePt.y, degreeText);

            // 逆行
            if (planet.speed < 0)
            {
                planetRetrogradePt = Util.Rotate(diameter - 25 - (planetOffset + planetROffset), 0, 5 * index - cusp0);
                planetRetrogradePt.x = planetRetrogradePt.x + CenterX - degreeXoffset;
                planetRetrogradePt.y = -1 * planetRetrogradePt.y + CenterY + degreeYoffset;
                p.Color = SKColors.Black;
                cvs.DrawText("R", (float)planetRetrogradePt.x, (float)planetRetrogradePt.y, degreeText);
            }
        }

        public int GetPlanetOffset(int bandIndex)
        {
            int planetOffset = 0;
            if (bandIndex == 1)
            {
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
            }
            else if (bandIndex == 2)
            {
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
            }
            else if (bandIndex == 3)
            {
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
            }

            return planetOffset;
        }


        public double GetRingOffset(int bandnum)
        {
            double offset = 0;
            if (CommonInstance.getInstance().currentSetting.bands == 2)
            {
                // TODO
            }
            return offset;
        }

        public void ReSetSettingMenu() {
            settingMenu.RemoveAllItems();
            for (int i = 0; i < 10; i++)
            {
                settingMenu.AddItem(new NSMenuItem(settings[i].dispName));
            }
        }
    }
}

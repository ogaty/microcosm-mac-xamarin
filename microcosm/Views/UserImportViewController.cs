using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Threading.Tasks;

namespace microcosm.Views
{
    public partial class UserImportViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public UserImportViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public UserImportViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public UserImportViewController() : base("UserImportView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new UserImportView View
        {
            get
            {
                return (UserImportView)base.View;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        partial void CloseBtnClicked(NSObject e)
        {
            DismissViewController(this);
        }

        public async Task<bool> Import()
        {
            return await Task.Run(() => 
            {
                return true;
            }); 
        }

        /*
        public async void startAmateru(OpenFileDialog oFD)
        {
            cancelToken = new CancellationTokenSource();
            complete = false;
            int err = 0;
            List<string> dataStr = new List<string>();
            // ファイルハンドラはすぐ閉じる
            using (Stream fileStream = oFD.OpenFile())
            {
                StreamReader sr = new StreamReader(fileStream, true);
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    dataStr.Add(line);
                }
                sr.Close();
            }

            Progress<int> p = new Progress<int>(showProgress);

            await Task.Run(() =>
            {
                err = processAmateru(p, dataStr, cancelToken);
            }
            );
            if (err == 0)
            {
                lbl.Content = "終了しました。";
            }
            else
            {
                lbl.Content = String.Format("終了しました。(エラー{0}件)", err);
            }
            complete = true;
            stopBtn.Content = "閉じる";
        }

        private int processAmateru(IProgress<int> p, List<string> dataStr, CancellationTokenSource token)
        {
            int err = 0;

            int success = 0;
            List<string> errMsgs = new List<string>();
            int lineCnt = 0;
            string ecsm = "";
            foreach (string line in dataStr)
            {
                if (line.IndexOf("NATAL") != 0)
                {
                    continue;
                }
                try
                {
                    string[] data = line.Split('\t');
                    string[] days = data[6].Split('-');
                    string[] hours = new string[3];
                    double lat;
                    double lng;
                    if (data[7] == "")
                    {
                        hours[0] = "12";
                        hours[1] = "0";
                        hours[2] = "0";
                    }
                    else
                    {
                        hours = data[7].Split(':');
                    }
                    if (data[9] == "")
                    {
                        lat = Common.CommonData.defaultLat;
                    }
                    else
                    {
                        lat = double.Parse(data[9]);
                    }
                    if (data[10] == "")
                    {
                        lng = Common.CommonData.defaultLng;
                    }
                    else
                    {
                        lng = double.Parse(data[10]);
                    }

                    ecsm += String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}\n",
                        data[1],
                        data[2],
                        days[0],
                        days[1],
                        days[2],
                        hours[0],
                        hours[1],
                        hours[2],
                        lat.ToString(),
                        lng.ToString(),
                        data[8],
                        data[6],
                        data[11]
                        );
                    lineCnt++;
                    p.Report(lineCnt * 100 / dataStr.Count());
                }
                catch (IOException exception)
                {
                    string errMsg = String.Format("{0} {1}", lineCnt, exception.Message);
                    errMsgs.Add(errMsg);
                    err++;
                }
                if (token.IsCancellationRequested)
                {
                    return err;
                }
            }
            p.Report(100);

            try
            {
                string filename = "Amateru" + DateTime.Now.ToString("yyyyMMdd") + ".ecsm";
                Assembly myAssembly = Assembly.GetEntryAssembly();
                string path = System.IO.Path.GetDirectoryName(myAssembly.Location) + @"\data\AMATERU\" + filename;
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                }
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(ecsm);
                sw.Close();
                fs.Close();

                string errLog = "Amateru" + DateTime.Now.ToString("yyyyMMdd") + ".ecsm";
                string errPath = System.IO.Path.GetDirectoryName(myAssembly.Location) + @"\data\AMATERU\" + errLog;
                FileStream fs2 = new FileStream(errPath, FileMode.Create);
                StreamWriter sw2 = new StreamWriter(fs2);
                sw2.Write(ecsm);
                sw2.Close();
                fs2.Close();

                success++;
            }
            catch (IOException)
            {
                err++;
            }

            return err;
        }
        */

    }
}

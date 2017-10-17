using System;
using System.IO;
using System.IO.IsolatedStorage;
using AppKit;
using Foundation;
using microcosm.Calc;
using SwissEphNet;

namespace microcosm
{
    public partial class ViewController : NSViewController
    {
        public AstroCalc calc;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			// Do any additional setup after loading the view.
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

    }
}

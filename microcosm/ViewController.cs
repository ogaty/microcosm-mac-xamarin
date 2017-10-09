using System;

using AppKit;
using Foundation;

namespace microcosm
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
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

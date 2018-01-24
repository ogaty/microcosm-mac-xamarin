using System;
using AppKit;
using microcosm.Common;

namespace microcosm.Models
{
    public class CuspListDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "cellID";

        private CuspListDataSource DataSource;

        public CuspListDelegate(CuspListDataSource dataSource)
        {
            DataSource = dataSource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            string sign;
            double tmp1;
            double tmp2;
            double tmp3;

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "cusps":
                    view.StringValue = (row + 1).ToString();
                    tableColumn.Width = 50;
                    break;
                case "1":
                    sign = CommonData.getSignSymbol((int)(DataSource.list[(int)row].Degree1 / 30));
                    tmp1 = DataSource.list[(int)row].Degree1 / 30;
                    tmp2 = tmp1 - Math.Floor(tmp1);
                    tmp3 = Math.Floor(DataSource.list[(int)row].Degree1 % 30) + (tmp2 / 100) * 60;
                    view.StringValue = sign + String.Format("{0:0.00}", tmp3);
                    tableColumn.Width = 70;
                    break;
                case "2":
                    sign = CommonData.getSignSymbol((int)(DataSource.list[(int)row].Degree2 / 30));
                    tmp1 = DataSource.list[(int)row].Degree2 / 30;
                    tmp2 = tmp1 - Math.Floor(tmp1);
                    tmp3 = Math.Floor(DataSource.list[(int)row].Degree1 % 30) + (tmp2 / 100) * 60;
                    view.StringValue = sign + String.Format("{0:0.00}", tmp3);
                    break;
                case "3":
                    sign = CommonData.getSignSymbol((int)(DataSource.list[(int)row].Degree3 / 30));
                    tmp1 = DataSource.list[(int)row].Degree3 / 30;
                    tmp2 = tmp1 - Math.Floor(tmp1);
                    tmp3 = Math.Floor(DataSource.list[(int)row].Degree1 % 30) + (tmp2 / 100) * 60;
                    view.StringValue = sign + String.Format("{0:0.00}", tmp3);
                    break;
            }

            return view;
        }
    }
}

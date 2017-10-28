using System;
using AppKit;
using microcosm.Common;

namespace microcosm.Tables
{
    public class SettingDetailPlanetTableDelegate : NSTableViewDelegate
    {
        private const string cellIdentifier = "cellID";

        public SettingDetailPlanetTableDataSource DataSource;
        public SettingDetailPlanetTableDelegate(SettingDetailPlanetTableDataSource dataSource)
        {
            this.DataSource = dataSource;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(cellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = cellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }
            switch (tableColumn.Title)
            {
                case "sun":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_SUN] ? "A" : "";
                    break;
                case "moon":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_MOON] ? "B" : "";
                    break;
                case "mercury":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_MERCURY] ? "B" : "";
                    break;
                case "venus":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_VENUS] ? "B" : "";
                    break;
                case "mars":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_MARS] ? "B" : "";
                    break;
                case "jupiter":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_JUPITER] ? "B" : "";
                    break;
                case "saturn":
                    view.StringValue = CommonInstance.getInstance().settings[0].dispPlanet[(int)row][CommonData.ZODIAC_NUMBER_SATURN] ? "B" : "";
                    break;
                default:
                    view.StringValue = (row + 1).ToString();
                    break;
            }

            return view;
        }
    }
}

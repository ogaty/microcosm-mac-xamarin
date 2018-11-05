// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace microcosm
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSImageView canvas { get; set; }

		[Outlet]
		AppKit.NSBox ChartBox { get; set; }

		[Outlet]
		AppKit.NSView ChartBoxView { get; set; }

		[Outlet]
		AppKit.NSTableView CuspList { get; set; }

		[Outlet]
		AppKit.NSPopUpButton DateSetterCombo { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterCurrentLat { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterCurrentLng { get; set; }

		[Outlet]
		AppKit.NSDatePicker DateSetterDatePicker { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterDay { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterHour { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterMinute { get; set; }

		[Outlet]
		AppKit.NSTextField DateSetterSecond { get; set; }

		[Outlet]
		AppKit.NSTextField Event1Date { get; set; }

		[Outlet]
		AppKit.NSTextField Event1Name { get; set; }

		[Outlet]
		AppKit.NSTextField Event2Date { get; set; }

		[Outlet]
		AppKit.NSTextField Event2Name { get; set; }

		[Outlet]
		AppKit.NSView horoscopeCanvas { get; set; }

		[Outlet]
		AppKit.NSImageCell img { get; set; }

		[Outlet]
		AppKit.NSMenu settingMenu { get; set; }

		[Outlet]
		AppKit.NSButton testButton { get; set; }

		[Outlet]
		AppKit.NSTextField User1Date { get; set; }

		[Outlet]
		AppKit.NSTextField User1Name { get; set; }

		[Outlet]
		AppKit.NSTextField User2Date { get; set; }

		[Outlet]
		AppKit.NSTextField User2Name { get; set; }

		[Outlet]
		AppKit.NSTableColumn userDbDateColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn userDbNameColumn { get; set; }

		[Outlet]
		WebKit.WKWebView web { get; set; }

		[Action ("DateSetterDayLeft:")]
		partial void DateSetterDayLeft (Foundation.NSObject sender);

		[Action ("DateSetterDayRight:")]
		partial void DateSetterDayRight (Foundation.NSObject sender);

		[Action ("DateSetterHourLeft:")]
		partial void DateSetterHourLeft (Foundation.NSObject sender);

		[Action ("DateSetterHourRight:")]
		partial void DateSetterHourRight (Foundation.NSObject sender);

		[Action ("DateSetterHourRIght:")]
		partial void DateSetterHourRIght (Foundation.NSObject sender);

		[Action ("DateSetterLeft:")]
		partial void DateSetterLeft (Foundation.NSObject sender);

		[Action ("DateSetterMinuteLeft:")]
		partial void DateSetterMinuteLeft (Foundation.NSObject sender);

		[Action ("DateSetterMinuteRight:")]
		partial void DateSetterMinuteRight (Foundation.NSObject sender);

		[Action ("DateSetterNow:")]
		partial void DateSetterNow (Foundation.NSObject sender);

		[Action ("DateSetterRight:")]
		partial void DateSetterRight (Foundation.NSObject sender);

		[Action ("DateSetterSecondLeft:")]
		partial void DateSetterSecondLeft (Foundation.NSObject sender);

		[Action ("DateSetterSecondRight:")]
		partial void DateSetterSecondRight (Foundation.NSObject sender);

		[Action ("DateSetterSet:")]
		partial void DateSetterSet (Foundation.NSObject sender);

		[Action ("scriptButtonClicked:")]
		partial void scriptButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (canvas != null) {
				canvas.Dispose ();
				canvas = null;
			}

			if (ChartBox != null) {
				ChartBox.Dispose ();
				ChartBox = null;
			}

			if (ChartBoxView != null) {
				ChartBoxView.Dispose ();
				ChartBoxView = null;
			}

			if (CuspList != null) {
				CuspList.Dispose ();
				CuspList = null;
			}

			if (DateSetterCombo != null) {
				DateSetterCombo.Dispose ();
				DateSetterCombo = null;
			}

			if (DateSetterCurrentLat != null) {
				DateSetterCurrentLat.Dispose ();
				DateSetterCurrentLat = null;
			}

			if (DateSetterCurrentLng != null) {
				DateSetterCurrentLng.Dispose ();
				DateSetterCurrentLng = null;
			}

			if (DateSetterDatePicker != null) {
				DateSetterDatePicker.Dispose ();
				DateSetterDatePicker = null;
			}

			if (DateSetterDay != null) {
				DateSetterDay.Dispose ();
				DateSetterDay = null;
			}

			if (DateSetterHour != null) {
				DateSetterHour.Dispose ();
				DateSetterHour = null;
			}

			if (DateSetterMinute != null) {
				DateSetterMinute.Dispose ();
				DateSetterMinute = null;
			}

			if (DateSetterSecond != null) {
				DateSetterSecond.Dispose ();
				DateSetterSecond = null;
			}

			if (Event1Date != null) {
				Event1Date.Dispose ();
				Event1Date = null;
			}

			if (Event1Name != null) {
				Event1Name.Dispose ();
				Event1Name = null;
			}

			if (Event2Date != null) {
				Event2Date.Dispose ();
				Event2Date = null;
			}

			if (Event2Name != null) {
				Event2Name.Dispose ();
				Event2Name = null;
			}

			if (horoscopeCanvas != null) {
				horoscopeCanvas.Dispose ();
				horoscopeCanvas = null;
			}

			if (img != null) {
				img.Dispose ();
				img = null;
			}

			if (testButton != null) {
				testButton.Dispose ();
				testButton = null;
			}

			if (User1Date != null) {
				User1Date.Dispose ();
				User1Date = null;
			}

			if (User1Name != null) {
				User1Name.Dispose ();
				User1Name = null;
			}

			if (User2Date != null) {
				User2Date.Dispose ();
				User2Date = null;
			}

			if (User2Name != null) {
				User2Name.Dispose ();
				User2Name = null;
			}

			if (userDbDateColumn != null) {
				userDbDateColumn.Dispose ();
				userDbDateColumn = null;
			}

			if (userDbNameColumn != null) {
				userDbNameColumn.Dispose ();
				userDbNameColumn = null;
			}

			if (web != null) {
				web.Dispose ();
				web = null;
			}

			if (settingMenu != null) {
				settingMenu.Dispose ();
				settingMenu = null;
			}
		}
	}
}

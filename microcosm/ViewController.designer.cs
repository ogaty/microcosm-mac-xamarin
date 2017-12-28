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
		AppKit.NSTextField Event1Date { get; set; }

		[Outlet]
		AppKit.NSTextField Event1Name { get; set; }

		[Outlet]
		AppKit.NSTextField Event2Date { get; set; }

		[Outlet]
		AppKit.NSTextField Event2Name { get; set; }

		[Outlet]
		AppKit.NSImageCell img { get; set; }

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
		}
	}
}

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
		AppKit.NSScrollView CuspList { get; set; }

		[Outlet]
		AppKit.NSButton testButton { get; set; }

		[Outlet]
		AppKit.NSTableColumn userDbDateColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn userDbNameColumn { get; set; }

		[Outlet]
		AppKit.NSTableView userDbTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (testButton != null) {
				testButton.Dispose ();
				testButton = null;
			}

			if (userDbDateColumn != null) {
				userDbDateColumn.Dispose ();
				userDbDateColumn = null;
			}

			if (userDbNameColumn != null) {
				userDbNameColumn.Dispose ();
				userDbNameColumn = null;
			}

			if (userDbTable != null) {
				userDbTable.Dispose ();
				userDbTable = null;
			}

			if (CuspList != null) {
				CuspList.Dispose ();
				CuspList = null;
			}
		}
	}
}

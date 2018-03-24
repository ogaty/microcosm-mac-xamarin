// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace microcosm.Views
{
	[Register ("UserDbViewController")]
	partial class UserDbViewController
	{
		[Outlet]
		AppKit.NSTextField Event1Area { get; set; }

		[Outlet]
		AppKit.NSTextField Event2Area { get; set; }

		[Outlet]
		AppKit.NSTextView memoArea { get; set; }

		[Outlet]
		AppKit.NSTextField User1Area { get; set; }

		[Outlet]
		AppKit.NSTextField User2Area { get; set; }

		[Outlet]
		AppKit.NSOutlineView UserDbDirOutline { get; set; }

		[Outlet]
		AppKit.NSTableView UserTable { get; set; }

		[Action ("AddDirectoryClick:")]
		partial void AddDirectoryClick (Foundation.NSObject sender);

		[Action ("DeleteDirectoryClick:")]
		partial void DeleteDirectoryClick (Foundation.NSObject sender);

		[Action ("EditDirectoryClick:")]
		partial void EditDirectoryClick (Foundation.NSObject sender);

		[Action ("Event1Clicked:")]
		partial void Event1Clicked (Foundation.NSObject sender);

		[Action ("Event2Clicked:")]
		partial void Event2Clicked (Foundation.NSObject sender);

		[Action ("SubmitClicked:")]
		partial void SubmitClicked (Foundation.NSObject sender);

		[Action ("User1Clicked:")]
		partial void User1Clicked (Foundation.NSObject sender);

		[Action ("User2Clicked:")]
		partial void User2Clicked (Foundation.NSObject sender);

		[Action ("UserDbDirClick:")]
		partial void UserDbDirClick (Foundation.NSObject sender);

		[Action ("UserTableClick:")]
		partial void UserTableClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Event1Area != null) {
				Event1Area.Dispose ();
				Event1Area = null;
			}

			if (Event2Area != null) {
				Event2Area.Dispose ();
				Event2Area = null;
			}

			if (memoArea != null) {
				memoArea.Dispose ();
				memoArea = null;
			}

			if (User1Area != null) {
				User1Area.Dispose ();
				User1Area = null;
			}

			if (User2Area != null) {
				User2Area.Dispose ();
				User2Area = null;
			}

			if (UserDbDirOutline != null) {
				UserDbDirOutline.Dispose ();
				UserDbDirOutline = null;
			}

			if (UserTable != null) {
				UserTable.Dispose ();
				UserTable = null;
			}
		}
	}
}

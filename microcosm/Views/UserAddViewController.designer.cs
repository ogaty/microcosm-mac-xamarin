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
	[Register ("UserAddViewController")]
	partial class UserAddViewController
	{
		[Outlet]
		AppKit.NSTextField FileName { get; set; }

		[Outlet]
		AppKit.NSDatePicker UserBirth { get; set; }

		[Outlet]
		AppKit.NSTextField UserFurigana { get; set; }

		[Outlet]
		AppKit.NSTextField UserLat { get; set; }

		[Outlet]
		AppKit.NSTextField UserLng { get; set; }

		[Outlet]
		AppKit.NSScrollView UserMemo { get; set; }

		[Outlet]
		AppKit.NSTextField UserName { get; set; }

		[Outlet]
		AppKit.NSTextField UserPlace { get; set; }

		[Action ("GoogleSearchButtonClicked:")]
		partial void GoogleSearchButtonClicked (Foundation.NSObject sender);

		[Action ("OfflineSearchButtonClicked:")]
		partial void OfflineSearchButtonClicked (Foundation.NSObject sender);

		[Action ("SubmitClick:")]
		partial void SubmitClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (FileName != null) {
				FileName.Dispose ();
				FileName = null;
			}

			if (UserBirth != null) {
				UserBirth.Dispose ();
				UserBirth = null;
			}

			if (UserFurigana != null) {
				UserFurigana.Dispose ();
				UserFurigana = null;
			}

			if (UserLat != null) {
				UserLat.Dispose ();
				UserLat = null;
			}

			if (UserLng != null) {
				UserLng.Dispose ();
				UserLng = null;
			}

			if (UserMemo != null) {
				UserMemo.Dispose ();
				UserMemo = null;
			}

			if (UserName != null) {
				UserName.Dispose ();
				UserName = null;
			}

			if (UserPlace != null) {
				UserPlace.Dispose ();
				UserPlace = null;
			}
		}
	}
}

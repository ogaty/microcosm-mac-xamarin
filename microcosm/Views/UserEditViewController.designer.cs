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
	[Register ("UserEditViewController")]
	partial class UserEditViewController
	{
		[Outlet]
		AppKit.NSDatePicker birthDay { get; set; }

		[Outlet]
		AppKit.NSTextField fileName { get; set; }

		[Outlet]
		AppKit.NSTextField furigana { get; set; }

		[Outlet]
		AppKit.NSTextField memo { get; set; }

		[Outlet]
		AppKit.NSTextField userName { get; set; }

		[Outlet]
		AppKit.NSTextField userPlace { get; set; }

		[Action ("SubmitClicked:")]
		partial void SubmitClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (fileName != null) {
				fileName.Dispose ();
				fileName = null;
			}

			if (userName != null) {
				userName.Dispose ();
				userName = null;
			}

			if (furigana != null) {
				furigana.Dispose ();
				furigana = null;
			}

			if (birthDay != null) {
				birthDay.Dispose ();
				birthDay = null;
			}

			if (userPlace != null) {
				userPlace.Dispose ();
				userPlace = null;
			}

			if (memo != null) {
				memo.Dispose ();
				memo = null;
			}
		}
	}
}

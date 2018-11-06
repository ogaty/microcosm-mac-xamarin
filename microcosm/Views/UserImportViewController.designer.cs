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
	[Register ("UserImportViewController")]
	partial class UserImportViewController
	{
		[Outlet]
		AppKit.NSPopUpButton ImportTarget { get; set; }

		[Action ("CloseBtnClicked:")]
		partial void CloseBtnClicked (Foundation.NSObject sender);

		[Action ("OpenDialogClicked:")]
		partial void OpenDialogClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImportTarget != null) {
				ImportTarget.Dispose ();
				ImportTarget = null;
			}
		}
	}
}

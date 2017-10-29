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
		AppKit.NSOutlineView UserDbDirOutline { get; set; }

		[Action ("UserDbDirClick:")]
		partial void UserDbDirClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UserDbDirOutline != null) {
				UserDbDirOutline.Dispose ();
				UserDbDirOutline = null;
			}
		}
	}
}

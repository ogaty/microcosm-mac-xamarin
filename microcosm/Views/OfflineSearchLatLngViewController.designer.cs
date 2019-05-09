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
	[Register ("OfflineSearchLatLngViewController")]
	partial class OfflineSearchLatLngViewController
	{
		[Outlet]
		AppKit.NSTextField Place { get; set; }

		[Outlet]
		AppKit.NSTableView Result { get; set; }

		[Action ("LatLngTableClicked:")]
		partial void LatLngTableClicked (Foundation.NSObject sender);

		[Action ("SearchButtonClicked:")]
		partial void SearchButtonClicked (Foundation.NSObject sender);

		[Action ("SubmitClicked:")]
		partial void SubmitClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Place != null) {
				Place.Dispose ();
				Place = null;
			}

			if (Result != null) {
				Result.Dispose ();
				Result = null;
			}
		}
	}
}

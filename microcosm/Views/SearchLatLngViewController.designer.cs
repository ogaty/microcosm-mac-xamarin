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
	[Register ("SearchLatLngViewController")]
	partial class SearchLatLngViewController
	{
		[Outlet]
		AppKit.NSScrollView LatLngTable { get; set; }

		[Outlet]
		AppKit.NSTextField Place { get; set; }

		[Outlet]
		AppKit.NSButton SubmitButtonClicked { get; set; }

		[Action ("SearchButtonClicked:")]
		partial void SearchButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Place != null) {
				Place.Dispose ();
				Place = null;
			}

			if (LatLngTable != null) {
				LatLngTable.Dispose ();
				LatLngTable = null;
			}

			if (SubmitButtonClicked != null) {
				SubmitButtonClicked.Dispose ();
				SubmitButtonClicked = null;
			}
		}
	}
}

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
	[Register ("SettingsViewController")]
	partial class SettingsViewController
	{
		[Outlet]
		AppKit.NSMatrix CentricRadioGroup { get; set; }

		[Outlet]
		AppKit.NSButton DispCheckBox { get; set; }

		[Outlet]
		AppKit.NSTextField DispCheckText { get; set; }

		[Outlet]
		AppKit.NSMatrix DispTypeRadioGroup { get; set; }

		[Outlet]
		AppKit.NSMatrix DoubleRadioGroup { get; set; }

		[Outlet]
		AppKit.NSMatrix HouseRadioGroup { get; set; }

		[Outlet]
		AppKit.NSMatrix ProgressionRadioGroup { get; set; }

		[Outlet]
		AppKit.NSMatrix SideRealRadioGroup { get; set; }

		[Action ("CentricChanged:")]
		partial void CentricChanged (Foundation.NSObject sender);

		[Action ("DispCheckBoxChanged:")]
		partial void DispCheckBoxChanged (Foundation.NSObject sender);

		[Action ("DispTypeChanged:")]
		partial void DispTypeChanged (Foundation.NSObject sender);

		[Action ("DoubleChanged:")]
		partial void DoubleChanged (Foundation.NSObject sender);

		[Action ("HouseChanged:")]
		partial void HouseChanged (Foundation.NSObject sender);

		[Action ("ProgressionChanged:")]
		partial void ProgressionChanged (Foundation.NSObject sender);

		[Action ("SettingChanged:")]
		partial void SettingChanged (Foundation.NSObject sender);

		[Action ("SideRealChanged:")]
		partial void SideRealChanged (Foundation.NSObject sender);

		[Action ("SubmitClicked:")]
		partial void SubmitClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (SideRealRadioGroup != null) {
				SideRealRadioGroup.Dispose ();
				SideRealRadioGroup = null;
			}

			if (CentricRadioGroup != null) {
				CentricRadioGroup.Dispose ();
				CentricRadioGroup = null;
			}

			if (DispCheckBox != null) {
				DispCheckBox.Dispose ();
				DispCheckBox = null;
			}

			if (DispCheckText != null) {
				DispCheckText.Dispose ();
				DispCheckText = null;
			}

			if (DispTypeRadioGroup != null) {
				DispTypeRadioGroup.Dispose ();
				DispTypeRadioGroup = null;
			}

			if (DoubleRadioGroup != null) {
				DoubleRadioGroup.Dispose ();
				DoubleRadioGroup = null;
			}

			if (HouseRadioGroup != null) {
				HouseRadioGroup.Dispose ();
				HouseRadioGroup = null;
			}

			if (ProgressionRadioGroup != null) {
				ProgressionRadioGroup.Dispose ();
				ProgressionRadioGroup = null;
			}
		}
	}
}

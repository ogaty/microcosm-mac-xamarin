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
	[Register ("SettingOrbsViewController")]
	partial class SettingOrbsViewController
	{
		[Outlet]
		AppKit.NSTextField OrbMoonHard { get; set; }

		[Outlet]
		AppKit.NSTextField OrbMoonSoft { get; set; }

		[Outlet]
		AppKit.NSTextField OrbOtherHard { get; set; }

		[Outlet]
		AppKit.NSTextField OrbOtherSoft { get; set; }

		[Outlet]
		AppKit.NSComboBox OrbsCombo { get; set; }

		[Outlet]
		AppKit.NSTextField OrbSunHard { get; set; }

		[Outlet]
		AppKit.NSTextField OrbSunSoft { get; set; }

		[Outlet]
		AppKit.NSComboBox SettingsCombo { get; set; }

		[Outlet]
		AppKit.NSButton SubmitClicked { get; set; }

		[Action ("OrbsComboChanged:")]
		partial void OrbsComboChanged (Foundation.NSObject sender);

		[Action ("SettingsButtonChanged:")]
		partial void SettingsButtonChanged (Foundation.NSObject sender);

		[Action ("SettingsComboChanged:")]
		partial void SettingsComboChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (OrbMoonHard != null) {
				OrbMoonHard.Dispose ();
				OrbMoonHard = null;
			}

			if (OrbMoonSoft != null) {
				OrbMoonSoft.Dispose ();
				OrbMoonSoft = null;
			}

			if (OrbOtherHard != null) {
				OrbOtherHard.Dispose ();
				OrbOtherHard = null;
			}

			if (OrbOtherSoft != null) {
				OrbOtherSoft.Dispose ();
				OrbOtherSoft = null;
			}

			if (OrbsCombo != null) {
				OrbsCombo.Dispose ();
				OrbsCombo = null;
			}

			if (OrbSunHard != null) {
				OrbSunHard.Dispose ();
				OrbSunHard = null;
			}

			if (OrbSunSoft != null) {
				OrbSunSoft.Dispose ();
				OrbSunSoft = null;
			}

			if (SubmitClicked != null) {
				SubmitClicked.Dispose ();
				SubmitClicked = null;
			}

			if (SettingsCombo != null) {
				SettingsCombo.Dispose ();
				SettingsCombo = null;
			}
		}
	}
}

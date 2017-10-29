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
	[Register ("SettingDispAspectCategoryViewController")]
	partial class SettingDispAspectCategoryViewController
	{
		[Outlet]
		AppKit.NSButton dispAspect { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectConjunction { get; set; }

		[Outlet]
		AppKit.NSComboBox SettingsCombo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SettingsCombo != null) {
				SettingsCombo.Dispose ();
				SettingsCombo = null;
			}

			if (dispAspect != null) {
				dispAspect.Dispose ();
				dispAspect = null;
			}

			if (dispAspectConjunction != null) {
				dispAspectConjunction.Dispose ();
				dispAspectConjunction = null;
			}
		}
	}
}

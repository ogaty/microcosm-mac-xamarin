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
		AppKit.NSButton dispAspectBiQuintile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectConjunction { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectInconjunct { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectNovile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectOpposition { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectQuintile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSemiQuintile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSemiSextile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSemiSquare { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSeptile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSesquiquadrate { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSextile { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectSquare { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectTrine { get; set; }

		[Outlet]
		AppKit.NSComboBox RingsCombo { get; set; }

		[Outlet]
		AppKit.NSComboBox SettingsCombo { get; set; }

		[Action ("RingsComboChanged:")]
		partial void RingsComboChanged (Foundation.NSObject sender);

		[Action ("SettingsComboChanged:")]
		partial void SettingsComboChanged (Foundation.NSObject sender);

		[Action ("SubmitButtonClicked:")]
		partial void SubmitButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (dispAspect != null) {
				dispAspect.Dispose ();
				dispAspect = null;
			}

			if (dispAspectBiQuintile != null) {
				dispAspectBiQuintile.Dispose ();
				dispAspectBiQuintile = null;
			}

			if (dispAspectConjunction != null) {
				dispAspectConjunction.Dispose ();
				dispAspectConjunction = null;
			}

			if (dispAspectInconjunct != null) {
				dispAspectInconjunct.Dispose ();
				dispAspectInconjunct = null;
			}

			if (dispAspectNovile != null) {
				dispAspectNovile.Dispose ();
				dispAspectNovile = null;
			}

			if (dispAspectOpposition != null) {
				dispAspectOpposition.Dispose ();
				dispAspectOpposition = null;
			}

			if (dispAspectQuintile != null) {
				dispAspectQuintile.Dispose ();
				dispAspectQuintile = null;
			}

			if (dispAspectSemiQuintile != null) {
				dispAspectSemiQuintile.Dispose ();
				dispAspectSemiQuintile = null;
			}

			if (dispAspectSemiSextile != null) {
				dispAspectSemiSextile.Dispose ();
				dispAspectSemiSextile = null;
			}

			if (dispAspectSemiSquare != null) {
				dispAspectSemiSquare.Dispose ();
				dispAspectSemiSquare = null;
			}

			if (dispAspectSeptile != null) {
				dispAspectSeptile.Dispose ();
				dispAspectSeptile = null;
			}

			if (dispAspectSesquiquadrate != null) {
				dispAspectSesquiquadrate.Dispose ();
				dispAspectSesquiquadrate = null;
			}

			if (dispAspectSextile != null) {
				dispAspectSextile.Dispose ();
				dispAspectSextile = null;
			}

			if (dispAspectSquare != null) {
				dispAspectSquare.Dispose ();
				dispAspectSquare = null;
			}

			if (dispAspectTrine != null) {
				dispAspectTrine.Dispose ();
				dispAspectTrine = null;
			}

			if (RingsCombo != null) {
				RingsCombo.Dispose ();
				RingsCombo = null;
			}

			if (SettingsCombo != null) {
				SettingsCombo.Dispose ();
				SettingsCombo = null;
			}
		}
	}
}

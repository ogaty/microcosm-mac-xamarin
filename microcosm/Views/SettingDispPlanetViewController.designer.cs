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
	[Register ("SettingDispPlanetViewController")]
	partial class SettingDispPlanetViewController
	{
		[Outlet]
		AppKit.NSButton dispAspectPlanetAsc { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetCeres { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetChiron { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetDh { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetEarth { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetEris { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetHaumea { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetJuno { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetJupiter { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetLilith { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetMakemake { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetMars { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetMc { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetMercury { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetMoon { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetNeptune { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetPallas { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetPluto { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetPof { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetSaturn { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetSedna { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetSun { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetUranus { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetVenus { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetVesta { get; set; }

		[Outlet]
		AppKit.NSButton dispAspectPlanetVt { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetAsc { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetCeres { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetChiron { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetDh { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetEarth { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetEris { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetHaumea { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetJuno { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetJupiter { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetLilith { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetMakemake { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetMars { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetMc { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetMercury { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetMoon { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetNeptune { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetParas { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetPluto { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetPof { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetSaturn { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetSedna { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetSun { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetUranus { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetVenus { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetVesta { get; set; }

		[Outlet]
		AppKit.NSButton dispPlanetVt { get; set; }

		[Outlet]
		AppKit.NSComboBox RingsCombo { get; set; }

		[Outlet]
		microcosm.Views.SettingListView settingListTbl { get; set; }

		[Outlet]
		AppKit.NSPopUpButton SettingsCombo { get; set; }

		[Action ("ringsComboChanged:")]
		partial void ringsComboChanged (Foundation.NSObject sender);

		[Action ("settingsComboChanged:")]
		partial void settingsComboChanged (Foundation.NSObject sender);

		[Action ("SettingsComboChanged:")]
		partial void SettingsComboChanged (Foundation.NSObject sender);

		[Action ("SubmitClicked:")]
		partial void SubmitClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (dispAspectPlanetCeres != null) {
				dispAspectPlanetCeres.Dispose ();
				dispAspectPlanetCeres = null;
			}

			if (dispAspectPlanetPallas != null) {
				dispAspectPlanetPallas.Dispose ();
				dispAspectPlanetPallas = null;
			}

			if (dispAspectPlanetJuno != null) {
				dispAspectPlanetJuno.Dispose ();
				dispAspectPlanetJuno = null;
			}

			if (dispAspectPlanetVesta != null) {
				dispAspectPlanetVesta.Dispose ();
				dispAspectPlanetVesta = null;
			}

			if (dispAspectPlanetEris != null) {
				dispAspectPlanetEris.Dispose ();
				dispAspectPlanetEris = null;
			}

			if (dispAspectPlanetSedna != null) {
				dispAspectPlanetSedna.Dispose ();
				dispAspectPlanetSedna = null;
			}

			if (dispAspectPlanetHaumea != null) {
				dispAspectPlanetHaumea.Dispose ();
				dispAspectPlanetHaumea = null;
			}

			if (dispAspectPlanetMakemake != null) {
				dispAspectPlanetMakemake.Dispose ();
				dispAspectPlanetMakemake = null;
			}

			if (dispAspectPlanetAsc != null) {
				dispAspectPlanetAsc.Dispose ();
				dispAspectPlanetAsc = null;
			}

			if (dispAspectPlanetChiron != null) {
				dispAspectPlanetChiron.Dispose ();
				dispAspectPlanetChiron = null;
			}

			if (dispAspectPlanetDh != null) {
				dispAspectPlanetDh.Dispose ();
				dispAspectPlanetDh = null;
			}

			if (dispAspectPlanetEarth != null) {
				dispAspectPlanetEarth.Dispose ();
				dispAspectPlanetEarth = null;
			}

			if (dispAspectPlanetJupiter != null) {
				dispAspectPlanetJupiter.Dispose ();
				dispAspectPlanetJupiter = null;
			}

			if (dispAspectPlanetLilith != null) {
				dispAspectPlanetLilith.Dispose ();
				dispAspectPlanetLilith = null;
			}

			if (dispAspectPlanetMars != null) {
				dispAspectPlanetMars.Dispose ();
				dispAspectPlanetMars = null;
			}

			if (dispAspectPlanetMc != null) {
				dispAspectPlanetMc.Dispose ();
				dispAspectPlanetMc = null;
			}

			if (dispAspectPlanetMercury != null) {
				dispAspectPlanetMercury.Dispose ();
				dispAspectPlanetMercury = null;
			}

			if (dispAspectPlanetMoon != null) {
				dispAspectPlanetMoon.Dispose ();
				dispAspectPlanetMoon = null;
			}

			if (dispAspectPlanetNeptune != null) {
				dispAspectPlanetNeptune.Dispose ();
				dispAspectPlanetNeptune = null;
			}

			if (dispAspectPlanetPluto != null) {
				dispAspectPlanetPluto.Dispose ();
				dispAspectPlanetPluto = null;
			}

			if (dispAspectPlanetPof != null) {
				dispAspectPlanetPof.Dispose ();
				dispAspectPlanetPof = null;
			}

			if (dispAspectPlanetSaturn != null) {
				dispAspectPlanetSaturn.Dispose ();
				dispAspectPlanetSaturn = null;
			}

			if (dispAspectPlanetSun != null) {
				dispAspectPlanetSun.Dispose ();
				dispAspectPlanetSun = null;
			}

			if (dispAspectPlanetUranus != null) {
				dispAspectPlanetUranus.Dispose ();
				dispAspectPlanetUranus = null;
			}

			if (dispAspectPlanetVenus != null) {
				dispAspectPlanetVenus.Dispose ();
				dispAspectPlanetVenus = null;
			}

			if (dispAspectPlanetVt != null) {
				dispAspectPlanetVt.Dispose ();
				dispAspectPlanetVt = null;
			}

			if (dispPlanetAsc != null) {
				dispPlanetAsc.Dispose ();
				dispPlanetAsc = null;
			}

			if (dispPlanetCeres != null) {
				dispPlanetCeres.Dispose ();
				dispPlanetCeres = null;
			}

			if (dispPlanetChiron != null) {
				dispPlanetChiron.Dispose ();
				dispPlanetChiron = null;
			}

			if (dispPlanetDh != null) {
				dispPlanetDh.Dispose ();
				dispPlanetDh = null;
			}

			if (dispPlanetEarth != null) {
				dispPlanetEarth.Dispose ();
				dispPlanetEarth = null;
			}

			if (dispPlanetEris != null) {
				dispPlanetEris.Dispose ();
				dispPlanetEris = null;
			}

			if (dispPlanetHaumea != null) {
				dispPlanetHaumea.Dispose ();
				dispPlanetHaumea = null;
			}

			if (dispPlanetJuno != null) {
				dispPlanetJuno.Dispose ();
				dispPlanetJuno = null;
			}

			if (dispPlanetJupiter != null) {
				dispPlanetJupiter.Dispose ();
				dispPlanetJupiter = null;
			}

			if (dispPlanetLilith != null) {
				dispPlanetLilith.Dispose ();
				dispPlanetLilith = null;
			}

			if (dispPlanetMakemake != null) {
				dispPlanetMakemake.Dispose ();
				dispPlanetMakemake = null;
			}

			if (dispPlanetMars != null) {
				dispPlanetMars.Dispose ();
				dispPlanetMars = null;
			}

			if (dispPlanetMc != null) {
				dispPlanetMc.Dispose ();
				dispPlanetMc = null;
			}

			if (dispPlanetMercury != null) {
				dispPlanetMercury.Dispose ();
				dispPlanetMercury = null;
			}

			if (dispPlanetMoon != null) {
				dispPlanetMoon.Dispose ();
				dispPlanetMoon = null;
			}

			if (dispPlanetNeptune != null) {
				dispPlanetNeptune.Dispose ();
				dispPlanetNeptune = null;
			}

			if (dispPlanetParas != null) {
				dispPlanetParas.Dispose ();
				dispPlanetParas = null;
			}

			if (dispPlanetPluto != null) {
				dispPlanetPluto.Dispose ();
				dispPlanetPluto = null;
			}

			if (dispPlanetPof != null) {
				dispPlanetPof.Dispose ();
				dispPlanetPof = null;
			}

			if (dispPlanetSaturn != null) {
				dispPlanetSaturn.Dispose ();
				dispPlanetSaturn = null;
			}

			if (dispPlanetSedna != null) {
				dispPlanetSedna.Dispose ();
				dispPlanetSedna = null;
			}

			if (dispPlanetSun != null) {
				dispPlanetSun.Dispose ();
				dispPlanetSun = null;
			}

			if (dispPlanetUranus != null) {
				dispPlanetUranus.Dispose ();
				dispPlanetUranus = null;
			}

			if (dispPlanetVenus != null) {
				dispPlanetVenus.Dispose ();
				dispPlanetVenus = null;
			}

			if (dispPlanetVesta != null) {
				dispPlanetVesta.Dispose ();
				dispPlanetVesta = null;
			}

			if (dispPlanetVt != null) {
				dispPlanetVt.Dispose ();
				dispPlanetVt = null;
			}

			if (RingsCombo != null) {
				RingsCombo.Dispose ();
				RingsCombo = null;
			}

			if (settingListTbl != null) {
				settingListTbl.Dispose ();
				settingListTbl = null;
			}

			if (SettingsCombo != null) {
				SettingsCombo.Dispose ();
				SettingsCombo = null;
			}
		}
	}
}

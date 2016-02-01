using System;
using Foundation;
using System.Threading;
using System.Diagnostics;

namespace Seamgen.MvvmCross.Localization.Touch
{
	public class LocalizationPlugin : ILocalization
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var iosLanguage = NSLocale.CurrentLocale.LanguageCode;
			var netLanguage = iosLanguage.Replace ("_", "-");

			// HACK: not sure why NSLocale isn't ever returning correct data
			if (NSLocale.PreferredLanguages.Length > 0) {
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-");
				Debug.WriteLine ("preferred:" + netLanguage);
			}
			return new System.Globalization.CultureInfo(netLanguage);
		}

		public void SetLocale ()
		{
			var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
			var netLocale = iosLocaleAuto.Replace ("_", "-");
			System.Globalization.CultureInfo ci;

			try 
			{
				ci = new System.Globalization.CultureInfo (netLocale);
			} 
			catch 
			{
				ci = GetCurrentCultureInfo ();
			}

			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			Debug.WriteLine ("SetLocale: " + ci.Name);
		}

		public string TestString () {
			return "Test2";
		}
	}
}



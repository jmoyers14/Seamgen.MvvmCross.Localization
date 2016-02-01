using System;
using System.Globalization;
using System.Collections.Generic;
using Cirrious.CrossCore;
using System.Resources;
using System.Reflection;
using System.Diagnostics;

namespace Seamgen.MvvmCross.Localization
{
	public static class Localization
	{
		private static readonly CultureInfo ci;
		private static readonly Dictionary<Enum, string> dictionary;


		static Localization ()
		{
			ci = Mvx.Resolve<ILocalization> ().GetCurrentCultureInfo ();
			dictionary = new Dictionary<Enum, string> ();
		}

		public static void SetLocale ()
		{
			Mvx.Resolve<ILocalization> ().SetLocale ();
		}

		public static string TestString ()
		{
			return Mvx.Resolve<ILocalization> ().TestString ();
		}

		public static string GetString (this Enum key)
		{

			Assembly asm = Mvx.Resolve<ILocalizationSettings> ().ResourceAssembly;
			string baseName = Mvx.Resolve<ILocalizationSettings> ().BaseName;

			Debug.WriteLine("Test Debug Print");
			if (dictionary.ContainsKey (key))
			{
				return dictionary [key];
			} 
			else
			{

				ResourceManager rm = new ResourceManager (baseName, asm);
				string result = rm.GetString (key.ToString (), ci);
				dictionary.Add (key, result);

				return result; 
			}
		}

		/*
		public static string GetString (this string key)
		{
			try
			{
				StringKey enumKey = (StringKey)Enum.Parse (typeof(StringKey), key);        
				if (Enum.IsDefined (typeof(StringKey), enumKey))
				{
					return enumKey.GetString ();
				}
			} 
			catch (ArgumentException ex)
			{
				Debug.WriteLine (ex);
			}
			return null;
		}*/

		public static string GetTwoLetterISOLangaugeName() {
			return ci?.TwoLetterISOLanguageName ?? "en";
		}
	}
}


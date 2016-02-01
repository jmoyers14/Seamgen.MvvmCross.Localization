using System;
using System.Globalization;

namespace Seamgen.MvvmCross.Localization
{
	public interface ILocalization
	{
		CultureInfo GetCurrentCultureInfo ();

		void SetLocale();

		string TestString();
	}
}


using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace Seamgen.MvvmCross.Localization.Touch
{
	public class Plugin : IMvxPlugin
	{
		public void Load ()
		{
			Mvx.RegisterSingleton<ILocalization> (new LocalizationPlugin ());
		}
	}
}

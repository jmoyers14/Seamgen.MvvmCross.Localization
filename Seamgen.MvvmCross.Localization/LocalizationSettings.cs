using System;
using System.Reflection;

namespace Seamgen.MvvmCross.Localization
{
	public class LocalizationSettings : ILocalizationSettings
	{
		public Assembly ResourceAssembly { get; set; }	
		public string BaseName { get; set; }
	}
}


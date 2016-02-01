using System;
using System.Reflection;

namespace Seamgen.MvvmCross.Localization
{
	public interface ILocalizationSettings
	{
		Assembly ResourceAssembly { get; set; }
		string BaseName { get; set; }
	}
}


using System.Reflection;
using Cirrious.CrossCore.Plugins;



namespace Seamgen.MvvmCross.Localization
{
	public class LocalizationConfiguration : IMvxPluginConfiguration
	{
		public Assembly ResourceAssembly { get; set; }
		public string BaseName { get; set; }
	}
}



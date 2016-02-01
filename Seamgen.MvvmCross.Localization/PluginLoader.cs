using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore;
using System.Reflection;

namespace Seamgen.MvvmCross.Localization
{
	public class PluginLoader : IMvxConfigurablePluginLoader, IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader ();

		private LocalizationConfiguration _localizationConfig;

		public void EnsureLoaded()
		{

			var localizationSettings = new LocalizationSettings {
				ResourceAssembly = _localizationConfig.ResourceAssembly,
				BaseName = _localizationConfig.BaseName,
			};
			Mvx.RegisterSingleton<ILocalizationSettings>(localizationSettings);

			var manager = Mvx.Resolve<IMvxPluginManager> ();
			manager.EnsurePlatformAdaptionLoaded<PluginLoader> ();

		}

		public void Configure(IMvxPluginConfiguration configuration)
		{
			if (configuration == null && !(configuration is LocalizationConfiguration))
				throw new MvxException("Plugin only supports instances of LocalizationConfiguration. You provided {0}", configuration.GetType().Name);

			_localizationConfig = (LocalizationConfiguration)configuration;
		}
	}
}


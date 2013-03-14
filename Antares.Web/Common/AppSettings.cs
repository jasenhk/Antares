using System;
using System.Web;
using System.Web.Mvc;

namespace Antares.Web
{
    public interface IAppSettings
    {
        bool UseSSL { get; }
    }

    public class AppSettings : IAppSettings
    {
        private const string AppKey = "__MyApplication__";

        private AppSettings()
        {
            // initialize values

            var appSettings = System.Configuration.ConfigurationManager.AppSettings;

            if (appSettings[AppSettingsKeys.UseSSL] == null || !Boolean.TryParse(appSettings[AppSettingsKeys.UseSSL], out useSsl))
            {
                useSsl = false;
            }
        }

        public static IAppSettings Current
        {
            get
            {
                IAppSettings settings = (AppSettings)HttpContext.Current.Application[AppKey];
                if (settings == null)
                {
                    settings = new AppSettings();
                    HttpContext.Current.Application[AppKey] = settings;
                }
                return settings;
            }
        }

        #region Application Variables

        private bool useSsl;
        public bool UseSSL { get { return useSsl; } }

        #endregion
    }

    public static class AppSettingsKeys
    {
        public const string UseSSL = "UseSSL";
    }
}
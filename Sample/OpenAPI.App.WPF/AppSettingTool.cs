using System.Configuration;
using System.Linq;

namespace OpenAPI.App.WPF
{
    public static class AppSettingTool
    {
        public const string ACCESS_TOKEN_KEY = "KKBOX_OPEN_API_TOKEN";

        private static Configuration config;

        static AppSettingTool()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public static string Get(string key)
        {
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                return config.AppSettings.Settings[key].Value;
            }
            else
            {
                config.AppSettings.Settings.Add(key, string.Empty);
                return string.Empty;
            }
        }

        public static void Set(string key, string value)
        {
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
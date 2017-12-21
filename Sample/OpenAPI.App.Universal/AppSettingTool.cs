using Windows.Storage;

namespace OpenAPI.App.Universal
{
    public static class AppSettingTool
    {
        public const string ACCESS_TOKEN_KEY = "KKBOX_OPEN_API_TOKEN";

        private static ApplicationDataContainer applicationDataContainer;

        static AppSettingTool()
        {
            applicationDataContainer = ApplicationData.Current.LocalSettings;
        }

        public static T Get<T>(string key)
        {
            object value = null;
            if (applicationDataContainer.Values.TryGetValue(key, out value))
            {
                return (T)value;
            }
            else
            {
                return default(T);
            }
        }

        public static void Set(string key, object value)
        {
            applicationDataContainer.Values[key] = value;
        }
    }
}
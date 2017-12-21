using KKBOX.OpenAPI.ServiceModel;

namespace KKBOX.OpenAPI
{
    internal class CommonDefine
    {
        internal const string API_TOKEN_URL = "https://account.kkbox.com/oauth2/token";

        internal const string KKBOX_OPEN_API_URL = "https://api.kkbox.com/v1.1/";

        /// <summary>
        /// The territory of a artist. Territory is mandatory in client credentials flow and is optional in authorization code flow.
        /// </summary>
        internal static TerritoryType TerritoryType { get; set; } = default(TerritoryType);

        internal static string AccessToken { get; set; } = string.Empty;
    }
}
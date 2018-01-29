using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// OAuth token data.
    /// </summary>
    public class OAuthTokenData
    {
        /// <summary>
        /// Access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Expires in.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExipresIn { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Scope.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
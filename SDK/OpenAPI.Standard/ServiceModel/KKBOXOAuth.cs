using KKBOX.OpenAPI.ServiceModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KKBOX.OpenAPI
{
    /// <summary>
    /// KKBOX OAuth 2.0 Authorize API.
    /// </summary>
    public partial class KKBOXOAuth
    {
        /// <summary>
        /// OAuth 2.0 Token API for Client Credentials Flow
        /// </summary>
        /// <param name="clientId">The id of OAuth 2.0.</param>
        /// <param name="clientSecret">The secret of OAuth 2.0.</param>
        /// <returns><see cref="KKOAuthResponse"/></returns>
        public static async Task<KKOAuthResponse> SignInAsync(string clientId, string clientSecret)
        {
            string authorizeCode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            List<KeyValuePair<string, string>> postParameter = new List<KeyValuePair<string, string>>();
            postParameter.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            var result = await OAuthHttpService.RequestAccessTokenAsync(postParameter, authorizeCode);

            return result;
        }
    }
}
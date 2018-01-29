using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KKBOX.OpenAPI.ServiceModel
{
    internal class OAuthHttpService
    {
        internal static async Task<KKOAuthResponse> RequestAccessTokenAsync(List<KeyValuePair<string, string>> postParameter, string authHeader = "")
        {
            KKOAuthResponse returnData = new KKOAuthResponse();

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(CommonDefine.API_TOKEN_URL));
                request.Content = new FormUrlEncodedContent(postParameter);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                if (string.IsNullOrEmpty(authHeader) == false)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                }

                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonData = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(jsonData);

                        if (jsonData.Contains("access_token"))
                        {
                            //{"access_token":"","scope":"all","token_type":""}
                            returnData.Content = JsonConvert.DeserializeObject<OAuthTokenData>(jsonData);
                            returnData.Staus = APIStatus.Success;
                        }
                        else
                        {
                            // "error": "invalid_grant"
                            returnData.Content = null;
                            returnData.ErrorMessage = jsonData;
                            returnData.Staus = APIStatus.Failed;
                        }
                    }
                    else
                    {
                        returnData.Staus = APIStatus.Failed;
                    }
                }
            }

            return returnData;
        }
    }
}
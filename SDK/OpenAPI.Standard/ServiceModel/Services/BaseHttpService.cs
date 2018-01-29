using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KKBOX.OpenAPI.ServiceModel
{
    internal class BaseHttpService<TResult>
        where TResult : new()
    {
        internal Dictionary<string, string> QueryString { get; set; } = new Dictionary<string, string>();

        internal HttpContent Content { get; set; }

        internal HttpMethod Method { get; set; } = HttpMethod.Get;

        internal string URL { get; set; } = string.Empty;

        internal bool AppendTerritory { get; set; } = true;

        internal int? Limit { get; set; }

        internal int? Offset { get; set; }

        public BaseHttpService()
        {

        }

        public BaseHttpService(int? limit, int? offset)
        {
            this.Limit = limit;
            this.Offset = offset;
        }

        internal void SetOffset(int? limit, int? offset)
        {
            if (limit != null)
            {
                Limit = (int)limit;
            }

            if (offset != null)
            {
                Offset = (int)offset;
            }
        }

        internal void PrepareQueryString()
        {
            if (AppendTerritory)
            {
                QueryString.Add("territory", CommonDefine.TerritoryType.ToString());
            }

            if (Limit != null)
            {
                QueryString.Add("limit", Limit.ToString());
            }

            if (Offset != null)
            {
                QueryString.Add("offset", Offset.ToString());
            }
        }

        internal async Task<ParseResult<TResult>> InvokeAsync()
        {
            string apiURL = GenerateRequqestURL();

            Debug.WriteLine(apiURL);

            string accessKey = CommonDefine.AccessToken;
            HttpRequestMessage requestParameter = new HttpRequestMessage(Method, new Uri(apiURL));
            requestParameter.Content = Content;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessKey);
                if (requestParameter.Method == HttpMethod.Post)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                using (HttpResponseMessage response = await client.SendAsync(requestParameter))
                {
                    var cryptTask = await response.Content.ReadAsByteArrayAsync();
                    string json = Encoding.UTF8.GetString(cryptTask, 0, cryptTask.Length);

                    Debug.WriteLine(json);

                    ParseResult<TResult> result = new ParseResult<TResult>();

                    if (response.IsSuccessStatusCode)
                    {
                        result.Content = JsonConvert.DeserializeObject<TResult>(json);
                    }
                    else
                    {
                        result.Error = ParseErrorData(json);
                    }

                    return result;
                }
            }
        }

        private string GenerateRequqestURL()
        {
            string parameter = string.Empty;

            PrepareQueryString();

            if (QueryString != null && QueryString.Count > 0)
            {
                parameter += $"{string.Join("&", QueryString.Select(x => $"{x.Key}={WebUtility.UrlEncode(x.Value)}").ToArray())}";
            }

            string newUrl = $"{CommonDefine.KKBOX_OPEN_API_URL}{URL}?{parameter}";

            return newUrl;
        }

        private ErrorData ParseErrorData(string json)
        {
            try
            {
                var errorJson = JObject.Parse(json);
                var errorToken = errorJson["error"];

                return JsonConvert.DeserializeObject<ErrorData>(errorToken.ToString());
            }
            catch (Exception ex)
            {
                return new ErrorData
                {
                    Message = ex.Message
                };
            }
        }
    }
}
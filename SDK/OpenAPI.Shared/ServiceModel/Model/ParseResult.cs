using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Indicated API response.
    /// </summary>
    public class ParseResult<T>
    {
        /// <summary>
        /// API response content.
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// API error content.
        /// </summary>
        public ErrorData Error { get; set; }
    }

    /// <summary>
    /// API error content.
    /// </summary>
    public class ErrorData
    {
        /// <summary>
        /// Message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
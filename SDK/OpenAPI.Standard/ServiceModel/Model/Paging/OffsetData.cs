using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Include PagingData Class.
    /// </summary>
    public class OffsetData<T>
    {
        /// <summary>
        /// Data tag.
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// Paging tag. <see cref="PagingData"/>
        /// </summary>
        [JsonProperty("paging")]
        public PagingData Paging { get; set; }

        /// <summary>
        /// Summary tag. <see cref="SummaryData"/>
        /// </summary>
        [JsonProperty("summary")]
        public SummaryData Summary { get; set; }
    }
}
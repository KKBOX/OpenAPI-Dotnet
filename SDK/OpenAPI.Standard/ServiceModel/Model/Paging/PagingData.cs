using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Paging information.
    /// </summary>
    public class PagingData
    {
        /// <summary>
        /// The index offset for first element.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// The size of one page.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }
        
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        /// <summary>
        /// Is to the last data.
        /// </summary>
        public bool IsEnd()
        {
            return string.IsNullOrEmpty(Next) ? true : false;
        }

        /// <summary>
        /// Get next offset.
        /// </summary>
        public int NextOffset()
        {
            return Limit + Offset;
        }
    }
}
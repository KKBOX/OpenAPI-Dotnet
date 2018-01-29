using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Station data collection.
    /// </summary>
    public class StationListData
    {
        /// <summary>
        /// Station collection.
        /// </summary>
        [JsonProperty("data")]
        public List<StationData> Stations { get; set; }

        [JsonProperty("paging")]
        public string Paging { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
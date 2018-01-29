using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Station collection with offset data.
    /// </summary>
    public class StationOffsetData : OffsetData<List<StationData>>
    {

    }

    /// <summary>
    /// Station metadata.
    /// </summary>
    public class StationData
    {
        /// <summary>
        /// For Genre station.
        /// </summary>
        [JsonProperty("category")]
        public string Categroy { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tracks")]
        public OffsetData<List<TrackData>> Tracks { get; set; }

        /// <summary>
        /// For Moog station.
        /// </summary>
        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }
    }
}
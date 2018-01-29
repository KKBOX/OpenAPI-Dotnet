using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Track collection with offset data.
    /// </summary>
    public class TrackOffsetData : OffsetData<List<TrackData>>
    {
    }

    /// <summary>
    /// Track metadata.
    /// </summary>
    public class TrackData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public double? Duration { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("explicitness")]
        public bool Explicitness { get; set; }
        
        [JsonProperty("album")]
        public AlbumData Album { get; set; }

        [JsonProperty("available_territories")]
        public List<string> AvailableTerritories { get; set; }
    }
}
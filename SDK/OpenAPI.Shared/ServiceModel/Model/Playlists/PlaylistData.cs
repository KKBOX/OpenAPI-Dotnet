using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Playlist collection with offset data.
    /// </summary>
    public class PlaylistOffsetData : OffsetData<List<PlaylistData>>
    {

    }

    /// <summary>
    /// Playlist metadata.
    /// </summary>
    public class PlaylistData
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("updated_at")]
        public string UpdateAt { get; set; }

        [JsonProperty("owner")]
        public OwnerData Owner { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }

        [JsonProperty("tracks")]
        public OffsetData<List<TrackData>> Tracks { get; set; }
    }
}
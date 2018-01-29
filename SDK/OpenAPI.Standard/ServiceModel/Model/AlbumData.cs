using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Album collection with offset data.
    /// </summary>
    public class AlbumOffsetData : OffsetData<List<AlbumData>>
    {
    }

    /// <summary>
    /// Album meatadata.
    /// </summary>
    public class AlbumData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("artist")]
        public ArtistData Artist { get; set; }

        [JsonProperty("available_territories")]
        public List<string> AvailableTerritories { get; set; }

        [JsonProperty("explicitness")]
        public bool Explicitness { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
using Newtonsoft.Json;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Ower of the Playlist.
    /// </summary>
    public class OwnerData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
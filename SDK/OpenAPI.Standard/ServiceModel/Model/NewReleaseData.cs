using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// New release metadata.
    /// </summary>
    public class NewReleaseData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("albums")]
        public OffsetData<List<AlbumData>> Albums { get; set; }
    }
}
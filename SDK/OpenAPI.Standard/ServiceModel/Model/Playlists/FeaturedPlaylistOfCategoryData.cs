using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Featured Playlists of the category.
    /// </summary>
    public class FeaturedPlaylistOfCategoryData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }

        [JsonProperty("playlists")]
        public OffsetData<List<PlaylistData>> Playlists { get; set; }
    }
}
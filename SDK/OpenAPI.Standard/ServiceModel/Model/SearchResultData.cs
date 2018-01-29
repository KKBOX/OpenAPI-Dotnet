using Newtonsoft.Json;
using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// Search result.
    /// </summary>
    public class SearchResultData
    {
        /// <summary>
        /// Track data collection.
        /// </summary>
        [JsonProperty("tracks")]
        public OffsetData<List<TrackData>> Tracks { get; set; }

        /// <summary>
        /// Album data collection.
        /// </summary>
        [JsonProperty("albums")]
        public OffsetData<List<AlbumData>> Albums { get; set; }

        /// <summary>
        /// Artist data collection.
        /// </summary>
        [JsonProperty("artists")]
        public OffsetData<List<ArtistData>> Artists { get; set; }

        /// <summary>
        /// Playlist data collection.
        /// </summary>
        [JsonProperty("playlists")]
        public OffsetData<List<PlaylistData>> Playlists { get; set; }

        [JsonProperty("paging")]
        public PagingData Paging { get; set; }

        [JsonProperty("summary")]
        public SummaryData Summary { get; set; }
    }
}
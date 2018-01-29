namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlists/{playlist_id}/tracks
    /// </summary>
    internal class FeaturedPlaylistPlaylistTracksService : BaseHttpService<TrackOffsetData>
    {
        internal FeaturedPlaylistPlaylistTracksService(string playlistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"featured-playlists/{playlistId}/tracks";
            SetOffset(limit, offset);
        }
    }
}
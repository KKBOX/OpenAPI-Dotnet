namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /shared-playlists/{playlist_id}/tracks
    /// </summary>
    internal class SharedPlaylistTracksService : BaseHttpService<TrackOffsetData>
    {
        internal SharedPlaylistTracksService(string playlistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"shared-playlists/{playlistId}/tracks";
            SetOffset(limit, offset);
        }
    }
}
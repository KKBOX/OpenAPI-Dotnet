namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-hits-playlists/{playlist_id}/tracks
    /// </summary>
    internal class NewHitsPlaylistsPlaylistTracksService : BaseHttpService<TrackOffsetData>
    {
        internal NewHitsPlaylistsPlaylistTracksService(string playlistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"new-hits-playlists/{playlistId}/tracks";
            SetOffset(limit, offset);
        }
    }
}
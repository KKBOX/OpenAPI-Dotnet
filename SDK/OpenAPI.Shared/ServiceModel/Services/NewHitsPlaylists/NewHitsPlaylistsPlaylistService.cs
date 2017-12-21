namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-hits-playlists/{playlist_id}
    /// </summary>
    internal class NewHitsPlaylistsPlaylistService : BaseHttpService<PlaylistData>
    {
        internal NewHitsPlaylistsPlaylistService(string playlistId)
        {
            URL = $"new-hits-playlists/{playlistId}";
        }
    }
}
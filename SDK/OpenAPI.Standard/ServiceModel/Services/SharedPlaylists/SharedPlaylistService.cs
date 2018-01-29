namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /shared-playlists/{playlist_id}
    /// </summary>
    internal class SharedPlaylistService : BaseHttpService<PlaylistData>
    {
        internal SharedPlaylistService(string playlistId)
        {
            URL = $"shared-playlists/{playlistId}";
        }
    }
}
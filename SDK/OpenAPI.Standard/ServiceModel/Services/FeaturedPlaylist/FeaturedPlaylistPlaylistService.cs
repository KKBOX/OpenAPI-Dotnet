namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlists/{playlist_id}
    /// </summary>
    internal class FeaturedPlaylistPlaylistService : BaseHttpService<PlaylistData>
    {
        internal FeaturedPlaylistPlaylistService(string playlistId)
        {
            URL = $"featured-playlists/{playlistId}";
        }
    }
}
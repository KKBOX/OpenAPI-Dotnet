namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /charts/{playlist_id}
    /// </summary>
    internal class ChartPlaylistService : BaseHttpService<PlaylistData>
    {
        internal ChartPlaylistService(string playlistId)
        {
            URL = $"charts/{playlistId}";
        }
    }
}
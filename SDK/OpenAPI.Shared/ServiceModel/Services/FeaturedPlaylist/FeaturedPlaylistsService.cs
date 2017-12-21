namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlists
    /// </summary>
    internal class FeaturedPlaylistsService : BaseHttpService<PlaylistOffsetData>
    {
        internal FeaturedPlaylistsService(int? limit, int? offset) : base(100, 0)
        {
            URL = $"featured-playlists";
            SetOffset(limit, offset);
        }
    }
}
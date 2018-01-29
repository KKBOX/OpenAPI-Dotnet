namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlist-categories/{category_id}/playlists
    /// </summary>
    internal class FeaturedPlaylistCategoryPlaylistsService : BaseHttpService<PlaylistOffsetData>
    {
        internal FeaturedPlaylistCategoryPlaylistsService(string categoryId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"featured-playlist-categories/{categoryId}/playlists";
            SetOffset(limit, offset);
        }
    }
}
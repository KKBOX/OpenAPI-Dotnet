namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlist-categories
    /// </summary>
    internal class FeaturedPlaylistCategoriesService : BaseHttpService<PlaylistOffsetData>
    {
        internal FeaturedPlaylistCategoriesService(int? limit, int? offset) : base(100, 0)
        {
            URL = $"featured-playlist-categories";
        }
    }
}
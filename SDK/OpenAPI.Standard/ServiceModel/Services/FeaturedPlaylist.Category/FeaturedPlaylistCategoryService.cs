namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /featured-playlist-categories/{category_id}
    /// </summary>
    internal class FeaturedPlaylistCategoryService : BaseHttpService<FeaturedPlaylistOfCategoryData>
    {
        internal FeaturedPlaylistCategoryService(string categoryId)
        {
            URL = $"featured-playlist-categories/{categoryId}";
        }
    }
}
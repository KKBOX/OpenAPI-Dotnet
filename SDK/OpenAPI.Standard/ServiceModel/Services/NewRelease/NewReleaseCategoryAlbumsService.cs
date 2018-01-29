namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-release-categories/{category_id}/albums
    /// </summary>
    internal class NewReleaseCategoryAlbumsService : BaseHttpService<AlbumOffsetData>
    {
        internal NewReleaseCategoryAlbumsService(string categoryId, int? limit, int?offset) : base(50, 0)
        {
            URL = $"new-release-categories/{categoryId}/albums";
            SetOffset(limit, offset);
        }
    }
}
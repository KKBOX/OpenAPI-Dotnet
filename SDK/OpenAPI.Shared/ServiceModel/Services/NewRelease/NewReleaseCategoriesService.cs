namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-release-categories
    /// </summary>
    internal class NewReleaseCategoriesService : BaseHttpService<BaseItemOffsetData>
    {
        internal NewReleaseCategoriesService(int? limit, int? offset) : base(50, 0)
        {
            URL = $"new-release-categories";
            SetOffset(limit, offset);
        }
    }
}
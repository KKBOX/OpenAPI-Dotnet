namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-release-categories/{category_id}
    /// </summary>
    internal class NewReleaseCategoryService : BaseHttpService<NewReleaseData>
    {
        internal NewReleaseCategoryService(string categoryId)
        {
            URL = $"new-release-categories/{categoryId}";
        }
    }
}
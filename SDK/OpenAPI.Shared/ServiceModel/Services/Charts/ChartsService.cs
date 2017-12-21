namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /charts
    /// </summary>
    internal class ChartsService : BaseHttpService<PlaylistOffsetData>
    {
        internal ChartsService(int? limit, int? offset) : base(50, 0)
        {
            URL = $"charts";
            SetOffset(limit, offset);
        }
    }
}
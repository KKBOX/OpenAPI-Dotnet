namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /mood-stations
    /// </summary>
    internal class MoodStationsService : BaseHttpService<BaseItemOffsetData>
    {
        internal MoodStationsService(int? limit, int? offset) : base(100, 0)
        {
            URL = $"mood-stations";
            SetOffset(limit, offset);
        }
    }
}
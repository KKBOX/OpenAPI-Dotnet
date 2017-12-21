namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /mood-stations/{station_id}
    /// </summary>
    internal class MoodStationService : BaseHttpService<StationData>
    {
        internal MoodStationService(string moodStationId)
        {
            URL = $"mood-stations/{moodStationId}";
        }
    }
}
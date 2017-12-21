namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /genre-stations/{station_id}
    /// </summary>
    internal class GenreStationService : BaseHttpService<StationData>
    {
        internal GenreStationService(string genreStationId)
        {
            URL = $"genre-stations/{genreStationId}";
        }
    }
}
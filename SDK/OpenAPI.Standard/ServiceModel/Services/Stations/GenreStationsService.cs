using System.Collections.Generic;

namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /genre-stations
    /// </summary>
    internal class GenreStationsService : BaseHttpService<StationOffsetData>
    {
        internal GenreStationsService(int? limit, int? offset) : base(100, 0)
        {
            URL = $"genre-stations";
            SetOffset(limit, offset);
        }
    }
}
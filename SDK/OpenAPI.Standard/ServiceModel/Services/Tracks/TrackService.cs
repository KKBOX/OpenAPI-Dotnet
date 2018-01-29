namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /tracks/{track_id}
    /// </summary>
    internal class TrackService : BaseHttpService<TrackData>
    {
        internal TrackService(string trackId)
        {
            URL = $"tracks/{trackId}";
        }
    }
}
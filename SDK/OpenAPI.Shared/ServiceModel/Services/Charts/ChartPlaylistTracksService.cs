namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /charts/{playlist_id}/tracks
    /// </summary>
    internal class ChartPlaylistTracksService : BaseHttpService<TrackOffsetData>
    {
        internal ChartPlaylistTracksService(string playlistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"charts/{playlistId}/tracks";
            SetOffset(limit, offset);
        }
    }
}
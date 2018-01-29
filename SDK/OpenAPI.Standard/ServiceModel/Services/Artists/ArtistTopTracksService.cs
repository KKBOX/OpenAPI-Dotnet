namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /artists/{artist_id}/top-tracks
    /// </summary>
    internal class ArtistTopTracksService : BaseHttpService<TrackOffsetData>
    {
        internal ArtistTopTracksService(string artistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"artists/{artistId}/top-tracks";
            SetOffset(limit, offset);
        }
    }
}
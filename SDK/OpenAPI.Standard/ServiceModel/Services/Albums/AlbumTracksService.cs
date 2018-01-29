namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /albums/{album_id}/tracks
    /// </summary>
    internal class AlbumTracksService : BaseHttpService<TrackOffsetData>
    {
        internal AlbumTracksService(string albumId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"albums/{albumId}/tracks";
            SetOffset(limit, offset);
        }
    }
}
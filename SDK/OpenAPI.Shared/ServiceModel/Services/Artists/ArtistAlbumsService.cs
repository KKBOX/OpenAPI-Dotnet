namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /artists/{artist_id}/albums
    /// </summary>
    internal class ArtistAlbumsService : BaseHttpService<AlbumOffsetData>
    {
        internal ArtistAlbumsService(string artistId, int? limit, int? offset) : base(100, 0)
        {
            URL = $"artists/{artistId}/albums";
            SetOffset(limit, offset);
        }
    }
}
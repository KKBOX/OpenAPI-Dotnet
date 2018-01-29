namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /artists/{artist_id}
    /// </summary>
    internal class ArtistService : BaseHttpService<ArtistData>
    {
        internal ArtistService(string artistId)
        {
            URL = $"artists/{artistId}";
        }
    }
}
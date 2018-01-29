namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /albums/{album_id} 
    /// </summary>
    internal class AlbumService : BaseHttpService<AlbumData>
    {
        internal AlbumService(string albumId)
        {
            URL = $"albums/{albumId}";
        }
    }
}
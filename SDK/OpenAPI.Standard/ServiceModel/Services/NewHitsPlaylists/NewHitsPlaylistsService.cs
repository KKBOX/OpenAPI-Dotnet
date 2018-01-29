namespace KKBOX.OpenAPI.ServiceModel
{
    /// <summary>
    /// GET /new-hits-playlists
    /// </summary>
    internal class NewHitsPlaylistsService : BaseHttpService<PlaylistOffsetData>
    {
        internal NewHitsPlaylistsService(int? limit, int? offset) : base(10, 0)
        {
            URL = $"new-hits-playlists";
            SetOffset(limit, offset);
        }
    }
}
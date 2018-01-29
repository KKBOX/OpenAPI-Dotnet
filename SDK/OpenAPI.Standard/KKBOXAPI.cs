using KKBOX.OpenAPI.ServiceModel;
using System;
using System.Threading.Tasks;

namespace KKBOX.OpenAPI
{
    /// <summary>
    /// <para>The instance of the KKBOX Open API</para>
    /// </summary>
    public sealed partial class KKBOXAPI
    {
        /// <summary>
        /// Current access token.
        /// </summary>
        public string AccessToken
        {
            get { return CommonDefine.AccessToken; }
            set { CommonDefine.AccessToken = value; }
        }

        /// <summary>
        /// Current territory.
        /// </summary>
        public TerritoryType TerritoryType
        {
            get { return CommonDefine.TerritoryType; }
            set { CommonDefine.TerritoryType = value; }
        }

        public KKBOXAPI() { }

        public KKBOXAPI(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Lost KKBOX Open API access token.");
            }

            AccessToken = accessToken;
        }

        #region Albums
        /// <summary>
        /// To retrieve information of the album with {album_id}.
        /// </summary>
        /// <param name="albumId">album_id</param>
        /// <example>
        /// <code>
        /// var album = await KKBOXAPI.GetAlbumAsync(albumId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="AlbumData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<AlbumData>> GetAlbumAsync(string albumId)
        {
            return await new AlbumService(albumId).InvokeAsync();
        }

        /// <summary>
        /// List of tracks of an album.
        /// </summary>
        /// <param name="albumId">album_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var tracks = await KKBOXAPI.GetTracksOfAlbumAsync(albumId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetTracksOfAlbumAsync(string albumId, int? limit = null, int? offset = null)
        {
            return await new AlbumTracksService(albumId, limit, offset).InvokeAsync();
        }
        #endregion

        #region Artist
        /// <summary>
        /// To retrieve information of the artist with {artist_id}.
        /// </summary>
        /// <param name="artistId">artist_id</param>
        /// <example>
        /// <code>
        /// var artist = await KKBOXAPI.GetArtistAsync(artistId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="ArtistData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<ArtistData>> GetArtistAsync(string artistId)
        {
            return await new ArtistService(artistId).InvokeAsync();
        }

        /// <summary>
        /// List of albums of an artist.
        /// </summary>
        /// <param name="artistId">artist_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var albums = await KKBOXAPI.GetAlbumsOfArtistAsync(artistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="AlbumOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<AlbumOffsetData>> GetAlbumsOfArtistAsync(string artistId, int? limit = null, int? offset = null)
        {
            return await new ArtistAlbumsService(artistId, limit, offset).InvokeAsync();
        }

        /// <summary>
        /// List of top tracks of an artist.
        /// </summary>
        /// <param name="artistId">artist_Id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var topTracks = await KKBOXAPI.GetTopTracksOfArtistAsync(artistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetTopTracksOfArtistAsync(string artistId, int? limit = null, int? offset = null)
        {
            return await new ArtistTopTracksService(artistId, limit, offset).InvokeAsync();
        }
        #endregion

        #region Charts
        /// <summary>
        /// List of song rankings.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var chartList = await KKBOXAPI.GetChartListAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistOffsetData>> GetChartListAsync(int? limit = null, int? offset = null)
        {
            return await new ChartsService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the song ranking with {playlist_id}.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <example>
        /// <code>
        /// var playlist = await KKBOXAPI.GetPlaylistOfChartAsync(playlistId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistData>> GetPlaylistOfChartAsync(string playlistId)
        {
            return await new ChartPlaylistService(playlistId).InvokeAsync();
        }

        /// <summary>
        /// List tracks of a chart playlist.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var playlist = await KKBOXAPI.GetPlaylistTracksOfChartAsync(playlistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetPlaylistTracksOfChartAsync(string playlistId, int? limit = null, int? offset = null)
        {
            return await new ChartPlaylistTracksService(playlistId, limit, offset).InvokeAsync();
        }
        #endregion

        #region Featured Playlists
        /// <summary>
        /// List of songs hand-picked and arranged by KKBOX editors.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var featuredPlaylists = await KKBOXAPI.GetFeaturedPlaylistsAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistOffsetData>> GetFeaturedPlaylistsAsync(int? limit = null, int? offset = null)
        {
            return await new FeaturedPlaylistsService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the featured playlist with {playlist_id}.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <example>
        /// <code>
        /// var playlist = await KKBOXAPI.GetPlaylistOfFeaturedPlaylistsAsync(playlistId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistData>> GetPlaylistOfFeaturedPlaylistsAsync(string playlistId)
        {
            return await new FeaturedPlaylistPlaylistService(playlistId).InvokeAsync();
        }

        /// <summary>
        /// List the songs of a featured playlist.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var tracks = await KKBOXAPI.GetPlaylistTracksOfFeaturedPlaylistsAsync(playlistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetPlaylistTracksOfFeaturedPlaylistsAsync(string playlistId, int? limit = null, int? offset = null)
        {
            return await new FeaturedPlaylistPlaylistTracksService(playlistId, limit, offset).InvokeAsync();
        }
        #endregion

        #region Featured Playlist Categories
        /// <summary>
        /// List of featured playlist categories.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var categories = await KKBOXAPI.GetFeaturedPlaylistCategoriesAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistOffsetData>> GetFeaturedPlaylistCategoriesAsync(int? limit = null, int? offset = null)
        {
            return await new FeaturedPlaylistCategoriesService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// Get A Featured Playlist Category.
        /// </summary>
        /// <param name="categoryId">category_id</param>
        /// <example>
        /// <code>
        /// var featuredPlaylist = await KKBOXAPI.GetFeaturedPlaylistCategoryAsync(categoryId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="FeaturedPlaylistOfCategoryData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<FeaturedPlaylistOfCategoryData>> GetFeaturedPlaylistCategoryAsync(string categoryId)
        {
            return await new FeaturedPlaylistCategoryService(categoryId).InvokeAsync();
        }

        /// <summary>
        /// List of playlists of a featured playlist category.
        /// </summary>
        /// <param name="categoryId">category_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var playlists = await KKBOXAPI.GetPlaylistsOfFeaturedPlaylistCategoryAsync(categoryId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistOffsetData>> GetPlaylistsOfFeaturedPlaylistCategoryAsync(string categoryId, int? limit = null, int? offset = null)
        {
            return await new FeaturedPlaylistCategoryPlaylistsService(categoryId, limit, offset).InvokeAsync();
        }
        #endregion

        #region Mood Stations
        /// <summary>
        /// List of mood stations.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var moodStations = await KKBOXAPI.GetMoodStationListAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="BaseItemOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<BaseItemOffsetData>> GetMoodStationListAsync(int? limit = null, int? offset = null)
        {
            return await new MoodStationsService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the mood station with {station_id}.
        /// </summary>
        /// <param name="stationId">station_id</param>
        /// <example>
        /// <code>
        /// var station = await KKBOXAPI.GetMoodStationAsync(stationId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="StationData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<StationData>> GetMoodStationAsync(string stationId)
        {
            return await new MoodStationService(stationId).InvokeAsync();
        }
        #endregion

        #region Genre Stations
        /// <summary>
        /// List of genre stations.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var genreStations = await KKBOXAPI.GetGenreStationListAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="OffsetData{T}"/><![CDATA[ < ]]><see cref="StationOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<StationOffsetData>> GetGenreStationListAsync(int? limit = null, int? offset = null)
        {
            return await new GenreStationsService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the genre station with {station_id}.
        /// </summary>
        /// <param name="stationId">station_id</param>
        /// <example>
        /// <code>
        /// var station = await KKBOXAPI.GetGenreStationAsync(stationId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="StationData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<StationData>> GetGenreStationAsync(string stationId)
        {
            return await new GenreStationService(stationId).InvokeAsync();
        }
        #endregion

        #region New release 
        /// <summary>
        /// List of new release categories.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var categories = await KKBOXAPI.GetNewReleaseCategoriesAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="BaseItemOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<BaseItemOffsetData>> GetNewReleaseCategoriesAsync(int? limit = null, int? offset = null)
        {
            return await new NewReleaseCategoriesService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the new release category with {category_id}.
        /// </summary>
        /// <param name="categoryId">category_id</param>
        /// <example>
        /// <code>
        /// var newRelease = await KKBOXAPI.GetNewReleaseCategoryAsync(categoryId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="NewReleaseData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<NewReleaseData>> GetNewReleaseCategoryAsync(string categoryId)
        {
            return await new NewReleaseCategoryService(categoryId).InvokeAsync();
        }

        /// <summary>
        /// List of albums of a new release category.
        /// </summary>
        /// <param name="categoryId">category_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var albums = await KKBOXAPI.GetAlbumsOfNewReleaseCategoryAsync(categoryId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="AlbumOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<AlbumOffsetData>> GetAlbumsOfNewReleaseCategoryAsync(string categoryId, int? limit = null, int? offset = null)
        {
            return await new NewReleaseCategoryAlbumsService(categoryId, limit, offset).InvokeAsync();
        }
        #endregion

        #region New Hits Playlists
        /// <summary>
        /// List of new hits playlists.
        /// </summary>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var playlists = await KKBOXAPI.GetNewHitsPlaylistsAsync(100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistOffsetData>> GetNewHitsPlaylistsAsync(int? limit = null, int? offset = null)
        {
            return await new NewHitsPlaylistsService(limit, offset).InvokeAsync();
        }

        /// <summary>
        /// To retrieve information of the new hits playlist with {playlist_id}.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <example>
        /// <code>
        /// var playlist = await KKBOXAPI.GetPlaylistOfNewHitsPlaylistsAsync(playlistId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistData>> GetPlaylistOfNewHitsPlaylistsAsync(string playlistId)
        {
            return await new NewHitsPlaylistsPlaylistService(playlistId).InvokeAsync();
        }

        /// <summary>
        /// List of tracks of a new hits playlist.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var tracks = await KKBOXAPI.GetPlaylistTracksOfNewHitsPlaylistsAsync(playlistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetPlaylistTracksOfNewHitsPlaylistsAsync(string playlistId, int? limit = null, int? offset = null)
        {
            return await new NewHitsPlaylistsPlaylistTracksService(playlistId, limit, offset).InvokeAsync();
        }
        #endregion        

        #region Shared Playlist
        /// <summary>
        /// To retrieve information of the shared playlist with {playlist_id}.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <example>
        /// <code>
        /// var playlist = await KKBOXAPI.GetSharedPlaylistAsync(playlistId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="PlaylistData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<PlaylistData>> GetSharedPlaylistAsync(string playlistId)
        {
            return await new SharedPlaylistService(playlistId).InvokeAsync();
        }

        /// <summary>
        /// List of songs of a shared playlist.
        /// </summary>
        /// <param name="playlistId">playlist_id</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <example>
        /// <code>
        /// var tracks = await KKBOXAPI.GetTracksOfSharedPlaylistAsync(playlistId, 100, 0);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackOffsetData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackOffsetData>> GetTracksOfSharedPlaylistAsync(string playlistId, int? limit = null, int? offset = null)
        {
            return await new SharedPlaylistTracksService(playlistId, limit, offset).InvokeAsync();
        }
        #endregion

        /// <summary>
        /// To retrieve information of the song with {track_id}.
        /// </summary>
        /// <param name="trackId">track_id</param>
        /// <example>
        /// <code>
        /// var track = await KKBOXAPI.GetTrackAsync(trackId);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="TrackData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<TrackData>> GetTrackAsync(string trackId)
        {
            return await new TrackService(trackId).InvokeAsync();
        }

        /// <summary>
        /// Search for various objects.
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <param name="limit">The size of one page</param>
        /// <param name="offset">The index offset for first element.</param>
        /// <param name="types">artist, album, track, playlist</param>
        /// <example>
        /// <code>
        /// var search = await KKBOXAPI.SearchAsync(keyword, 15, 0, SearchType.track, SearchType.album, SearchType.playlist, SearchType.artist);
        /// </code>
        /// </example>
        /// <returns>
        /// <see cref="ParseResult{T}"/><![CDATA[ < ]]><see cref="SearchResultData"/><![CDATA[ > ]]>
        /// </returns>
        public async Task<ParseResult<SearchResultData>> SearchAsync(string keyword, int? limit = null, int? offset = null, params SearchType[] types)
        {
            var service = new SearchService(keyword, types);
            service.SetOffset(limit, offset);

            return await service.InvokeAsync();
        }
    }
}
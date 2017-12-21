## `KKBOXAPI`

The instance of the KKBOX Open API
```csharp
public class KKBOX.OpenAPI.KKBOXAPI

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | AccessToken | Current access token. |  | 
| `TerritoryType` | TerritoryType | Current territory. |  | 


Methods

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Task<ParseResult<AlbumData>>` | GetAlbumAsync(`String` albumId) | To retrieve information of the album with {album_id}. | var album = await KKBOXAPI.GetAlbumAsync(albumId); | 
| `Task<ParseResult<AlbumOffsetData>>` | GetAlbumsOfArtistAsync(`String` artistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of albums of an artist. | var albums = await KKBOXAPI.GetAlbumsOfArtistAsync(artistId, 100, 0); | 
| `Task<ParseResult<AlbumOffsetData>>` | GetAlbumsOfNewReleaseCategoryAsync(`String` categoryId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of albums of a new release category. | var albums = await KKBOXAPI.GetAlbumsOfNewReleaseCategoryAsync(categoryId, 100, 0); | 
| `Task<ParseResult<ArtistData>>` | GetArtistAsync(`String` artistId) | To retrieve information of the artist with {artist_id}. | var artist = await KKBOXAPI.GetArtistAsync(artistId); | 
| `Task<ParseResult<PlaylistOffsetData>>` | GetChartListAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of song rankings. | var chartList = await KKBOXAPI.GetChartListAsync(100, 0); | 
| `Task<ParseResult<PlaylistOffsetData>>` | GetFeaturedPlaylistCategoriesAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of featured playlist categories. | var categories = await KKBOXAPI.GetFeaturedPlaylistCategoriesAsync(100, 0); | 
| `Task<ParseResult<FeaturedPlaylistOfCategoryData>>` | GetFeaturedPlaylistCategoryAsync(`String` categoryId) | Get A Featured Playlist Category. | var featuredPlaylist = await KKBOXAPI.GetFeaturedPlaylistCategoryAsync(categoryId); | 
| `Task<ParseResult<PlaylistOffsetData>>` | GetFeaturedPlaylistsAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of songs hand-picked and arranged by KKBOX editors. | var featuredPlaylists = await KKBOXAPI.GetFeaturedPlaylistsAsync(100, 0); | 
| `Task<ParseResult<StationData>>` | GetGenreStationAsync(`String` stationId) | To retrieve information of the genre station with {station_id}. | var station = await KKBOXAPI.GetGenreStationAsync(stationId); | 
| `Task<ParseResult<StationOffsetData>>` | GetGenreStationListAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of genre stations. | var genreStations = await KKBOXAPI.GetGenreStationListAsync(100, 0); | 
| `Task<ParseResult<StationData>>` | GetMoodStationAsync(`String` stationId) | To retrieve information of the mood station with {station_id}. | var station = await KKBOXAPI.GetMoodStationAsync(stationId); | 
| `Task<ParseResult<BaseItemOffsetData>>` | GetMoodStationListAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of mood stations. | var moodStations = await KKBOXAPI.GetMoodStationListAsync(100, 0); | 
| `Task<ParseResult<PlaylistOffsetData>>` | GetNewHitsPlaylistsAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of new hits playlists. | var playlists = await KKBOXAPI.GetNewHitsPlaylistsAsync(100, 0); | 
| `Task<ParseResult<BaseItemOffsetData>>` | GetNewReleaseCategoriesAsync(`Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of new release categories. | var categories = await KKBOXAPI.GetNewReleaseCategoriesAsync(100, 0); | 
| `Task<ParseResult<NewReleaseData>>` | GetNewReleaseCategoryAsync(`String` categoryId) | To retrieve information of the new release category with {category_id}. | var newRelease = await KKBOXAPI.GetNewReleaseCategoryAsync(categoryId); | 
| `Task<ParseResult<PlaylistData>>` | GetPlaylistOfChartAsync(`String` playlistId) | To retrieve information of the song ranking with {playlist_id}. | var playlist = await KKBOXAPI.GetPlaylistOfChartAsync(playlistId); | 
| `Task<ParseResult<PlaylistData>>` | GetPlaylistOfFeaturedPlaylistsAsync(`String` playlistId) | To retrieve information of the featured playlist with {playlist_id}. | var playlist = await KKBOXAPI.GetPlaylistOfFeaturedPlaylistsAsync(playlistId); | 
| `Task<ParseResult<PlaylistData>>` | GetPlaylistOfNewHitsPlaylistsAsync(`String` playlistId) | To retrieve information of the new hits playlist with {playlist_id}. | var playlist = await KKBOXAPI.GetPlaylistOfNewHitsPlaylistsAsync(playlistId); | 
| `Task<ParseResult<PlaylistOffsetData>>` | GetPlaylistsOfFeaturedPlaylistCategoryAsync(`String` categoryId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of playlists of a featured playlist category. | var playlists = await KKBOXAPI.GetPlaylistsOfFeaturedPlaylistCategoryAsync(categoryId, 100, 0); | 
| `Task<ParseResult<TrackOffsetData>>` | GetPlaylistTracksOfChartAsync(`String` playlistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List tracks of a chart playlist. | var playlist = await KKBOXAPI.GetPlaylistTracksOfChartAsync(playlistId, 100, 0); | 
| `Task<ParseResult<TrackOffsetData>>` | GetPlaylistTracksOfFeaturedPlaylistsAsync(`String` playlistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List the songs of a featured playlist. | var tracks = await KKBOXAPI.GetPlaylistTracksOfFeaturedPlaylistsAsync(playlistId, 100, 0); | 
| `Task<ParseResult<TrackOffsetData>>` | GetPlaylistTracksOfNewHitsPlaylistsAsync(`String` playlistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of tracks of a new hits playlist. | var tracks = await KKBOXAPI.GetPlaylistTracksOfNewHitsPlaylistsAsync(playlistId, 100, 0); | 
| `Task<ParseResult<PlaylistData>>` | GetSharedPlaylistAsync(`String` playlistId) | To retrieve information of the shared playlist with {playlist_id}. | var playlist = await KKBOXAPI.GetSharedPlaylistAsync(playlistId); | 
| `Task<ParseResult<TrackOffsetData>>` | GetTopTracksOfArtistAsync(`String` artistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of top tracks of an artist. | var topTracks = await KKBOXAPI.GetTopTracksOfArtistAsync(artistId, 100, 0); | 
| `Task<ParseResult<TrackData>>` | GetTrackAsync(`String` trackId) | To retrieve information of the song with {track_id}. | var track = await KKBOXAPI.GetTrackAsync(trackId); | 
| `Task<ParseResult<TrackOffsetData>>` | GetTracksOfAlbumAsync(`String` albumId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of tracks of an album. | var tracks = await KKBOXAPI.GetTracksOfAlbumAsync(albumId, 100, 0); | 
| `Task<ParseResult<TrackOffsetData>>` | GetTracksOfSharedPlaylistAsync(`String` playlistId, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null) | List of songs of a shared playlist. | var tracks = await KKBOXAPI.GetTracksOfSharedPlaylistAsync(playlistId, 100, 0); | 
| `Task<ParseResult<SearchResultData>>` | SearchAsync(`String` keyword, `Nullable<Int32>` limit = null, `Nullable<Int32>` offset = null, `SearchType[]` types) | Search for various objects. | var search = await KKBOXAPI.SearchAsync(keyword, 15, 0, SearchType.track, SearchType.album, SearchType.playlist, SearchType.artist); | 


## `KKBOXOAuth`

KKBOX OAuth 2.0 Authorize API.
```csharp
public class KKBOX.OpenAPI.KKBOXOAuth

```

Static Methods

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Task<KKOAuthResponse>` | SignInAsync(`String` clientId, `String` clientSecret) | OAuth 2.0 Token API for Client Credentials Flow |  | 



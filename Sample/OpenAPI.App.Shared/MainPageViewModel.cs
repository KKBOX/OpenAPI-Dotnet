using KKBOX.OpenAPI;
using KKBOX.OpenAPI.ServiceModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OpenAPI.App
{
    public partial class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ClientId { get; set; } = "";

        public string ClientSecret { get; set; } = "";

        public KKBOXAPI OpenAPI { get; private set; }

        private bool isEnabled;
        public bool IsEanbled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                RaisePropertyChanged(nameof(IsEanbled));
            }
        }

        public MainPageViewModel()
        {
            OpenAPI = new KKBOXAPI();
        }

        /// <summary>
        /// Process OAuth authorized.
        /// </summary>
        public async Task GetAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                var result = await KKBOXOAuth.SignInAsync(ClientId, ClientSecret);

                if (result?.Staus == APIStatus.Success)
                {
                    Debug.WriteLine($"access token: {result.Content.AccessToken}");
                    Debug.WriteLine($"expires in: {result.Content.ExipresIn}");

                    OpenAPI.AccessToken = result.Content.AccessToken;
                    this.IsEanbled = true;
                }
            }
            else
            {
                OpenAPI.AccessToken = accessToken;
                this.IsEanbled = true;
            }
        }

        public async Task GetAlbumAndTracks()
        {
            string albumId = "WpTPGzNLeutVFHcFq6";

            // Get album information
            var albumResult = await OpenAPI.GetAlbumAsync(albumId);
            var album = albumResult.Content;

            Debug.WriteLine($"album: {album.Name}, {album.Id}");

            PagingData tracksPaging = null;

            // Get tracks of the album
            var tracksResult = await OpenAPI.GetTracksOfAlbumAsync(album.Id, tracksPaging?.Limit, tracksPaging?.Offset);
            var tracks = tracksResult.Content;
            tracksPaging = tracks.Paging;
            tracksPaging.Offset = tracks.Paging.NextOffset();

            foreach (var track in tracks.Data)
            {
                Debug.WriteLine($"song: {track.Name}, {track.Id}");
            }

            if (tracksPaging.IsEnd() == false)
            {
                // Loop to get all tracks of the album
            }
        }

        public async Task GetArtistAndAlbumTracksAndTopTracks()
        {
            string artistId = "8q3_xzjl89Yakn_7GB";

            // Get artist information
            var artistResult = await OpenAPI.GetArtistAsync(artistId);
            var artist = artistResult.Content;

            Debug.WriteLine($"artist: {artist.Name}, {artist.Id}");

            PagingData albumsPaging = null;

            // Get albums of the artist
            var albumsResult = await OpenAPI.GetAlbumsOfArtistAsync(artist.Id, albumsPaging?.Limit, albumsPaging?.Offset);
            var albums = albumsResult.Content;

            albumsPaging = albums.Paging;
            albumsPaging.Offset = albums.Paging.NextOffset();

            foreach (var album in albums.Data)
            {
                Debug.WriteLine($"album: {album.Name}, {album.Id}");
            }

            if (albumsPaging.IsEnd())
            {
                // Loop to get all albums of the artist
            }

            PagingData topTracksPaging = null;

            // Get top tracks of the artist
            var topTracksResult = await OpenAPI.GetTopTracksOfArtistAsync(artist.Id, topTracksPaging?.Limit, topTracksPaging?.Offset);
            var topTracks = topTracksResult.Content;
            topTracksPaging = topTracks.Paging;
            topTracksPaging.Offset = topTracks.Paging.NextOffset();

            foreach (var track in topTracks.Data)
            {
                Debug.WriteLine($"top song: {track.Name}, {track.Id}");
            }

            if (topTracksPaging.IsEnd())
            {
                // Loop to get all top tracks of the artist
            }
        }

        public async Task GetChartsAndPlaylistTracks()
        {
            var chartPlaylistsResult = await OpenAPI.GetChartListAsync();
            var chartPlaylists = chartPlaylistsResult.Content;

            foreach (var item in chartPlaylists.Data)
            {
                Debug.WriteLine($"chart playlist: {item.Title}, {item.Id}");

                PagingData tracksPaging = null;

                // Get playlist information
                var playlist = await OpenAPI.GetPlaylistOfChartAsync(item.Id);

                // Get tracks of the playlist
                var tracksResult = await OpenAPI.GetPlaylistTracksOfChartAsync(item.Id, tracksPaging?.Limit, tracksPaging?.Offset);
                var tracks = tracksResult.Content;
                tracksPaging = tracks.Paging;
                tracksPaging.Offset = tracks.Paging.NextOffset();

                foreach (var track in tracks.Data)
                {
                    Debug.WriteLine($"song: {track.Name}, {track.Id}");
                }

                if (tracksPaging.IsEnd())
                {
                    // Loop to get all tracks of the playlist
                }
            }
        }

        public async Task GetFeaturedPlaylists()
        {
            PagingData paging = null;

            // Get featured playlists
            var featuredPlaylistsResult = await OpenAPI.GetFeaturedPlaylistsAsync(paging?.Limit, paging?.Offset);
            var featuredPlaylists = featuredPlaylistsResult.Content;

            foreach (var item in featuredPlaylists.Data)
            {
                Debug.WriteLine($"featured playlist: {item.Title}, {item.Id}");

                // Get playlist information
                var playlist = await OpenAPI.GetPlaylistOfFeaturedPlaylistsAsync(item.Id);

                PagingData tracksPaging = null;

                // Get tracks of the feature playlist
                var tracksResult = await OpenAPI.GetPlaylistTracksOfFeaturedPlaylistsAsync(item.Id, tracksPaging?.Limit, tracksPaging?.Offset);
                var tracks = tracksResult.Content;
                tracksPaging = tracks.Paging;
                tracksPaging.Offset = tracks.Paging.NextOffset();

                foreach (var track in tracks.Data)
                {
                    Debug.WriteLine($"song: {track.Name}, {track.Id}");
                }

                if (tracksPaging.IsEnd())
                {
                    // Loop to get all tracks of the playlist
                }
            }

            paging = featuredPlaylists.Paging;
            paging.Offset = featuredPlaylists.Paging.NextOffset();

            if (paging.IsEnd())
            {
                // Loop to get all feature playlists
            }
        }

        public async Task GetFeaturedCategroyPlaylists()
        {
            // List of featured playlist categories.
            var categoryListResult = await OpenAPI.GetFeaturedPlaylistCategoriesAsync();
            var categoryList = categoryListResult.Content;

            foreach (var item in categoryList.Data)
            {
                Debug.WriteLine($"featured playlist category: {item.Title}, {item.Id}");

                // Get A Featured Playlist Category
                var detailCategoryResult = await OpenAPI.GetFeaturedPlaylistCategoryAsync(item.Id);
                var detailCategory = detailCategoryResult.Content;

                foreach (var playlist in detailCategory.Playlists.Data)
                {
                    Debug.WriteLine($"playlist of category: {playlist.Title}, {playlist.Id}");
                }

                if (detailCategory.Playlists.Paging.IsEnd())
                {
                    continue;
                }

                PagingData playlistPaging = detailCategory.Playlists.Paging;
                playlistPaging.Offset = detailCategory.Playlists.Paging.NextOffset();


                var nextPlaylistResult = await OpenAPI.GetPlaylistsOfFeaturedPlaylistCategoryAsync(item.Id, playlistPaging.Limit, playlistPaging.Offset);
                var nextPlaylist = nextPlaylistResult.Content;

                foreach (var playlist in nextPlaylist.Data)
                {
                    Debug.WriteLine($"playlist of category: {playlist.Title}, {playlist.Id}");
                }

                playlistPaging = nextPlaylist.Paging;
                playlistPaging.Offset = playlistPaging.Limit + playlistPaging.Offset;

                if (string.IsNullOrEmpty(nextPlaylist.Paging.Next))
                {
                    break;
                }

            }
        }

        public async Task GetMoodStationList()
        {
            // List of mood stations.
            var moonListResult = await OpenAPI.GetMoodStationListAsync();
            var moonList = moonListResult.Content;

            foreach (var mood in moonList.Data)
            {
                Debug.WriteLine($"mood: {mood.Title}, {mood.Id}");

                // To retrieve information of the mood station with {station_id}.
                var stationResult = await OpenAPI.GetMoodStationAsync(mood.Id);
                var station = stationResult.Content;

                foreach (var item in station.Tracks.Data)
                {
                    Debug.WriteLine($"mood track: {item.Name}, {item.Id}");
                }
            }
        }

        public async Task GetGenreStationList()
        {
            // List of genre stations.
            var genreListResult = await OpenAPI.GetGenreStationListAsync();
            var genreList = genreListResult.Content;

            foreach (var genre in genreList.Data)
            {
                Debug.WriteLine($"genre: {genre.Name}, {genre.Id}");

                // To retrieve information of the genre station with {station_id}.
                var stationResult = await OpenAPI.GetGenreStationAsync(genre.Id);
                var station = stationResult.Content;

                foreach (var item in station.Tracks.Data)
                {
                    Debug.WriteLine($"genre track: {item.Name}, {item.Id}");
                }
            }
        }

        public async Task GetNewReleaseList()
        {
            PagingData categoryPaging = null;

            // List of new release categories.
            var newReleaseCategoryResult = await OpenAPI.GetNewReleaseCategoriesAsync(categoryPaging?.Limit, categoryPaging?.Offset);
            var newReleaseCategory = newReleaseCategoryResult.Content;

            foreach (var categoryItem in newReleaseCategory.Data)
            {
                Debug.WriteLine($"new release category: {categoryItem.Title}, {categoryItem.Id}");

                // To retrieve information of the new release category with {category_id}.
                var categoryDetailResult = await OpenAPI.GetNewReleaseCategoryAsync(categoryItem.Id);
                var categoryDetail = categoryDetailResult.Content;

                PagingData albumPaging = categoryDetail.Albums.Paging;
                albumPaging.Offset = albumPaging.NextOffset();

                foreach (var album in categoryDetail.Albums.Data)
                {
                    Debug.WriteLine($"album of the new release: {album.Name}, {album.Id} : {categoryDetail.Title}");
                }

                if (albumPaging.IsEnd())
                {
                    continue;
                }

                var albumsResult = await OpenAPI.GetAlbumsOfNewReleaseCategoryAsync(categoryItem.Id, albumPaging?.Limit, albumPaging?.Offset);
                var albums = albumsResult.Content;

                foreach (var album in albums.Data)
                {
                    Debug.WriteLine($"album of the new release: {album.Name}, {album.Id} : {categoryDetail.Title}");
                }

                albumPaging = albums.Paging;
                albumPaging.Offset = albumPaging.Offset + albumPaging.Limit;

                if (string.IsNullOrEmpty(albums.Paging.Next))
                {
                    // Loop to get all albums of the category
                }
            }

            categoryPaging = newReleaseCategory.Paging;
            categoryPaging.Offset = categoryPaging.Offset + categoryPaging.Limit;

            if (string.IsNullOrEmpty(newReleaseCategory.Paging.Next))
            {
                // List of new release categories.
            }
        }

        public async Task GetSearchResult()
        {
            string keyword = "祝我幸福";
            PagingData paging = null;

            SearchType[] searchType = { SearchType.album, SearchType.artist, SearchType.playlist, SearchType.track };

            var searchResult = await OpenAPI.SearchAsync(keyword, paging?.Limit, paging?.Offset, searchType);
            var result = searchResult.Content;

            // get tracks
            result.Tracks.Data.ForEach(x =>
            {
                Debug.WriteLine($"name: {x.Name}, album: {x.Album.Name}");
            });

            paging = result.Tracks.Paging;
            paging.Offset = result.Tracks.Paging.NextOffset();

            while (true)
            {
                if (string.IsNullOrEmpty(paging.Next))
                {
                    break;
                }

                var nextResult = await OpenAPI.SearchAsync(keyword, paging?.Limit, paging.Offset, SearchType.track);
                var next = nextResult.Content;

                next.Tracks.Data.ForEach(x =>
                {
                    Debug.WriteLine($"name: {x.Name}, album: {x.Album.Name}");
                });

                paging = next.Tracks.Paging;
                paging.Offset = paging.NextOffset();
            }
        }

        public async Task GetTrack()
        {
            var trackResult = await OpenAPI.GetTrackAsync("-rMBKj4tJ3FgYZK_5n");
            var track = trackResult.Content;
            Debug.WriteLine($"song: {track.Name}, {track.Id}");
        }

        public async Task GetNewHitsPlaylists()
        {
            PagingData paging = new PagingData
            {
                Offset = 0,
                Limit = 10,
            };

            var playlistsResult = await OpenAPI.GetNewHitsPlaylistsAsync(paging.Limit, paging.Offset);
            var playlists = playlistsResult.Content;

            foreach (var item in playlists.Data)
            {
                Debug.WriteLine($"new hits playlist: {item.Title}");

                var detailPlaylistResult = await OpenAPI.GetPlaylistOfNewHitsPlaylistsAsync(item.Id);
                var detailPlaylist = detailPlaylistResult.Content;

                foreach (var trackItem in detailPlaylist.Tracks.Data)
                {
                    Debug.WriteLine($"private playlist track: {trackItem.Id}, {trackItem.Name}");
                }
            }
        }

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {
                // nothing
            }
        }
    }
}
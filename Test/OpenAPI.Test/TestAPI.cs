using KKBOX.OpenAPI.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace KKBOX.OpenAPI.Test
{
    [TestClass]
    public class APITest
    {
        private KKBOXAPI OpenAPI { get; set; }

        [TestMethod]
        private (string id, string secret, string uri) ReadSettingConfigJson()
        {
            var settingContent = File.ReadAllText("settings.json");
            var jsonObject = JObject.Parse(settingContent);

            string clientId = jsonObject["client_id"].ToString();
            string clientSecret = jsonObject["client_secret"].ToString();
            string redirecutUri = jsonObject["redirect_uri"].ToString();

            return (clientId, clientSecret, redirecutUri);
        }

        [TestMethod]
        public async Task AuthorizeAsyncTestMethod()
        {
            var settings = ReadSettingConfigJson();
            var authorize = await KKBOXOAuth.SignInAsync(settings.id, settings.secret);

            OpenAPI = new KKBOXAPI(authorize?.Content?.AccessToken);

            Assert.AreEqual(false, string.IsNullOrEmpty(authorize?.Content?.AccessToken));
        }

        [TestMethod]
        public async Task GetAlbumAndTracksTestMethod()
        {
            await AuthorizeAsyncTestMethod();

            string albumId = "WpTPGzNLeutVFHcFq6";

            // Get Album information
            var albumResult = await OpenAPI.GetAlbumAsync(albumId);
            var album = albumResult.Content;

            Debug.WriteLine($"album: {album.Name}, {album.Id}");

            PagingData tracksPaging = null;

            while (true)
            {
                // Loop to get all tracks of the album
                var tracksResult = await OpenAPI.GetTracksOfAlbumAsync(album.Id, tracksPaging?.Limit, tracksPaging?.Offset);
                var tracks = tracksResult.Content;

                tracksPaging = tracks.Paging;
                tracksPaging.Offset = tracks.Paging.NextOffset();

                foreach (var track in tracks.Data)
                {
                    Debug.WriteLine($"song: {track.Name}, {track.Id}");
                }

                if (tracksPaging.IsEnd())
                {
                    break;
                }
            }
        }

        [TestMethod]
        public async Task GetArtistAndAlbumTracksAndTopTracksTestMethod()
        {
            await AuthorizeAsyncTestMethod();

            string artistId = "8q3_xzjl89Yakn_7GB";

            // Get Artist information
            var artistResult = await OpenAPI.GetArtistAsync(artistId);
            var artist = artistResult.Content;

            Debug.WriteLine($"artist: {artist.Name}, {artist.Id}");

            PagingData albumsPaging = null;

            while (true)
            {
                // Loop to get all albums of the artist
                var albumsResult = await OpenAPI.GetAlbumsOfArtistAsync(artist.Id, albumsPaging?.Limit, albumsPaging?.Offset);
                var albums = albumsResult.Content;

                albumsPaging = albums.Paging;
                albumsPaging.Offset = albums.Paging.NextOffset();

                foreach (var album in albums.Data)
                {
                    PagingData tracksPaging = null;

                    Debug.WriteLine($"album: {album.Name}, {album.Id}");

                    while (true)
                    {
                        // Loop to get all tracks of the album
                        var tracksResult = await OpenAPI.GetTracksOfAlbumAsync(album.Id, tracksPaging?.Limit, tracksPaging?.Offset);
                        var tracks = tracksResult.Content;

                        tracksPaging = tracks.Paging;
                        tracksPaging.Offset = tracksPaging.NextOffset();

                        foreach (var track in tracks.Data)
                        {
                            Debug.WriteLine($"song: {track.Name}, {track.Id}");
                        }

                        if (tracksPaging.IsEnd())
                        {
                            break;
                        }
                    }
                }

                if (albumsPaging.IsEnd())
                {
                    break;
                }
            }

            PagingData topTracksPaging = null;

            while (true)
            {
                // Loop to get all top tracks of the artist
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
                    break;
                }
            }
        }

        [TestMethod]
        public async Task GetChartsAndPlaylistTracksTestMethod()
        {
            await AuthorizeAsyncTestMethod();

            var chartPlaylistsResult = await OpenAPI.GetChartListAsync();
            var chartPlaylists = chartPlaylistsResult.Content;

            foreach (var item in chartPlaylists.Data)
            {
                Debug.WriteLine($"chart playlist: {item.Title}, {item.Id}");

                PagingData tracksPaging = null;

                // Get playlist information
                var playlist = await OpenAPI.GetPlaylistOfChartAsync(item.Id);

                while (true)
                {
                    // Loop to get all tracks of the playlist
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
                        break;
                    }
                }
            }
        }

        [TestMethod]
        public async Task GetFeaturedPlaylistsTestMethod()
        {
            await AuthorizeAsyncTestMethod();

            PagingData paging = null;

            while (true)
            {
                // Get featured playlists
                var featuredPlaylistsResult = await OpenAPI.GetFeaturedPlaylistsAsync(paging?.Limit, paging?.Offset);
                var featuredPlaylists = featuredPlaylistsResult.Content;

                foreach (var item in featuredPlaylists.Data)
                {
                    Debug.WriteLine($"featured playlist: {item.Title}, {item.Id}");

                    // Get playlist information
                    var playlist = await OpenAPI.GetPlaylistOfFeaturedPlaylistsAsync(item.Id);

                    PagingData tracksPaging = null;

                    while (true)
                    {
                        // Loop to get all tracks of the playlist
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
                            break;
                        }
                    }
                }

                paging = featuredPlaylists.Paging;
                paging.Offset = featuredPlaylists.Paging.NextOffset();

                if (paging.IsEnd())
                {
                    break;
                }
            }
        }

        [TestMethod]
        public async Task GetFeaturedCategroyPlaylistsTestMethod()
        {
            await AuthorizeAsyncTestMethod();

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

                while (true)
                {
                    var nextPlaylistResult = await OpenAPI.GetPlaylistsOfFeaturedPlaylistCategoryAsync(item.Id, playlistPaging.Limit, playlistPaging.Offset);
                    var nextPlaylist = nextPlaylistResult.Content;

                    foreach (var playlist in nextPlaylist.Data)
                    {
                        Debug.WriteLine($"playlist of category: {playlist.Title}, {playlist.Id}");
                    }

                    if (string.IsNullOrEmpty(nextPlaylist.Paging.Next))
                    {
                        break;
                    }

                    playlistPaging = nextPlaylist.Paging;
                    playlistPaging.Offset = playlistPaging.Limit + playlistPaging.Offset;
                }
            }
        }

        [TestMethod]
        public async Task GetMoodStationListTestMethod()
        {
            await AuthorizeAsyncTestMethod();
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

        [TestMethod]
        public async Task GetGenreStationListTestMethod()
        {
            await AuthorizeAsyncTestMethod();

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

        [TestMethod]
        public async Task GetNewReleaseListTestMethod()
        {
            await AuthorizeAsyncTestMethod();
            PagingData categoryPaging = null;

            while (true)
            {
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

                    while (true)
                    {
                        var albumsResult = await OpenAPI.GetAlbumsOfNewReleaseCategoryAsync(categoryItem.Id, albumPaging?.Limit, albumPaging?.Offset);
                        var albums = albumsResult.Content;

                        foreach (var album in albums.Data)
                        {
                            Debug.WriteLine($"album of the new release: {album.Name}, {album.Id} : {categoryDetail.Title}");
                        }

                        if (string.IsNullOrEmpty(albums.Paging.Next))
                        {
                            break;
                        }

                        albumPaging = albums.Paging;
                        albumPaging.Offset = albumPaging.Offset + albumPaging.Limit;

                    }
                }

                if (string.IsNullOrEmpty(newReleaseCategory.Paging.Next))
                {
                    continue;
                }

                categoryPaging = newReleaseCategory.Paging;
                categoryPaging.Offset = categoryPaging.Offset + categoryPaging.Limit;
            }
        }

        [TestMethod]
        public async Task GetSearchResultTestMethod()
        {
            await AuthorizeAsyncTestMethod();

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


            var nextResult = await OpenAPI.SearchAsync(keyword, paging?.Limit, paging.Offset, SearchType.track);
            var next = nextResult.Content;

            next.Tracks.Data.ForEach(x =>
            {
                Debug.WriteLine($"name: {x.Name}, album: {x.Album.Name}");
            });

            paging = next.Tracks.Paging;
            paging.Offset = paging.NextOffset();

            if (string.IsNullOrEmpty(paging.Next))
            {
                // Loop to get datas
            }
        }

        [TestMethod]
        public async Task GetTrackTestMethod()
        {
            await AuthorizeAsyncTestMethod();
            var trackResult = await OpenAPI.GetTrackAsync("-rMBKj4tJ3FgYZK_5n");
            var track = trackResult.Content;
            Debug.WriteLine($"song: {track.Name}, {track.Id}");
        }

        [TestMethod]
        public async Task GetNewHitsPlaylistsTestMethod()
        {
            await AuthorizeAsyncTestMethod();

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
    }
}
using OpenAPI.App.Universal;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenAPI.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new MainPageViewModel();

            this.InitializeComponent();
        }

        private async void OAuthButton_Click(object sender, RoutedEventArgs e)
        {
            string previousAccessToken = AppSettingTool.Get<string>(AppSettingTool.ACCESS_TOKEN_KEY);
            await ViewModel.GetAccessToken(previousAccessToken);
            AppSettingTool.Set(AppSettingTool.ACCESS_TOKEN_KEY, ViewModel.OpenAPI.AccessToken);
        }

        private async void AlbumButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetAlbumAndTracks();
        }

        private async void ArtistButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetArtistAndAlbumTracksAndTopTracks();
        }

        private async void ChartsButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetChartsAndPlaylistTracks();
        }

        private async void SearchButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetSearchResult();
        }

        private async void TrackButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetTrack();
        }

        private async void FeaturedPlaylistsButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetFeaturedPlaylists();
        }

        private async void FeaturedPlaylistCategoriesButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetFeaturedCategroyPlaylists();
        }

        private async void MoodStationsButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetMoodStationList();
        }

        private async void GenreStationsButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetGenreStationList();
        }

        private async void NewreleaseButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetNewReleaseList();
        }

        private async void NewHitsPlaylistsButon_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetNewHitsPlaylists();
        }
    }
}
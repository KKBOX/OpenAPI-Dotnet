using System.Windows;

namespace OpenAPI.App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPageViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainPageViewModel();
            DataContext = ViewModel;
        }

        private async void OAuthButton_Click(object sender, RoutedEventArgs e)
        {
            string previousAccessToken = AppSettingTool.Get(AppSettingTool.ACCESS_TOKEN_KEY);
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
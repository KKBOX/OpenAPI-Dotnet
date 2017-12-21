using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KKBOX.OpenAPI.Controls
{
    /// <summary>
    /// Interaction logic for WebAuthorizeDialog.xaml
    /// </summary>
    public partial class WebAuthorizeDialog : UserControl
    {
        public string AuthorizeUrl { get; set; }

        public string RedirectUrl { get; set; }

        public bool? IsShowing
        {
            get { return PopupControl?.IsActive; }
        }

        private Window PopupControl { get; set; }

        private TaskCompletionSource<string> TCS { get; set; }

        public WebAuthorizeDialog()
        {
            InitializeComponent();

            PopupControl = new Window();
            PopupControl.Title = "Connecting to a service";
            PopupControl.Content = this;
            PopupControl.Width = Application.Current.MainWindow.ActualWidth;
            PopupControl.Height = Application.Current.MainWindow.ActualHeight;
            PopupControl.SizeChanged -= PopupControl_SizeChanged;
            PopupControl.SizeChanged += PopupControl_SizeChanged;
            PopupControl.Closed += PopupControl_Closed;

            Unloaded += WebAuthorizeDialog_Unloaded;
            Application.Current.MainWindow.Closed += MainWindow_Closed;

            TCS = new TaskCompletionSource<string>();

            WebViewControl.Navigated += WebViewControl_Navigated;
            WebViewControl.Navigating += WebViewControl_Navigating;
        }

        private void WebAuthorizeDialog_Unloaded(object sender, RoutedEventArgs e)
        {
            UnSubscribeEvetns();
        }

        private void PopupControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RefreshLayout();
        }

        private void PopupControl_Closed(object sender, EventArgs e)
        {
            Hide();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Hide();
        }

        private void WebViewControl_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            string urlString = e?.Uri?.OriginalString;

            if (string.IsNullOrEmpty(urlString) == false && urlString.IndexOf(RedirectUrl) == 0)
            {
                e.Cancel = true;

                Hide(urlString.Replace(RedirectUrl, string.Empty));
            }
        }

        private void WebViewControl_Navigated(object sender, NavigationEventArgs e)
        {
        }

        public async Task<string> Show()
        {
            if (Uri.TryCreate(AuthorizeUrl, UriKind.Absolute, out var authorizeUri))
            {
                WebViewControl.Navigate(authorizeUri);
            }

            RefreshLayout();
            PopupControl.Show();
            return await TCS?.Task;
        }

        public void Hide(string response = "")
        {
            PopupControl.Close();
            // clear cookies
            WebViewControl.Navigate("https://account.kkbox.com/logout");

            TCS?.TrySetResult(response);
        }

        private void UnSubscribeEvetns()
        {
            if (WebViewControl != null)
            {
                WebViewControl.Navigated -= WebViewControl_Navigated;
                WebViewControl.Navigating -= WebViewControl_Navigating;
            }

            if (PopupControl != null)
            {
                PopupControl.SizeChanged -= PopupControl_SizeChanged;
                PopupControl.Closed -= PopupControl_Closed;
            }

            Application.Current.MainWindow.Closed -= MainWindow_Closed;
        }

        private void RefreshLayout()
        {
            try
            {
                PopupControl.UpdateLayout();
            }
            catch (Exception)
            {
            }

            RootContainer.Width = PopupControl.Width;
            RootContainer.Height = PopupControl.Height;
            ContentContainer.Height = PopupControl.Height * 0.7;
        }

        private void ClearCookie()
        {
            try
            {
                if (Uri.TryCreate(AuthorizeUrl, UriKind.Absolute, out var authUri))
                {
                    string cookie = Application.GetCookie(authUri);

                    if (!string.IsNullOrEmpty(cookie))
                    {
                        string[] values = cookie.Split(';');
                        foreach (string s in values)
                        {
                            if (s.IndexOf('=') > 0)
                            {
                                // Sets value to null with expiration date of yesterday.
                                DeleteSingleCookie(s.Substring(0, s.IndexOf('=')), authUri);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void DeleteSingleCookie(string name, Uri url)
        {
            try
            {
                // Calculate "one day ago"
                DateTime expiration = DateTime.UtcNow - TimeSpan.FromDays(2);

                // Format the cookie as seen on FB.com.  Path and domain name are important factors here.
                string cookie = String.Format("{0}; expires={1};", name, expiration.ToString("R"));

                // Set a single value from this cookie (doesnt work if you try to do all at once, for some reason)
                Application.SetCookie(url, cookie);
                string cookie1 = Application.GetCookie(url);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc + " seen deleting a cookie.  If this is reasonable, add it to the list.");
            }
        }
    }
}
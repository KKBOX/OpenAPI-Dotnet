using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace KKBOX.OpenAPI.Controls
{
    internal sealed class WebAuthorizeDialog : Control
    {
        internal string AuthorizeUrl { get; set; }

        internal string RedirectUrl { get; set; }

        internal bool? IsShowing
        {
            get { return PopupControl?.IsOpen; }
        }

        private WebView WebViewControl { get; set; }

        private Grid RootContainer { get; set; }

        private Grid ContentContainer { get; set; }

        private Button HideButton { get; set; }

        private Border BackgroundBorder { get; set; }

        private ProgressRing ProgressRingControl { get; set; }

        private Popup PopupControl { get; set; }

        private TaskCompletionSource<string> TCS { get; set; }

        public WebAuthorizeDialog()
        {
            this.DefaultStyleKey = typeof(WebAuthorizeDialog);

            if (Window.Current != null)
            {
                var currentWindow = Window.Current;
                currentWindow.SizeChanged += CurrentWindow_SizeChanged;
            }

            SystemNavigationManager.GetForCurrentView().BackRequested -= WebAuthorizeDialog_BackRequested;
            SystemNavigationManager.GetForCurrentView().BackRequested += WebAuthorizeDialog_BackRequested;

            Unloaded += WebAuthorizeDialog_Unloaded;
            
            TCS = new TaskCompletionSource<string>();
        }

        private void BuildDialogLayout()
        {
            RootContainer = new Grid();

            BackgroundBorder = new Border
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Opacity = 0,
                Background = new SolidColorBrush(Colors.Black)
            };
            RootContainer.Children.Add(BackgroundBorder);

            ContentContainer = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(25, 0, 25, 0),
                Background = new SolidColorBrush(Colors.White)
            };

            ContentContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            ContentContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            RootContainer.Children.Add(ContentContainer);

            Grid headerGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = new SolidColorBrush(Colors.White)
            };
            Grid.SetRow(headerGrid, 0);
            ContentContainer.Children.Add(headerGrid);
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            TextBlock headerTextblock = new TextBlock
            {
                Text = "Connecting to a service",
                Margin = new Thickness(10, 0, 10, 0),
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x88, 0x88, 0x88)),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(headerTextblock, 0);
            headerGrid.Children.Add(headerTextblock);

            HideButton = new Button
            {
                FontFamily = new FontFamily("Segoe MDL2 Assets"),
                Content = "\uE106",
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(HideButton, 1);
            headerGrid.Children.Add(HideButton);
            HideButton.Click += HideButton_Click;

            WebViewControl = new WebView
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            Grid.SetRow(WebViewControl, 1);
            ContentContainer.Children.Add(WebViewControl);
            WebViewControl.NavigationStarting -= WebViewControl_NavigationStarting;
            WebViewControl.NavigationStarting += WebViewControl_NavigationStarting;
            WebViewControl.NavigationCompleted -= WebViewControl_NavigationCompleted;
            WebViewControl.NavigationCompleted += WebViewControl_NavigationCompleted;
            WebViewControl.NavigationFailed -= WebViewControl_NavigationFailed;
            WebViewControl.NavigationFailed += WebViewControl_NavigationFailed;
            WebViewControl.UnsupportedUriSchemeIdentified -= WebViewControl_UnsupportedUriSchemeIdentified;
            WebViewControl.UnsupportedUriSchemeIdentified += WebViewControl_UnsupportedUriSchemeIdentified;

            ProgressRingControl = new ProgressRing
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x88, 0x88, 0x88)),
                IsActive = true,
                Height = 80,
                Width = 80
            };
            Grid.SetRow(ProgressRingControl, 1);
            ContentContainer.Children.Add(ProgressRingControl);

            PopupControl = new Popup();
            PopupControl.Child = RootContainer;
        }

        private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            RefreshLayout();
        }

        private void WebViewControl_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            ControlProgressRingControl(false);
        }

        private void WebViewControl_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            ControlProgressRingControl(false);
        }

        private void WebViewControl_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            ControlProgressRingControl(true);

            string urlString = args?.Uri?.OriginalString;

            if (string.IsNullOrEmpty(urlString) == false && urlString.IndexOf(RedirectUrl) == 0)
            {
                args.Cancel = true;
                Hide(urlString.Replace(RedirectUrl, string.Empty));
            }
        }

        private void WebViewControl_UnsupportedUriSchemeIdentified(WebView sender, WebViewUnsupportedUriSchemeIdentifiedEventArgs args)
        {
            args.Handled = true;
            Hide(args?.Uri?.OriginalString);
        }

        private void WebAuthorizeDialog_Unloaded(object sender, RoutedEventArgs e)
        {
            UnSubscribeEvetns();
        }

        private void WebAuthorizeDialog_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (PopupControl.IsOpen)
            {
                Hide();
                e.Handled = true;
            }
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        public async Task<string> Show()
        {
            if (RootContainer == null)
            {
                BuildDialogLayout();
            }

            if (Uri.TryCreate(AuthorizeUrl, UriKind.Absolute, out var authorizeUri))
            {
                WebViewControl.Navigate(authorizeUri);
            }

            RefreshLayout();
            DisplayPopupAnimation();
            PopupControl.IsOpen = true;
            return await TCS?.Task;
        }

        public void Hide(string response = "")
        {
            PopupControl.IsOpen = false;
            ClearCookie();
            TCS?.TrySetResult(response);
        }

        private void DisplayPopupAnimation()
        {
            Storyboard messageStoryboard = new Storyboard();

            DoubleAnimation backgroundOpacityAnimation = new DoubleAnimation()
            {
                From = 0.0,
                To = 0.7,
                Duration = TimeSpan.FromMilliseconds(250)
            };

            Storyboard.SetTarget(backgroundOpacityAnimation, BackgroundBorder);
            Storyboard.SetTargetProperty(backgroundOpacityAnimation, "Opacity");
            messageStoryboard.Children.Add(backgroundOpacityAnimation);

            TranslateTransform messageTranslateTransform = new TranslateTransform();
            RootContainer.RenderTransform = messageTranslateTransform;
            DoubleAnimation messageTranslateYAnimation = new DoubleAnimation()
            {
                From = 180,
                To = 0,
                BeginTime = TimeSpan.FromMilliseconds(50),
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new PowerEase()
                {
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(messageTranslateYAnimation, messageTranslateTransform);
            Storyboard.SetTargetProperty(messageTranslateYAnimation, "Y");
            messageStoryboard.Children.Add(messageTranslateYAnimation);

            DoubleAnimation messageOpacityAnimation = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                BeginTime = TimeSpan.FromMilliseconds(50),
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new PowerEase()
                {
                    EasingMode = EasingMode.EaseOut
                }
            };
            Storyboard.SetTarget(messageOpacityAnimation, RootContainer);
            Storyboard.SetTargetProperty(messageOpacityAnimation, "Opacity");
            messageStoryboard.Children.Add(messageOpacityAnimation);

            messageStoryboard.SafeBegin();
        }

        private void RefreshLayout()
        {
            try
            {
                Window.Current.Content.UpdateLayout();
            }
            catch (Exception)
            {
            }

            RootContainer.Width = Window.Current.Bounds.Width;
            RootContainer.Height = Window.Current.Bounds.Height;
            ContentContainer.Height = Window.Current.Bounds.Height * 0.7;
        }

        private void ControlProgressRingControl(bool isActive)
        {
            if (ProgressRingControl != null)
            {
                ProgressRingControl.IsActive = isActive;
            }
        }

        private void ClearCookie()
        {
            if (Uri.TryCreate(AuthorizeUrl, UriKind.Absolute, out var authUri))
            {
                string targetUrl = $"{authUri.Scheme}://{authUri.Host}";

                HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
                HttpCookieManager manager = filter.CookieManager;
                HttpCookieCollection collection = manager.GetCookies(new Uri(targetUrl));

                foreach (var item in collection)
                {
                    manager.DeleteCookie(item);
                }
            }
        }

        private void UnSubscribeEvetns()
        {
            if (WebViewControl != null)
            {
                WebViewControl.NavigationStarting -= WebViewControl_NavigationStarting;
                WebViewControl.NavigationCompleted -= WebViewControl_NavigationCompleted;
                WebViewControl.NavigationFailed -= WebViewControl_NavigationFailed;
                WebViewControl.UnsupportedUriSchemeIdentified -= WebViewControl_UnsupportedUriSchemeIdentified;
            }

            if (HideButton != null)
            {
                HideButton.Click -= HideButton_Click;
            }

            if (Window.Current != null)
            {
                var currentWindow = Window.Current;
                currentWindow.SizeChanged -= CurrentWindow_SizeChanged;
            }

            SystemNavigationManager.GetForCurrentView().BackRequested -= WebAuthorizeDialog_BackRequested;
        }
    }
}

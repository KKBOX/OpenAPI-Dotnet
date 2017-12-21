using System;
using Windows.UI.Xaml.Media.Animation;

namespace KKBOX.OpenAPI.Controls
{
    internal static class StoryboardExtension
    {
        internal static void SafeBegin(this Storyboard storyboard)
        {
            try
            {
                storyboard?.Begin();
            }
            catch (Exception)
            {
                // 動畫壞了
            }
        }
    }
}
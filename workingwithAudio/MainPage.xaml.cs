using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace workingwithAudio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaPlayer player = new MediaPlayer();
        public MainPage()
        {
            this.InitializeComponent();
            PlayVideo();
        }
        public void PlayVideo()
        {
            player = new MediaPlayer();
            player.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/somevideo.mkv"));
            player.Play();
            
            mediaPlayerElement.SetMediaPlayer(player);
        }

        private void skipforward_Click(object sender, RoutedEventArgs e)
        {
            var session = player.PlaybackSession;
            session.Position = session.Position + TimeSpan.FromSeconds(10);
        }

        private void speedToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            player.PlaybackSession.PlaybackRate = 2.0;
        }

        private void speedToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            player.PlaybackSession.PlaybackRate = 1.0;
        }
    }
}

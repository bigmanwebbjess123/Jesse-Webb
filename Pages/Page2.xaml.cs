using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public bool poop { get; set; } 
        public Page2()
        {
            InitializeComponent();
        }

        public void MuteSwitch_Toggled(object sender, ToggledEventArgs e)  
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Stop();
            poop = true;
        }

        private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            if (e.Value)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;
                if(poop.Equals(false))
                {
                    player.Load("spooky.mp3");
                    player.Play();
                }
                else
                {
                    player.Stop();
                }
                
            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
                if(poop.Equals(false))
                {
                    player.Load("nioce.mp3");
                    player.Play();
                }
                else
                {
                    player.Stop();
                    return;
                }
                
            }
        }
    }
}
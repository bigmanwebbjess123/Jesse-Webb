using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_App
{
    public partial class App : Application
    {
        public static string FilePath;
        public App()
        {
            Device.SetFlags(new string[] { "AppTheme_Experimental" });
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            FilePath = filePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

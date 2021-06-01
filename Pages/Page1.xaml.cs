using System;
using Xamarin.Forms;
using System.ComponentModel;
using Mobile_App.Models;
using SQLite;
using Plugin.Media;


namespace Mobile_App
{
    [DesignTimeVisible(true)]
    public partial class Page1 : ContentPage
    {
        public bool Poop { get; set; }
        public Page1()
        {
            InitializeComponent();
    
        }       

        void SaveButton_OnClicked(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("clapp.mp3");
            Birthdays brithday = new Birthdays()
            {
                FirstName = fNameEntry.Text,
                LastName = lNameEntry.Text,
                Date = datePicker.Date
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Birthdays>();
                int rowsAdded = conn.Insert(brithday);               
            }
            DisplayAlert("Alert", "Birthday has been saved to database", "OK");
            if(Poop.Equals(1))
                player.Play();
        }
        private void PickerButton_Clicked(object sender, System.EventArgs e)
        {
            this.datePicker.IsOpen = true;          
        }   

        private void LoadButton_OnClicked(object sender, System.EventArgs e)
        {
            UploadPhoto();
        }
        async void UploadPhoto()    
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not supported", "This is not a supported image", "ok");
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 40
            });

            if(file==null)
            {
                await DisplayAlert("Error", "Could not upload image", "Ok");
                return;
            }

        }

    }                                                     
            
}
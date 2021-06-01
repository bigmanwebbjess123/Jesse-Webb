using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SQLite;
using Mobile_App.Models;
using XamForms.Controls;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;

namespace Mobile_App
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Birthdays>();
                //conn.DeleteAll<Birthdays>();
                var birthday = conn.Table<Birthdays>().ToList();
                birthdayListView.ItemsSource = birthday;
            }
        }


        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }

       
    }
}

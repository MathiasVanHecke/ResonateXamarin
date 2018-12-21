using System;
using System.Collections.Generic;
using System.Diagnostics;
using ResonateXamarin.Models;
using Xamarin.Forms;

namespace ResonateXamarin.Views
{
    public partial class LoginSpotifyPage : ContentPage
    {
       
        public LoginSpotifyPage()
        {
            InitializeComponent();
            Browser.Source = "https://accounts.spotify.com/authorize?client_id=7a788b5554324e06afd076e05e69eaee&redirect_uri=https%3A%2F%2Fexample.com%2Fcallback&scope=user-read-private%20user-read-email%20user-top-read%20user-read-birthdate&response_type=token";
        }

        void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            if (!e.Url.Contains("client_id"))
            {
                string url = e.Url;
                string helper = url.Split('=')[1];
                string token = helper.Split('&')[0];
                GlobalVariables.UserBearer = token;
                Application.Current.MainPage = new RegisterPage();
            }
        }
    }
}

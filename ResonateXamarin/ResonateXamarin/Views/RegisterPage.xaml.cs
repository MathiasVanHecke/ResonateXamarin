using System;
using System.Collections.Generic;
using ResonateXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResonateXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            GetUserFromSpotify();
            GetUserDataFromSpotify();
        }


        private async void GetUserFromSpotify()
        {
            SpotifyUser spotifyUser = await ResonateManager.GetSpotifyUserAsync();
            lblName.Text = spotifyUser.display_name;
            lblEmail.Text = spotifyUser.email;
            lblDob.Text = spotifyUser.birthdate;
        }

        private async void GetUserDataFromSpotify()
        {
            SpotifyData spotifyData = await ResonateManager.GetSpotifyUserDataAsync();
          
            for (int i = 0; i < spotifyData.items.Count; i++)
            {
                gArtists.Children.Add(new Image
                {
                    Source = spotifyData.items[i].images[0].url,
                    Aspect = Aspect.AspectFill
                }, 0, i);

                gArtists.Children.Add(new BoxView
                {
                    BackgroundColor = Color.FromHex("#1e9b6c")
                }, 1, i);

                gArtists.Children.Add(new Label
                {
                    Text = spotifyData.items[i].name,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("#3f4648"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    FontSize = 18
                }, 2, i);

                //gArtists.Children.Add(new Image
                //{
                //    Source = ImageSource.FromResource("ResonateXamarin.Assets.Close.png"),
                //    VerticalOptions = LayoutOptions.CenterAndExpand
                //}, 3, i);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using ResonateXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResonateXamarin.Views.Swipe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileSwipePage : ContentPage
    {
        public ProfileSwipePage(string userId)
        {
            InitializeComponent();
            LoadProfile(userId);
        }

        async private void LoadProfile(string userId)
        {
            SpotifyUser spotifyUser = await ResonateManager.GetUser(userId);

            lblName.Text = spotifyUser.nameAndAge;
            imgProfilePic.Source = spotifyUser.urlPf;
            lblDescription.Text = spotifyUser.beschrijving;

            int i = 0;
            foreach(Artist artist in spotifyUser.Artists)
            {
                gArtists.Children.Add(new Image
                {
                    Source = artist.UrlPf,
                    Aspect = Aspect.AspectFill
                }, i, 0);

                gArtists.Children.Add(new BoxView
                {
                    BackgroundColor = Color.FromHex("#1e9b6c")
                }, i, 1);

                gArtists.Children.Add(new Label
                {
                    Text = artist.ArtistName,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("#3f4648"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    FontSize = 18
                }, i, 2);
                i++;
            }
        }
    }
}

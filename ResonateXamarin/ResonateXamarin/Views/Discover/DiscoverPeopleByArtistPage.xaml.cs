using System;
using System.Collections.Generic;
using System.Diagnostics;
using ResonateXamarin.Models;
using ResonateXamarin.Views.Swipe;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResonateXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverPeopleByArtistPage : ContentPage
    {
        public DiscoverPeopleByArtistPage()
        {
            InitializeComponent();
            LoadArtist();
        }

        private async void LoadArtist()
        {
            int column = 0;

            List<Artist> artists = await ResonateManager.GetArists();;

            foreach(Artist artist in artists)
            {
                Image image = new Image
                {
                    Source = artist.UrlPf,
                    Aspect = Aspect.AspectFill,
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                image.GestureRecognizers.Add(tapGestureRecognizer);

                tapGestureRecognizer.Tapped += (sender, e) =>
                {
                    Application.Current.MainPage = new SwipePage("artist", artist.ArtistName);
                };

                gArtists.Children.Add(image, column, 0);

                gArtists.Children.Add(new Label
                {
                    Text = artist.ArtistName,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("#3f4648"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    FontSize = 18
                }, column, 1);

                column++;
            }
        }
    }
}

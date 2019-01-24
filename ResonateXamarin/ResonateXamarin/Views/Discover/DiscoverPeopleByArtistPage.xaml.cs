using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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
            LoadGenres();
            Title = "Discover";
        }

        private async void LoadArtist()
        {
            int column = 0;
            int index = 0;

            List<Artist> artists = await ResonateManager.GetArists();

            for (int i = 0; (i <= 2) && (i <= artists.Count); i++)
            {
                Image image = new Image
                {
                    Source = artists[i].UrlPf,
                    Aspect = Aspect.AspectFill,
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                image.GestureRecognizers.Add(tapGestureRecognizer);

                tapGestureRecognizer.Tapped += async (sender, e) =>
                {
                    await Navigation.PushAsync(await SwipePage.BuildSwipePageAsnyc(1, artists[i].ArtistName));
                };

                gArtists.Children.Add(image, column, index);

                index++;

                gArtists.Children.Add(new Label
                {
                    Text = artists[i].ArtistName,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("#3f4648"),
                    TextColor = Color.FromHex("#FFFFFF"),
                    FontSize = 18
                }, column, index);

                column++;

                index = 0;
            }
        }

        private async void LoadGenres()
        {
            int indexG = 0;
            int columnG = 0;

            List<string> genres = await ResonateManager.GetGenres();

            //Elke artiest heeft een genre

            //Voor elke genre in artiest
            foreach (String genre in genres)
            {
                if (genre == string.Empty) return;
                Label label = new Label
                {
                    Text = genre,
                    TextColor = Color.FromHex("#FFFFFF"),
                    FontSize = 18,
                    BackgroundColor = Color.FromHex("#3f4648"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                //Tap
                var tapGestureRecognizer = new TapGestureRecognizer();
                label.GestureRecognizers.Add(tapGestureRecognizer);

                tapGestureRecognizer.Tapped += async (sender, e) =>
                {
                    await Navigation.PushAsync(await SwipePage.BuildSwipePageAsnyc(2, genre));
                };

                //Add to grid
                gGenres.Children.Add(label, columnG, indexG);

                if (columnG == 0)
                    columnG = 1;
                else
                {
                    //Blijf horizontaal
                    columnG = 0;
                    indexG++;
                }
            }
        }
    }
}

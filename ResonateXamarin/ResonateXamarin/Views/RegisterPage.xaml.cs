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
        public SpotifyData spotifyData = new SpotifyData();
        public SpotifyUser spotifyUser = new SpotifyUser();

        public RegisterPage()
        {
            InitializeComponent();
            GetUserFromSpotify();
            GetUserDataFromSpotify();
        }


        private async void GetUserFromSpotify()
        {
            spotifyUser = await ResonateManager.GetSpotifyUserAsync();
            entName.Text = spotifyUser.display_name;
            entEmail.Text = spotifyUser.email;
            entDob.Text = spotifyUser.birthdate;
        }

        private async void GetUserDataFromSpotify()
        {
            spotifyData = await ResonateManager.GetSpotifyUserDataAsync();

            LoadGenres();
            LoadArtists();
        }

        private void LoadGenres()
        {
            int index = 0;
            int column = 0;

            spotifyUser.Genres = new List<Genre>();

            //Elke artiest heeft een genre
            for (int i = 0; i < spotifyData.items.Count; i++)
            {
                //Voor elke genre in artiest
                foreach (String genre in spotifyData.items[i].genres)
                {
                    if (genre == string.Empty) return;
                    gGenres.Children.Add(new Label
                    {
                        Text = genre,
                        TextColor = Color.FromHex("#FFFFFF"),
                        FontSize = 18,
                        BackgroundColor = Color.FromHex("#3f4648"),
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }, column, index);

                    if (column == 0)
                        column = 1;
                    else
                    {
                        //Blijf horizontaal
                        column = 0;
                        index++;
                    }

                    //Toevoegen aan User object
                   spotifyUser.Genres.Add(new Genre() { UserId = spotifyUser.id, GenreName = genre });
                }
            }
        }

        private void LoadArtists()
        {
            spotifyUser.Artists = new List<Artist>();
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

                spotifyUser.Artists.Add(new Artist(){
                 UserId = spotifyUser.id,
                 ArtistName = spotifyData.items[i].name,UrlPf = spotifyData.items[i].images[0].url,
                    HrefSpotify = spotifyData.items[i].href });
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            spotifyUser.display_name = entName.Text;
            spotifyUser.email = entEmail.Text;
            spotifyUser.birthdate = entDob.Text;

            Boolean succes = await ResonateManager.RegisterUser(spotifyUser);
            //List<String> data = await ResonateManager.GetGenres();
        }
    }
}

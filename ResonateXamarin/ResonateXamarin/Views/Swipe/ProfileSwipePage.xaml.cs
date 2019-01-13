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
        SpotifyUser SpotifyUser = new SpotifyUser();

        public ProfileSwipePage()
        {
            InitializeComponent();
        }
    }
}

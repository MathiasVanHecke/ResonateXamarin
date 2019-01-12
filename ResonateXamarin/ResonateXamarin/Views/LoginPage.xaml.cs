﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ResonateXamarin.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            imgBackground.Source = ImageSource.FromResource("ResonateXamarin.Assets.loginbg.jpeg");
        }

        void btnLoginOn_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new LoginSpotifyPage();

            //Application.Current.MainPage = new RegisterPage();
        }
    }
}

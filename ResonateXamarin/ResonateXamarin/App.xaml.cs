using System;
using ResonateXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ResonateXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            try
            {
                var currentuserID = (Application.Current.Properties["user_id"].ToString());
                if (currentuserID != string.Empty)
                    MainPage = new NavigationPage(new DiscoverPeopleByArtistPage())
                    {
                        BarBackgroundColor = Color.FromHex("#222729"),
                        BarTextColor = Color.White
                    };
            }
            catch
            {
                Application.Current.Properties["user_id"] = "";
                Application.Current.Properties["bearer"] = "";
                Application.Current.SavePropertiesAsync();
                MainPage = new LoginPage();
            }

            //MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

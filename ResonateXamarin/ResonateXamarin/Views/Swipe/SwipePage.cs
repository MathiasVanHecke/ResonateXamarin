using System;
using PanCardView;
using ResonateXamarin.CardsFactory;
using ResonateXamarin.ViewModels;
using Xamarin.Forms;

namespace ResonateXamarin.Views.Swipe
{
    public class SwipePage : ContentPage
    {
        public SwipePage(string methode, string value)
        {
            //methode = Artist, Genre, Location
            //Value = waarde van methode
            

            var cardsView = new CardsView
            {
                ItemTemplate = new DataTemplate(() => new DefaultSwipeCardItemView()),
            };


            //Niet cyclen
            cardsView.IsCyclical = true;


            //Binden met VM
            cardsView.SetBinding(CardsView.ItemsSourceProperty, nameof(SwipePageViewModel.Items));
            cardsView.SetBinding(CardsView.SelectedIndexProperty, nameof(SwipePageViewModel.CurrentIndex));

            cardsView.SetBinding(CardsView.ItemSwipedCommandProperty, nameof(SwipePageViewModel.ItemSwiped));



            //Layout van swipe pagina
            Label title = new Label
            {
                Text = $"Ontdek alle mensen die van: {value} houden.",
                FontSize = 34,
                TextColor = Color.FromHex("#63d297")
            };

            title.Margin = new Thickness(10, 20, 10, 30);

            Content = new StackLayout()
            {
                Children =
                {
                    title,
                    cardsView
                }
            };

            Content.BackgroundColor = Color.FromHex("#222729");

            BindingContext = new SwipePageViewModel();
        }
    }
}


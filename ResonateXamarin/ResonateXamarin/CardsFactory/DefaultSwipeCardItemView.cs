﻿using System;
using ResonateXamarin.Views.Swipe;
using Xamarin.Forms;

namespace ResonateXamarin.CardsFactory
{
    public class DefaultSwipeCardItemView : StackLayout
    {
        public DefaultSwipeCardItemView()
        {
            var frame = new Frame
            {
                Padding = 0,
                HasShadow = false,
                IsClippedToBounds = false,
                BorderColor = Color.Silver,
            };

            Label label = new Label
            {
                Text = "Mathias, 18",
                TextColor = Color.White,
                FontSize = 26,
                BackgroundColor = Color.FromHex("#3f4648")
            };

            label.SetBinding(Label.TextProperty, "nameAndAge");

            frame.Margin = new Thickness(10, 0, 10, 0);
            label.Margin = new Thickness(10, 0, 10, 0);

            Children.Add(frame);
            Children.Add(label);

            var image = new Image
            {
                Aspect = Aspect.AspectFill
            };

            image.SetBinding(Image.SourceProperty, "urlPf");


            //TODO Smerige oplossing..

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) => await Navigation.PushAsync(new ProfileSwipePage("ariane.malfait"), false);

            GestureRecognizers.Add(tapGesture);

            frame.Content = image;
        }
    }
}

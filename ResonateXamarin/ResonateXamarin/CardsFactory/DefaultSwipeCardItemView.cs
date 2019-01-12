using System;
using Xamarin.Forms;

namespace ResonateXamarin.CardsFactory
{
    public class DefaultSwipeCardItemView : StackLayout
    {
        public DefaultSwipeCardItemView()
        {
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => Application.Current.MainPage.DisplayAlert("Tap!", null, "Ok");
            //profiel id meegeven aan volgende applicatie

            GestureRecognizers.Add(tapGesture);

            var frame = new Frame
            {
                Padding = 0,
                HasShadow = false,
                IsClippedToBounds = false,
                BorderColor = Color.Silver,
                BackgroundColor = Color.Red,
            };

            Label label = new Label
            {
                Text = "Mathias, 18",
                TextColor = Color.White,
                FontSize = 26,
                BackgroundColor = new Color(0, 0, 0, 0.1),
            };

            label.SetBinding(Label.TextProperty, "display_name");

            frame.Margin = new Thickness(10, 0, 10, 0);
            label.Margin = new Thickness(10, 0, 10, 0);

            Children.Add(frame);
            Children.Add(label);

            var image = new Image
            {
                Aspect = Aspect.AspectFill
            };

            image.SetBinding(Image.SourceProperty, "urlPf");

            frame.Content = image;
        }
    }
}

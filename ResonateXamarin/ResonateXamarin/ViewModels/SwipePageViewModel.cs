using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PanCardView.Extensions;
using ResonateXamarin.Models;
using Xamarin.Forms;

namespace ResonateXamarin.ViewModels
{
    public class SwipePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _currentIndex;

        public SwipePageViewModel()
        {

            Items = new ObservableCollection<SpotifyUser>
            {
               new SpotifyUser() {display_name = "Mathias Van Hecke", birthdate = "05/04/1998"} ,
               new SpotifyUser() {display_name = "Nico Clompen", birthdate = "05/04/1998"} ,
               new SpotifyUser() {display_name = "Céine Abbeloos", birthdate = "05/04/1998"},
            };

            ItemSwiped = new Command(v =>
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(v))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(v);
                    Console.WriteLine("{0}={1}", name, value);
                    if (Items.Any())
                    {
                        if (name == "Direction")
                        {
                            if (value.ToString() == "Left")
                            {
                                //Dislike
                                //Items.RemoveAt(CurrentIndex);
                                Items.RemoveAt(CurrentIndex.ToCyclingIndex(Items.Count));
                            }
                            else
                            {
                                //Like
                                Items.RemoveAt(CurrentIndex.ToCyclingIndex(Items.Count));
                            }
                        }
                    }
                }
            });
        }

        public ICommand ItemSwiped { get; }

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentIndex)));
            }
        }

        public ObservableCollection<SpotifyUser> Items { get; }
    }
}


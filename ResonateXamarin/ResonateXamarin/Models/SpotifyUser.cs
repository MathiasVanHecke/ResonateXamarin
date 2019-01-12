using System;
using System.Collections.Generic;

namespace ResonateXamarin.Models
{
    public class SpotifyUser
    {
        public string country { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string birthdate { get; set; }
        public List<Image> images { get; set; }
        public string uri { get; set; }

        //Server ontvangt dit anders dan in het object
        private string UrlPf;
        public string urlPf
        {
            get
            {
                return "https://scontent-bru2-1.xx.fbcdn.net/v/t31.0-8/19667789_10211328272659999_3127023050687871820_o.jpg?_nc_cat=102&_nc_ht=scontent-bru2-1.xx&oh=5cb7f7b3aefbf65a7fe3ff15ea5e0ed9&oe=5CBD3FB4";
                //return this.images[0].url;
                //TODO verander dit.
            }
            set
            {
                this.UrlPf = value;
            }
        }

        public class Image
        {
            public string url { get; set; }
        }

        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }

    }
}
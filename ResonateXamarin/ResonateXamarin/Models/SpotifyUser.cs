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
                return this.images[0].url;
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
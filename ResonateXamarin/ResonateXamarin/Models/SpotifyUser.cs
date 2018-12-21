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

        public class Image
        {
            public string url { get; set; }
        }

    }
}

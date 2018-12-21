using System;
using System.Collections.Generic;

namespace ResonateXamarin.Models
{
    public class SpotifyData
    {
        public IList<Item> items { get; set; }


        public class Image
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class Item
        {
            public IList<string> genres { get; set; }
            public string href { get; set; }
            public IList<Image> images { get; set; }
            public string name { get; set; }

        }
    }
}

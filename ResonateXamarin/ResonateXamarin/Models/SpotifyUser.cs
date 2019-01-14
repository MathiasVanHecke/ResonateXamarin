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
        public string beschrijving { get; set; }
        public string urlPf { get; set; }

        private string _nameAndAge;
        public string nameAndAge
        {
            get
            {
                var today = DateTime.Today;
            
                var age = today.Year - Convert.ToDateTime(birthdate).Year;
        
                if (Convert.ToDateTime(birthdate) > today.AddYears(-age)) age--;
                _nameAndAge = $"{display_name}, {age} ";
                return _nameAndAge;
            }
        }


        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }


    }


}
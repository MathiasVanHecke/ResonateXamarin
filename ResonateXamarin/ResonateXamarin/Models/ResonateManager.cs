using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ResonateXamarin.Models
{
    public static class ResonateManager
    {
        #region Spotify Api
        public static async Task<SpotifyUser> GetSpotifyUserAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.spotify.com/v1/me";
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["bearer"].ToString());
                    String result = await client.GetStringAsync(url);
                    SpotifyUser user = JsonConvert.DeserializeObject<SpotifyUser>(result);
                    Debug.WriteLine(user);
                    return user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<SpotifyData> GetSpotifyUserDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.spotify.com/v1/me/top/artists?time_range=medium_term&limit=3";
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["bearer"].ToString());
                    String result = await client.GetStringAsync(url);
                    SpotifyData data = JsonConvert.DeserializeObject<SpotifyData>(result);
                    Debug.WriteLine(data);
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Resonate Api

        #region User
        public static async Task<Boolean> RegisterUser(SpotifyUser user)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://resonateapi.azurewebsites.net/api/user";
                try
                {
                    string json = JsonConvert.SerializeObject(user);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();
                    return Convert.ToBoolean(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<SpotifyUser> GetUser(string userId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://resonateapi.azurewebsites.net/api/user/{userId}";
                try
                {
                    String result = await client.GetStringAsync(url);
                    SpotifyUser data = JsonConvert.DeserializeObject<SpotifyUser>(result);
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        #endregion

        #region Genre en Artiesten
        public static async Task<List<String>> GetGenres()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://resonateapi.azurewebsites.net/api/genre";
                try
                {
                    String result = await client.GetStringAsync(url);
                    List<String> data = JsonConvert.DeserializeObject<List<String>>(result);
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<List<Artist>> GetArists()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://resonateapi.azurewebsites.net/api/artist";
                try
                {
                    List<Artist> data = JsonConvert.DeserializeObject<List<Artist>>(await client.GetStringAsync(url));
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Matches
        public static async Task<ObservableCollection<SpotifyUser>> GetPotMatches(int matchLevel, String name)
        {
            using (HttpClient client = new HttpClient())
            {

                string url = $"https://resonateapi.azurewebsites.net/api/match/{(Application.Current.Properties["user_id"].ToString())}/{matchLevel}/{name.ToLower()}";
                try
                {
                    ObservableCollection<SpotifyUser> data = JsonConvert.DeserializeObject<ObservableCollection<SpotifyUser>>(await client.GetStringAsync(url));
                    return data;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static async Task<Boolean> AddMatch(SpotifyUser user2)
        {
            using (HttpClient client = new HttpClient())
            {
                const string currentUser = "koen.vanhecke";

                string url = $"https://resonateapi.azurewebsites.net/api/match/{currentUser}/{user2.id}";
                try
                {
                    string json = JsonConvert.SerializeObject(user2);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    SpotifyUser user = JsonConvert.DeserializeObject<SpotifyUser>(await response.Content.ReadAsStringAsync());
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #endregion
    }
}

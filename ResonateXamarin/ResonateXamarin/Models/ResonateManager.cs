using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResonateXamarin.Models
{
    public class ResonateManager
    {
        public ResonateManager()
        {
        }

        public static async Task<SpotifyUser> GetSpotifyUserAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.spotify.com/v1/me";
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.UserBearer);
                    String result = await client.GetStringAsync(url);
                    SpotifyUser user = JsonConvert.DeserializeObject<SpotifyUser>(result);
                    Debug.WriteLine(GlobalVariables.UserBearer);
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
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVariables.UserBearer);
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
    }
}

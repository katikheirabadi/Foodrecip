using Foodrecip.Models.Page3;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json;
using Foodrecip.Models.Page2;
using Foodrecip.Services.page1;
using System.Linq;
using System.Collections.Generic;

namespace Foodrecip.Services
{
    public class ThemealdbClient
    {
        private readonly HttpClient client;
        private const string BaseAddress = "https://www.themealdb.com";
        private const string apiKey = "1";

        public ThemealdbClient(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAddress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public FoodList GetDetail_ing(string food)
        {
            var httpResponse = client.GetAsync($"api/json/v1/1/list.php?i={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList foods;
            HttpContent content = httpResponse.Content;
            var stringContent = content.ReadAsStringAsync().Result;
            foods = JsonSerializer.Deserialize<FoodList>(stringContent);
            return foods;
        }    
        public FoodList GetDetail_cat(string food)
        {
            var httpResponse = client.GetAsync($"api/json/v1/1/list.php?c={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList foods;
            HttpContent content = httpResponse.Content;
            var stringContent = content.ReadAsStringAsync().Result;
            foods = JsonSerializer.Deserialize<FoodList>(stringContent);
            return foods;
        }
        public FoodList GetDetail_area(string food)
        {
            var httpResponse = client.GetAsync($"api/json/v1/1/list.php?a={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList foods;
            HttpContent content = httpResponse.Content;
            var stringContent = content.ReadAsStringAsync().Result;
            foods = JsonSerializer.Deserialize<FoodList>(stringContent);
            return foods;
        }
        public List<FoodList> GetFaveriteFood(string email)
        {
            const int count = 2;
            List<FoodList> lu = new List<FoodList>();
            var user = UserServises.us.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null;
            else
            {
                if (user.Favorites.Count <= count)
                {
                    foreach (var food in user.Favorites)
                        lu.Add(GetDetail_ing(food));
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        lu.Add(GetDetail_ing(user.Favorites[i]));
                    }
                }
                return lu;
            }
        }
    }

}

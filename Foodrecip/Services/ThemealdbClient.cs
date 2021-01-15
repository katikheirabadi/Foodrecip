using Foodrecip.Models.Page3;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json;
using Foodrecip.Models.Page2;
using Foodrecip.Models.Page4;

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
        public FoodList GetDetail_meal(string food)
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
        public DetailView showDetail(string id)
        {
            var httpResponse = client.GetAsync($"api/json/v1/1/lookup.php?i={id}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            DetailView detail;
            HttpContent content = httpResponse.Content;
            var stringContent = content.ReadAsStringAsync().Result;
            detail = JsonSerializer.Deserialize<DetailView>(stringContent);
            return detail;
        }
    }

}

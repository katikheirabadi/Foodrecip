using Foodrecip.Models.Page3;
using System;
using System.Net.Http;
using System.Text.Json;

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

        public FoodList GetDetail_ing(string foodname)
        {
            var httpresponse = client.GetAsync($"api/json/v1/1/list.php?i={foodname}").Result;
            httpresponse.EnsureSuccessStatusCode();
            if(!httpresponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList foods;
            HttpContent httpContent = httpresponse.Content;
            string stringcontent = httpContent.ReadAsStringAsync().Result;
            foods = JsonSerializer.Deserialize<FoodList>(stringcontent);

            return foods;
        }

        
    }

}

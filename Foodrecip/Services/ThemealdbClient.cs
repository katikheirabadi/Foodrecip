using System;
using System.Net.Http;
using System.Text.Json;
using Foodrecip.Models.Page2;

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

        public AreaList ListAreas(int x)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/list.php?a=list").Result;

            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode) { return null; }
            //AreaList areaListFull = new AreaList();
            AreaList resultTemp;
            using (HttpContent content = httpResponse.Content)
            {
                string stringContent = content.ReadAsStringAsync().Result;
                resultTemp = JsonSerializer.Deserialize<AreaList>(stringContent);

            }
            AreaList result = new AreaList();
            for (int i=0; i<x; i++) {
                result.meals.Add(resultTemp.meals[i]);
            }
            return result;
        }

    }

}

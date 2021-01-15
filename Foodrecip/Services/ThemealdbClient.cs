using System;
using System.Net.Http;
using System.Text.Json;
using Foodrecip.Models.Page2;
using System.Linq;

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

        public AreaList ListAreas(int size)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/list.php?a=list").Result;

            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode) { return null; }
            AreaList resultTemp;
            using (HttpContent content = httpResponse.Content)
            {
                string stringContent = content.ReadAsStringAsync().Result;
                resultTemp = JsonSerializer.Deserialize<AreaList>(stringContent);

            }
            var take = resultTemp.meals.Take(size);
            AreaList result = new AreaList();
            result.meals.AddRange(take);
            return result;
        }

        public CategoryList ListCategories(int size)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/list.php?c=list").Result;

            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode) { return null; }
            CategoryList resultTemp;
            using (HttpContent content = httpResponse.Content)
            {
                string stringContent = content.ReadAsStringAsync().Result;
                resultTemp = JsonSerializer.Deserialize<CategoryList>(stringContent);

            }
            var take = resultTemp.meals.Take(size);
            CategoryList result = new CategoryList();
            result.meals.AddRange(take);
            return result;
        }

        public IngredientOutputList ListIngredients(int size)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/list.php?i=list").Result;

            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode) { return null; }
            IngredientOutputList resultTemp = new IngredientOutputList();
            using (HttpContent content = httpResponse.Content)
            {
                string stringContent = content.ReadAsStringAsync().Result;
                var resultService = JsonSerializer.Deserialize<IngredientList>(stringContent);
                var result1 = resultService.meals.Select(x => new IngredientOutput() { id = x.idIngredient, ingredient = x.strIngredient }).Take(size).ToList();
                resultTemp.result = result1;

            }

            return resultTemp;
        }

    }

}

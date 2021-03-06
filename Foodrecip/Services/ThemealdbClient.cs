﻿using Foodrecip.Models.Page3;
using System;
using System.Net.Http;
using System.Text.Json;
using Foodrecip.Models.Page2;
using System.Linq;
using Foodrecip.Models.Page3;
using Foodrecip.Models.Page4;
using System.Collections.Generic;
using Foodrecip.Services.page1;

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
                var result1 = resultService.meals.Select(x => new IngredientOutput() { id = x.idIngredient, ingredient = x.strIngredient }).ToList();
                resultTemp.result = result1;
            }

            return resultTemp;
        }




        public FoodList GetDetail_ing(string food)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/filter.php?i={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList resultTemp = new FoodList();
            using (HttpContent content = httpResponse.Content)
            {
                var stringContent = content.ReadAsStringAsync().Result;
                var resultService = JsonSerializer.Deserialize<FoodListSite>(stringContent);
                var result2 = resultService.meals.Select(x => new Food() { id = x.idMeal, food = x.strMeal, foodthumb = x.strMealThumb }).Take(6).ToList();
                resultTemp.foods = result2;
            }
            return resultTemp;
        }



        public FoodList GetDetail_meal(string food)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/filter.php?c={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList resultTemp = new FoodList();
            using (HttpContent content = httpResponse.Content)
            {
                var stringContent = content.ReadAsStringAsync().Result;
                var resultService = JsonSerializer.Deserialize<FoodListSite>(stringContent);
                var result2 = resultService.meals.Select(x => new Food() { id = x.idMeal, food = x.strMeal, foodthumb = x.strMealThumb }).ToList();
                resultTemp.foods = result2;
            }
            return resultTemp;
        }


        public FoodList GetDetail_area(string food)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/filter.php?a={food}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            FoodList resultTemp = new FoodList();
            using (HttpContent content = httpResponse.Content)
            {
                var stringContent = content.ReadAsStringAsync().Result;
                var resultService = JsonSerializer.Deserialize<FoodListSite>(stringContent);
                var result2 = resultService.meals.Select(x => new Food() { id = x.idMeal, food = x.strMeal, foodthumb = x.strMealThumb }).ToList();
                resultTemp.foods = result2;
            }
            return resultTemp;
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





        public DetailView detailshow(int Myid)
        {
            var httpResponse = client.GetAsync($"/api/json/v1/{apiKey}/lookup.php?i={Myid}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            DetailView resultTemp = new DetailView();
            using (HttpContent content = httpResponse.Content)
            {
                var stringContent = content.ReadAsStringAsync().Result;
                var resultService = JsonSerializer.Deserialize<DetailSiteList>(stringContent);

                resultTemp.id = resultService.meals.FirstOrDefault().idMeal;
                resultTemp.title = resultService.meals.FirstOrDefault().strMeal;
                resultTemp.category = resultService.meals.FirstOrDefault().strCategory;
                resultTemp.area = resultService.meals.FirstOrDefault().strArea;
                resultTemp.instructions = resultService.meals.FirstOrDefault().strInstructions;
                resultTemp.mealThumb = resultService.meals.FirstOrDefault().strMealThumb;
            }
            return resultTemp;
        }

    }

}

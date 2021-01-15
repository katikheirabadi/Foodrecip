using System;
using System.Net.Http;

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
        
    }

}

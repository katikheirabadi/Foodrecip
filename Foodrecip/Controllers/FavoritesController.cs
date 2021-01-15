using Foodrecip.Models.Page3;
using Foodrecip.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ThemealdbClient client;
        public FavoritesController(ThemealdbClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public FoodList Get([FromQuery] string email)
        {
            return GetFaveriteFood(email);
        }

        private FoodList GetFaveriteFood(string email)
        {
            throw new NotImplementedException();
        }
    }
}

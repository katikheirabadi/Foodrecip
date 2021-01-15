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
    public class FoodsController : ControllerBase
    {
        private readonly ThemealdbClient themealdbclient;
        public FoodsController(ThemealdbClient theme)
        {
            themealdbclient = theme;
        }
        [HttpGet("{cat}&{selected}")]
        public FoodList Get([FromQuery] string cat, string food)
        {
            var foodList = new FoodList();

            switch (cat)
            {
                case "ing":
                    foodList = themealdbclient.GetDetail_ing(food);
                    break;
                case "meal":
                    foodList = themealdbclient.GetDetail_meal(food);
                    break;
                case "area":
                    foodList = themealdbclient.GetDetail_area(food);
                    break;
                default:
                    foodList = null;
                    break;
            }
            return foodList;


        }
    }
}

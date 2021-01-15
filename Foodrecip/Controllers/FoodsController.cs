using Foodrecip.Models.Page3;
using Foodrecip.Models.Page4;
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
        [HttpGet]
        public FoodList Get([FromQuery] string cat,[FromQuery] string selected)
        {
            var foodList = new FoodList();

            switch (cat)
            {
                case "ing":
                    foodList = themealdbclient.GetDetail_ing(selected);
                    break;
                case "meal":
                    foodList = themealdbclient.GetDetail_meal(selected);
                    break;
                case "area":
                    foodList = themealdbclient.GetDetail_area(selected);
                    break;
                default:
                    foodList = null;
                    break;
            }
            return foodList;

            
        }
        [HttpGet("{id}")]
        public DtsiteList show(string id)
        {
            return themealdbclient.detailshow(id);
        }
    }
}

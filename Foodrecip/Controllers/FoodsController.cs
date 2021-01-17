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
        public FoodList Get([FromQuery] FoodDetail foodDetail)
        {
            var foodList = new FoodList();

            switch (foodDetail.cat)
            {
                case "ing":
                    foodList = themealdbclient.GetDetail_ing(foodDetail.selected);
                    break;
                case "meal":
                    foodList = themealdbclient.GetDetail_meal(foodDetail.selected);
                    break;
                case "area":
                    foodList = themealdbclient.GetDetail_area(foodDetail.selected);
                    break;
                default:
                    foodList = null;
                    break;
            }
            return foodList;
        }

        [HttpGet("{id}")]
        public DetailView show(int id)
        {
            return themealdbclient.detailshow(id);
        }


    }
}

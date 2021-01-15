using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodrecip.Models.Page2;
using Foodrecip.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodrecip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : Controller
    {
        private readonly ThemealdbClient client;

        public IngredientsController(ThemealdbClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public IngredientOutputList GetIngrediens([FromQuery] int size)
        {
            return client.ListIngredients(size);
        }
    }
}

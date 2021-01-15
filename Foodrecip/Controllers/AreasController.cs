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
    public class AreasController : ControllerBase
    {
        private readonly ThemealdbClient client;

        public AreasController(ThemealdbClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public AreaList GetAreas([FromQuery] int size)
        {
            return client.ListAreas(size);
        }




    }
}

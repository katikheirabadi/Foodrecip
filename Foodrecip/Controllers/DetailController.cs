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
    public class DetailController : ControllerBase
    {
        private readonly ThemealdbClient detail;
        public DetailController(ThemealdbClient detailshow)
        {
            detail = detailshow;
        }
        [HttpGet("{id}")]
        public DetailView show(string id)
        {
            return detail.detailshow(id);
        }
    }
}

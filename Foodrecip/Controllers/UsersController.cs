using Foodrecip.Models.page1;
using Foodrecip.Services.page1;
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
    public class UsersController : ControllerBase
    {
        private readonly UserServises repository;
        public UsersController()
        {
            repository = new UserServises();
        }
        [HttpPost]
        public User Create([FromBody] User user)
        {
            repository.Insert(user);
            return user;
        }
    }
}

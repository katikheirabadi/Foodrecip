using Foodrecip.Models.page1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Services.page1
{
    public class UserServises
    {
        static List<User> us = new List<User>();
        
        public void Insert(User user)
        {
            var user2 = new User();
            user2.Email = user.Email;
            user2.Favorites = user.Favorites;
            us.Add(user2);
        }
    }
}

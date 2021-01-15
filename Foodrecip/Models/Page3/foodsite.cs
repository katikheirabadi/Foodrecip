using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Models.Page3
{
    public class foodsite
    {
        public string strMeal { get; set; }
        public string strMealThumb { get; set; }
        public string idMeal { get; set; }
    }
    public class Foodlistsite
    {
        public List<foodsite> meals { get; set; }
        public Foodlistsite()
        {
            meals = new List<foodsite>();
        }

    }
}

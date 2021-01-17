using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Models.Page3
{
    public class FoodSite
    {
        public string strMeal { get; set; }
        public string strMealThumb { get; set; }
        public string idMeal { get; set; }
    }


    public class FoodListSite
    {
        public List<FoodSite> meals { get; set; }
        public FoodListSite()
        {
            meals = new List<FoodSite>();
        }

    }

    public class FoodDetail
    {
        public string cat { get; set; }
        public string selected { get; set; }
    }
}

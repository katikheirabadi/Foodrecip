using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Models.Page4
{
    public class DetailSite
    {
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strDrinkAlternate { get; set; }
        public string strCategory { get; set; }
        public string strArea { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }



    }
    public class DetailSiteList
    {
        public List<DetailSite> meals { get; set; }

        public DetailSiteList()
        {
            meals = new List<DetailSite>();
        }
    }
}

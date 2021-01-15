using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Models.Page4
{
    public class DetailView
    {
        public string id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string area { get; set; }
        public string instructions { get; set; }
        public string mealThumb { get; set; }
    }
    public class DvList
    {
        public List<DetailView> meals;
       
    }
}

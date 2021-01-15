using System;
using System.Collections.Generic;

namespace Foodrecip.Models.Page2
{
    public class Area
    {
        public string strArea { get; set; }
    }

    public class AreaList {

        public List<Area> meals { get; set; }
        public AreaList()
        {
            meals = new List<Area>();
        }
    }
}

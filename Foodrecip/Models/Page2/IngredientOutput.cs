using System;
using System.Collections.Generic;

namespace Foodrecip.Models.Page2
{
    public class IngredientOutput
    {
        public string id { get; set; }
        public string ingredient { get; set; }


    }

    public class IngredientOutputList
    {
        public List<IngredientOutput> result { get; set; }

    }
}

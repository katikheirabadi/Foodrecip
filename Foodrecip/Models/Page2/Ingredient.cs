using System;
using System.Collections.Generic;

namespace Foodrecip.Models.Page2
{
    public class Ingredient
    {
        public string idIngredient { get; set; }
        public string strIngredient { get; set; }
    }

    public class IngredientList {
        public List<Ingredient> meals { get; set; }
        public IngredientList()
        {
            meals = new List<Ingredient>();
        }
    }
}

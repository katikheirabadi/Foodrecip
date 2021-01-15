using System;
using System.Collections.Generic;

namespace Foodrecip.Models.Page2
{
    public class Category
    {
        public string strCategory { get; set; }
    }

    public class CategoryList
    {

        public List<Category> meals { get; set; }
        public CategoryList()
        {
            meals = new List<Category>();
        }
    }
}

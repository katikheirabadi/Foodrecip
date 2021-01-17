using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodrecip.Models.Page4
{
    public class Detailvi
    {
         public string idMeal {get;set;}
         public string strMeal { get; set; }
         public string strCategory { get; set; }
         public string strArea { get; set; }
         public string strMealThumb { get; set; }
         public string strInstructions { get; set; }
         public string strDrinkAlternate { get; set; }
         public string strTags { get; set; }
         public string strYoutube { get; set; }
         public string strIngredient1 { get; set; }
         public string strIngredient2 { get; set; }
         public string strIngredient3 { get; set; }
         public string strIngredient4 { get; set; }
         public string strIngredient5 { get; set; }
         public string strIngredient6 { get; set; }
         public string strIngredient7 { get; set; }
         public string strIngredient8 { get; set; }
         public string strIngredient9{ get; set; }
         public string strIngredient10{ get; set; }
         public string strIngredient11{ get; set; }
         public string strIngredient12{ get; set; }
         public string strIngredient13{ get; set; }
         public string strIngredient14{ get; set; }
         public string strIngredient15{ get; set; }
         public string strIngredient16{ get; set; }
         public string strIngredient17{ get; set; }
         public string strIngredient18{ get; set; }
         public string strIngredient19{ get; set; }
         public string strIngredient20 { get; set; }
         public string strMeasure1 { get; set; }
         public string strMeasure2 { get; set; }
     //    public string strMeasure3 { get; set; }
         public string strMeasure4 { get; set; }
         public string strMeasure5 { get; set; }
         public string strMeasure6 { get; set; }
         public string strMeasure7 { get; set; }
         public string strMeasure8 { get; set; }
         public string strMeasure9 { get; set; }
         public string strMeasure10 { get; set; }
         public string strMeasure11 { get; set; }
         public string strMeasure12 { get; set; }
        

    }
    public class DtsiteList
    {
        public List<Detailvi> meals;
        public DtsiteList()
        {
            meals = new List<Detailvi>();
        }
    }
}

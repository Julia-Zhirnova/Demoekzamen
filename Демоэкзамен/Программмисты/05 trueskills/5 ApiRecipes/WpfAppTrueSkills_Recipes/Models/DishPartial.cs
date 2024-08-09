using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTrueSkills_Recipes.Models
{
    public partial class Dish
    {
        public double ServingPrice
        {
            get
            {
                var allIngredients = CookingStages.SelectMany(x => x.IngredientOfStages).ToList();
                double totalSum = allIngredients.Sum(x => x.Quantity * x.Ingredient.Price);
                double price = totalSum / ServingQuantity;
                return price;
            }
        }

        public string PhotoFullPath => $"/WpfAppTrueSkills_Recipes;component/Resources/{PhotoPath}";
    }
}

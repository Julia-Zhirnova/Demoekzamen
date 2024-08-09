using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfAppTrueSkills_Recipes.Models
{
    public partial class Ingredient
    {
        //public double Price
        //{
        //    get
        //    {
        //        return (double)Cost / CostForCount;
        //    }
        //}

        public double Price => (double)Cost / CostForCount;

        public SolidColorBrush PriceColor
        {
            get
            {
                if (Cost <= 60)
                    return Brushes.LightGreen;
                else if (Cost <= 200)
                    return Brushes.LightYellow;
                else
                    return Brushes.LightPink;
            }
        }
    }
}

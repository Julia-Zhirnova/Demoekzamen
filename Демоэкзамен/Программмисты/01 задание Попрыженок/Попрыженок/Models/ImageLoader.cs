using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Попрыженок.Models
{
    public partial class Agent
    {
        public string ImageAgent
        {
            get
            {
                string imageSource = "";
                string imageNullValue = "";
                string dictionary = Environment.CurrentDirectory;

                if((Logo == null ) || (Logo == ""))
                {
                    imageNullValue = "Resources\\picture.png";
                    imageSource = dictionary.Replace("bin\\Debug", "") + imageNullValue;
                }
                else
                {
                    imageNullValue = Logo;
                    imageSource = dictionary.Replace("bin\\Debug", "") + imageNullValue;
                }

                return imageSource;
            }
        }
        public int Discount
        {
            get
            {                
                int sale = Convert.ToInt32(ProductSale.Sum(c => c.Product.MinCostForAgent * c.ProductCount));
                if (sale >= 0 && sale < 10000)
                {
                    return 0;
                }
                else if (sale > 10000 && sale < 50000)
                {
                    return 5;
                }
                else if (sale > 50000 && sale < 150000)
                {
                    return 10;
                }
                else if (sale > 150000 && sale < 500000)
                {
                    return 20;
                }
                else
                {
                    return 25;
                    
                }
            }
        }    
        public string Rsc
        {
            get
            {
                int sale = Convert.ToInt32(ProductSale.Sum(c => c.Product.MinCostForAgent * c.ProductCount));
                if (sale > 500000)
                {
                    return "LightGreen";
                }
                else
                    return "Black";
            }
        }
    } 
}

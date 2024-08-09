using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordApp.Models
{
    internal class Sale
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}

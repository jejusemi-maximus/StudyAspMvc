using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private IValueCalcuator calc;

        public ShoppingCart(IValueCalcuator Linqs)
        {
            calc = Linqs;
        }

        public IEnumerable<Product> prod { get; set; }

        public decimal SumTotal()
        {
            return calc.ValueProducts(prod);
        }
    }
    
}
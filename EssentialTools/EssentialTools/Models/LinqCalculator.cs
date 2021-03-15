using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqCalculator
    {
        public decimal SumProduct(IEnumerable<Product> prod)
        {
            return prod.Sum(p => p.Price);
        }
    }
}
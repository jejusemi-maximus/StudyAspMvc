using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqCalculator : IValueCalcuator
    {
        private IDiscountHelper dicounter;
        public decimal ValueProducts(IEnumerable<Product> prod)
        {
            return dicounter.ApplyDiscount(prod.Sum(p=>p.Price));
        }


        public LinqCalculator(IDiscountHelper discountParam)
        {
            dicounter = discountParam;
        }


    }
}
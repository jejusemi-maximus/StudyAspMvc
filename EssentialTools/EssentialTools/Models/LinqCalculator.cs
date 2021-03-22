using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqCalculator : IValueCalcuator
    {
        public static int counter = 0;

        private IDiscountHelper dicounter;
        public decimal ValueProducts(IEnumerable<Product> prod)
        {
            return dicounter.ApplyDiscount(prod.Sum(p=>p.Price));
        }


        public LinqCalculator(IDiscountHelper discountParam)
        {
            dicounter = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("tmstamce {0}", ++counter));

        }


    }
}
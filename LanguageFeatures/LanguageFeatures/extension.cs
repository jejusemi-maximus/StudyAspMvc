using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures
{
    public static class extension
    {
        public static int SumPrice(this Products product)
        {
            int total = 0;
            foreach(Products prod in product)
            {
                total += prod.Price;
            }
            return total;
        }
    }
}
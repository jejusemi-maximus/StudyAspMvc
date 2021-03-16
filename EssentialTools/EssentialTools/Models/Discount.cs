using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{

    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
    public class DefaultDiscount : IDiscountHelper
    {
        public decimal DiscountSize;

        public DefaultDiscount(decimal DiscountParam)
        {
            DiscountSize = DiscountParam;
        }
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize * totalParam));
        }
    }
}
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Repository
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShoppingDetail detail);
    }
}

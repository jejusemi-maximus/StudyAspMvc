using SportStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;

namespace SportStore.Domain.ConCreate
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext Context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get
            {
                return Context.Products;
            }
        }
    }
}

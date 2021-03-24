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

        public Product DeleteProduct(int Productid)
        {
            Product prod = Context.Products.Find(Productid);
            if (prod != null)
            {
                Context.Products.Remove(prod);
                Context.SaveChanges();
            }
            return prod;

        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                Context.Products.Add(product);
            }
            else
            {
                Product dbEntry = Context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            Context.SaveChanges();
        }


    }
}

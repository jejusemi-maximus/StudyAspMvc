using Moq;
using Ninject;
using SportStore.Domain;
using SportStore.Domain.Entities;
using SportStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Infra
{
    public class DependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public DependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product {Name ="baseball",Price=25 },
                new Product {Name="soccer",Price=35 },
                new Product {Name="ballyball",Price=66 }
            });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
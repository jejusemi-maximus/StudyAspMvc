using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Infra
{
    public class NDR : IDependencyResolver
    {
        private IKernel kernel;

        public NDR(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();


        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalcuator>().To<LinqCalculator>();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscount>().WithConstructorArgument("DiscountParam", 50m);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqCalculator>();
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
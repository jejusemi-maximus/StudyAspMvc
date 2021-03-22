using Ninject;
using SportStore.Domain.ConCreate;
using SportStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSettings email = new EmailSettings
            {
                WriteAsfile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", email);
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
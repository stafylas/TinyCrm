using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using TinyCrm.Core.Services;

namespace TinyCrm.Core
{
   public class ServiceRegistrator : Autofac.Module
    {
      public static void RegisterServices(ContainerBuilder builder)
        {
            if (builder == null) {
                throw new ArgumentException(nameof(builder));
            }
            
            builder
                .RegisterType<ProductService>()
                .InstancePerLifetimeScope()
                .As<IProductService>();

            builder
                .RegisterType<CustomerService>()
                .InstancePerLifetimeScope()
                .As<ICustomerService>();

            builder
                .RegisterType<OrderService>()
                .InstancePerLifetimeScope()
                .As<IOrderService>();

            builder
                .RegisterType<Data.TinyCrmDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();

           
        }
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            return builder.Build();
        }
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }
    }
}

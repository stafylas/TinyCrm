using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using TinyCrm.Core;
using TinyCrm.Core.Data;

namespace TinyCrm.Tests
{
    public class TinyCrmFixture : IDisposable
    {

        public TinyCrmDbContext DbContext { get; private set; }
        public Autofac.ILifetimeScope Container { get; private set; }
        public TinyCrmFixture() 
        {
           
            Container = ServiceRegistrator.GetContainer().BeginLifetimeScope();
            DbContext = Container.Resolve<TinyCrmDbContext>();
        }
        public void Dispose()
        {
            Container.Dispose();
        }
    }
}

using Leaf.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Leaf.Core.Infrastructure;
//using Leaf.Con.Helper;

namespace Leaf.Con
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
           // builder.RegisterType<XlsHelper>().As<IXlsHelper>().SingleInstance();

        }
    }
}

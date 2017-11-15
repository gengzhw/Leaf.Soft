using Leaf.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Leaf.Core.Infrastructure;
using Leaf.Core.Data;
using Leaf.Data;
using Leaf.Services.Demo;
using Leaf.Services.Users;
using Microsoft.EntityFrameworkCore;
using Leaf.Core.Configuration;
using Leaf.Services.Spreads;
using Leaf.Services.Helpers;

namespace Leaf.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            builder.Register<DbContext>(c => new LeafObjectContext(LeafConfig.connStr)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterType<TestService>().As<ITest>().SingleInstance();
            builder.RegisterType<UserServices>().As<IUserServices>().SingleInstance();

            builder.RegisterType<QichachaServices>().As<IQichachaServices>().SingleInstance();

            //builder.RegisterType<XlsHelper>().As<IXlsHelper>().SingleInstance();
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }
}

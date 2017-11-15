using Leaf.Core.Infrastructure;
using Leaf.Core.Infrastructure.DependencyManagement;
using Leaf.Core.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Leaf.Core.Dependency;
using System;
using System.Collections.Generic;

namespace Leaf.Core.Infrastructure
{
   public class LeafEngine: IEngine
    {

        private IConfigurationRoot _configuration;
        private IHostingEnvironment _hostingEnvironment;
        private ContainerManager _containerManager;
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
            set { _containerManager = value; }
        }
        public LeafEngine()
        {
            
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            //var container = builder.Build();
            // DependencyRegister(container);
            var container = DependencyRegister(builder);
            this._containerManager = new ContainerManager(container);
            return container.Resolve<IServiceProvider>();
        }

        protected IContainer DependencyRegister(ContainerBuilder builder)
        {

            Log.WriteLog("开始执行依赖注入......");
            var typeFinder = new WebAppTypeFinder();
           // var builder = new ContainerBuilder();
                        
           

            try
            {
               

                //类型查询器依赖注入
                builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
              //  builder.Update(container);
                //builder.Populate(container);
                //builder.Build();

                //自定义依赖注入
               // builder = new ContainerBuilder();
                var dependencyRegistrar = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                List<IDependencyRegistrar> dependencyAutofacRegistrarList = new List<IDependencyRegistrar>();
                foreach (var dependencyRegistrarItem in dependencyRegistrar)
                {
                    dependencyAutofacRegistrarList.Add((IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrarItem));
                }
                foreach (var dependencyAutofacRegistrarListItem in dependencyAutofacRegistrarList)
                {
                    Log.WriteLog($"正在注入{dependencyAutofacRegistrarListItem.GetType().FullName}类型");
                    dependencyAutofacRegistrarListItem.Register(builder, typeFinder);
                }
                //  builder.Update(container);

                // container = builder.Build();
                //--
                // _containerManager = new ContainerManager(container);

                return builder.Build();
            }
            catch (Exception ex)
            {
                Log.WriteLog($"依赖注入失败，异常消息：{ex.Message}");
                throw;
            }
        }

        public void Initialize(IConfigurationRoot configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _hostingEnvironment = env;
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }
    }
}

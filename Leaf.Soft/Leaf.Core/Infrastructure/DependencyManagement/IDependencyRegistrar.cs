using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaf.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// 
    /// gengzhw
    /// 
    /// 2017/6/26 上午11:30:13
    /// 
    /// 依赖注入接口
    /// 
    /// </summary>
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Datas.Ef;
using Autofac;

namespace Applications.Service.Tests.Configs
{
    /// <summary>
    /// 应用程序Ioc配置
    /// </summary>
    public class IocConfig : OBear.DI.Autofac.ConfigBase
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}

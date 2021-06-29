using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutofacExperiment.Access.Deamon;

namespace AutofacExperiment.Access.Modules
{
    public class DAModules : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// 參考資料：http://autofac.readthedocs.io/en/latest/lifetime/instance-scope.html
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load("NineYi.ERP.DA.ERPDB");

            //builder.RegisterAssemblyTypes(assembly).OwnedByLifetimeScope();

            //// 目前NMQV2的物件生命週期policy
            builder.RegisterType<DeamonResourceRepository>()
                .As<IDeamonResourceRepository>()
                .InstancePerDependency();

            //builder.RegisterType<DeamonResourceRepository>()
            //    .As<IDeamonResourceRepository>()
            //    .OwnedByLifetimeScope();

            //// 這個生命週期讓 MemoryLeakMethod02 不會有 memory leak 的問題
            //// 因為在同一個scope下取得的實體，將會是同一個實體。(新的scope就是新的實體)
            //builder.RegisterType<DeamonResourceRepository>()
            //    .As<IDeamonResourceRepository>()
            //    .InstancePerLifetimeScope();

            ////用這個policy就不用擔心 memory leak 的問題
            //builder.RegisterType<DeamonResourceRepository>()
            //    .As<IDeamonResourceRepository>()
            //    .SingleInstance();    
        }
    }
}

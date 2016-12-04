using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace AutofacExperiment
{
    internal class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<NineYi.ERP.DA.ERPDB.Modules.DAModules>();

            using (var container = builder.Build())
            {
                MemoryLeakMethod02(container);
            }
        }

        /// <summary>
        /// 直接使用container取出依賴 (不建議使用)
        /// </summary>
        /// <param name="container"></param>
        private static void MemoryLeakMethod01(IContainer container)
        {
            while (1 == 1)
            {
                var resource = container.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>();

                resource.ResourceMonster();
            }
        }

        /// <summary>
        /// 容易不自覺產生memory的語法
        /// </summary>
        /// <param name="container">The container.</param>
        private static void MemoryLeakMethod02(IContainer container)
        {
            using (var lifetimescope = container.BeginLifetimeScope())
            {
                while (1 == 1)
                {
                    using (var resource = lifetimescope.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>())
                    {
                        resource.ResourceMonster();
                    }
                }
            }
        }

        /// <summary>
        /// 容易不自覺產生memory的語法，但使用 container 取出物件
        /// </summary>
        /// <param name="container"></param>
        private static void MemoryLeakMethod03(IContainer container)
        {
            while (1 == 1)
            {
                using (var resource = container.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>())
                {
                    resource.ResourceMonster();
                }
            }
        }

        /// <summary>
        /// 直接new出來不使用Autofac管理物件，交予 .NET Framework 底層的GC來管理記憶體
        /// </summary>
        /// <param name="container"></param>
        private static void NoMemoryLeakMethod01(IContainer container)
        {
            while (1 == 1)
            {
                var resource = new NineYi.ERP.DA.ERPDB.Deamon.DeamonResourceRepository();
                resource.ResourceMonster();
            }
        }

        /// <summary>
        /// 使用Child Scope來管理這區域中產生的物件，可以確保物件在這個區域使用完畢後會被釋放
        /// </summary>
        /// <param name="container"></param>
        private static void NoMemoryLeakMethod02(IContainer container)
        {
            while (1 == 1)
            {
                using (var lifetimescope = container.BeginLifetimeScope())
                {
                    using (var resource = lifetimescope.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>())
                    {
                        resource.ResourceMonster();
                    }
                }
            }
        }

        /// <summary>
        /// 使用Child Scope來管理這區域中產生的物件，可以確保物件在這個區域使用完畢後會被釋放(意義同 NoMemoryLeakMethod02)
        /// </summary>
        /// <param name="container"></param>
        private static void NoMemoryLeakMethod03(IContainer container)
        {
            while (1 == 1)
            {
                using (var lifetimescope = container.BeginLifetimeScope())
                {
                    var resource = lifetimescope.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>();

                    resource.ResourceMonster();
                }
            }
        }

        /// <summary>
        /// 使用Child Scope來管理這區域中產生的物件，可以確保物件在這個區域使用完畢後會被釋放
        /// </summary>
        /// <param name="container"></param>
        private static void NoMemoryLeakMethod04(IContainer container)
        {
            using (var lifetimescope = container.BeginLifetimeScope())
            {
                while (1 == 1)
                {
                    using (var childScope = lifetimescope.BeginLifetimeScope())
                    {
                        using (var resource = childScope.Resolve<NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository>())
                        {
                            resource.ResourceMonster();
                        }
                    }
                }
            }
        }
    }
}
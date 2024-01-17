using System.Threading;
using Autofac;
using AutofacExperiment.Access.Daemon;
using AutofacExperiment.Access.Modules;

namespace AutofacExperiment;

internal class Program
{
    /// <summary>
    ///     Mains the specified arguments.
    /// </summary>
    /// <param name="args">The arguments.</param>
    private static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<DAModules>();

        using var container = builder.Build();
        MemoryLeakMethod01(container);
    }

    /// <summary>
    ///     直接使用container取出依賴 (不建議使用)
    /// </summary>
    /// <param name="container"></param>
    private static void MemoryLeakMethod01(IContainer container)
    {
        while (true)
        {
            var service = container.Resolve<IDomainService>();

            service.GetServiceName();
            
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    ///     容易不自覺產生 memory leak 的語法
    /// </summary>
    /// <param name="container">The container.</param>
    private static void MemoryLeakMethod02(IContainer container)
    {
        using var lifetimeScope = container.BeginLifetimeScope();
        while (true)
        {
            using var service = lifetimeScope.Resolve<IDomainService>();
            service.GetServiceName();
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    ///     直接 new 出來不使用 Autofac 管理物件，交予 .NET Framework 底層的 GC 來管理記憶體
    /// </summary>
    /// <param name="container"></param>
    private static void NoMemoryLeakMethod01(IContainer container)
    {
        while (true)
        {
            var service = new DomainService(new DaemonResourceRepository());
            service.GetServiceName();
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    ///     使用Child Scope來管理這區域中產生的物件，可以確保物件在這個區域使用完畢後會被釋放
    /// </summary>
    /// <param name="container"></param>
    private static void NoMemoryLeakMethod02(IContainer container)
    {
        while (true)
        {
            using var lifetimeScope = container.BeginLifetimeScope();
            using var resource = lifetimeScope.Resolve<IDomainService>();
            resource.GetServiceName();
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    ///     使用 Child Scope 來管理這區域中產生的物件，可以確保物件在這個區域使用完畢後會被釋放
    /// </summary>
    /// <param name="container"></param>
    private static void NoMemoryLeakMethod03(IContainer container)
    {
        using var lifetimeScope = container.BeginLifetimeScope();
        while (true)
        {
            using var childScope = lifetimeScope.BeginLifetimeScope();
            using var resource = childScope.Resolve<IDomainService>();
            resource.GetServiceName();
            Thread.Sleep(1000);
        }
    }
}
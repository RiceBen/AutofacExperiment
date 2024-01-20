using System.Threading;
using Autofac;
using AutofacExperiment.Access.Daemon;
using AutofacExperiment.Access.Modules;

namespace AutofacExperiment;

internal class Program
{
    /// <summary>
    /// Experiment entry point
    /// </summary>
    /// <param name="args">The arguments.</param>
    private static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<DAModules>();

        using var container = builder.Build();
        Scenario01(container);
    }

    /// <summary>
    /// Use <see cref="IContainer"/> to get dependency directly.
    /// </summary>
    /// <param name="container"><see cref="IContainer"/></param>
    private static void Scenario01(IContainer container)
    {
        while (true)
        {
            var service = container.Resolve<IDomainService>();

            service.GetServiceName();
            
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    /// Use <see cref="ILifetimeScope"/> to resolve dependency. Let lifetimeScope outside the loop.
    /// </summary>
    /// <param name="container"><see cref="IContainer"/></param>
    private static void Scenario02(IContainer container)
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
    /// Concrete class directly do not use DI container.
    /// </summary>
    /// <param name="container"><see cref="IContainer"/></param>
    private static void Scenario03(IContainer container)
    {
        while (true)
        {
            var service = new DomainService(new DaemonResourceRepository());
            service.GetServiceName();
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    ///  Use <see cref="ILifetimeScope"/> to resolve dependency. Let lifetimeScope inside the loop.
    /// </summary>
    /// <param name="container"><see cref="IContainer"/></param>
    private static void Scenario04(IContainer container)
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
    /// Use <see cref="ILifetimeScope"/> outside the loop, use another scope inside the loop,
    /// then resolve the dependency via the chile scope.
    /// </summary>
    /// <param name="container"><see cref="IContainer"/></param>
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
using Autofac;
using AutofacExperiment.Access.Daemon;

namespace AutofacExperiment.Access.Modules;

public class DAModules : Module
{
    /// <summary>
    ///     Override to add registrations to the container.
    /// </summary>
    /// <param name="builder">
    ///     The builder through which components can be
    ///     registered.
    /// </param>
    /// <remarks>
    ///     Note that the ContainerBuilder parameter is unique to this module.
    ///     ref：http://autofac.readthedocs.io/en/latest/lifetime/instance-scope.html
    /// </remarks>
    protected override void Load(ContainerBuilder builder)
    {
        RegisterResourceRepository(builder: builder);
        RegisterDomainService(builder: builder);
    }

    private void RegisterResourceRepository(ContainerBuilder builder)
    {
        builder.RegisterType<DaemonResourceRepository>()
            .As<IDaemonResourceRepository>()
            .InstancePerDependency();

        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .OwnedByLifetimeScope();

        // 這個生命週期讓 MemoryLeakMethod02 不會有 memory leak 的問題
        // 因為在同一個scope下取得的實體，將會是同一個實體。(新的scope就是新的實體)
        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .InstancePerLifetimeScope();

        // ensure this app will get the same instance.
        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .SingleInstance();
    }
    
    private void RegisterDomainService(ContainerBuilder builder)
    {
        builder.RegisterType<DomainService>()
            .As<IDomainService>()
            .InstancePerDependency();
        
        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .OwnedByLifetimeScope();
        
        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .InstancePerLifetimeScope();

        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .SingleInstance();
    }
}
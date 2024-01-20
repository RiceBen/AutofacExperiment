using Autofac;
using AutofacExperiment.Access.Daemon;

namespace AutofacExperiment.Access.Modules;

public class DaModules : Module
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
        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .InstancePerDependency();

        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .OwnedByLifetimeScope();

        builder.RegisterType<DaemonResourceRepository>()
            .As<IDaemonResourceRepository>()
            .InstancePerLifetimeScope();

        // builder.RegisterType<DaemonResourceRepository>()
        //     .As<IDaemonResourceRepository>()
        //     .SingleInstance();
    }
    
    private void RegisterDomainService(ContainerBuilder builder)
    {
        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .InstancePerDependency();
        
        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .OwnedByLifetimeScope();
        
        builder.RegisterType<DomainService>()
            .As<IDomainService>()
            .InstancePerLifetimeScope();

        // builder.RegisterType<DomainService>()
        //     .As<IDomainService>()
        //     .SingleInstance();
    }
}
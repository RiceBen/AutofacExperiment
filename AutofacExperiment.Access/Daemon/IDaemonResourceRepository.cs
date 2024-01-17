using System;

namespace AutofacExperiment.Access.Daemon;

/// <summary>
///     Iinterface of deamon resource repository
/// </summary>
public interface IDaemonResourceRepository : IDisposable
{
    /// <summary>
    ///     Eat resource
    /// </summary>
    void ResourceMonster();
}
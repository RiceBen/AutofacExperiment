﻿using System;

namespace AutofacExperiment.Access.Daemon;

/// <summary>
/// Daemon resource repository.
/// </summary>
/// <seealso cref="IDaemonResourceRepository" />
/// <seealso cref="System.IDisposable" />
public class DaemonResourceRepository : IDaemonResourceRepository
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    private static string Name => typeof(DaemonResourceRepository).FullName;

    private readonly Guid _eid = Guid.NewGuid();

    /// <summary>
    /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
    /// </summary>
    public void Dispose()
    {
        Console.WriteLine($"{Name} dispose!");
    }

    public void ResourceMonster() => Console.WriteLine($"Object HashCode:{_eid}");
}
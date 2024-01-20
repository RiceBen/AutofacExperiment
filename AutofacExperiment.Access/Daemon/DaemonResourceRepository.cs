using System;

namespace AutofacExperiment.Access.Daemon;

/// <summary>
/// Daemon resource repository.
/// </summary>
/// <seealso cref="IDaemonResourceRepository" />
/// <seealso cref="System.IDisposable" />
public class DaemonResourceRepository : IDaemonResourceRepository
{
    private readonly Guid _eid = Guid.NewGuid();

    /// <summary>
    /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
    /// </summary>
    public void Dispose() => Console.WriteLine($"Resource {_eid} dispose!");

    public string ResourceMonster() => $"Resource:{_eid}";
}
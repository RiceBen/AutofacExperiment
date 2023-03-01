using System;

namespace AutofacExperiment.Access.Deamon;

/// <summary>
///     Deamon resource repository.
/// </summary>
/// <seealso cref="AutofacExperiment.Access.Deamon.IDeamonResourceRepository" />
/// <seealso cref="System.IDisposable" />
public class DeamonResourceRepository : IDeamonResourceRepository
{
    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>The name.</value>
    private static string Name => typeof(DeamonResourceRepository).FullName;

    /// <summary>
    ///     執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
    /// </summary>
    public void Dispose()
    {
        Console.WriteLine("{0} dispose!", Name);
    }

    /// <summary>
    ///     Eat resource
    /// </summary>
    public void ResourceMonster()
    {
        Console.WriteLine("Object HashCode:{0}", GetHashCode());
    }
}
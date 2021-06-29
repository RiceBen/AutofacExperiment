using System;

namespace AutofacExperiment.Access.Deamon
{
    /// <summary>
    /// Iinterface of deamon resource repository
    /// </summary>
    public interface IDeamonResourceRepository : IDisposable
    {
        /// <summary>
        /// Eat resource
        /// </summary>
        void ResourceMonster();
    }
}
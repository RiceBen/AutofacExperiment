using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineYi.ERP.DA.ERPDB.Deamon
{
    /// <summary>
    /// Iinterface of deamon resource repository
    /// </summary>
    public interface IDeamonResourceRepository: IDisposable
    {
        /// <summary>
        /// Eat resource
        /// </summary>
        void ResourceMonster();
    }
}

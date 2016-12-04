using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineYi.ERP.DA.ERPDB.Deamon
{
    /// <summary>
    /// Deamon resource repository.
    /// </summary>
    /// <seealso cref="NineYi.ERP.DA.ERPDB.Deamon.IDeamonResourceRepository" />
    /// <seealso cref="System.IDisposable" />
    public class DeamonResourceRepository : IDeamonResourceRepository
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get { return typeof(DeamonResourceRepository).FullName; } }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine(string.Format("{0} dispose!", this.Name));
        }

        /// <summary>
        /// Eat resource
        /// </summary>
        public void ResourceMonster()
        {
            Console.WriteLine(string.Format("Object HashCode:{0}",this.GetHashCode()));
        }
    }
}

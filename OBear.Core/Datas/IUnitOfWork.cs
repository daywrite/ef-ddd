using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBear.Datas
{
    /// <summary>
    /// 业务单元操作接口
    /// </summary>
    public interface IUnitOfWork : IDependency
    {
        /// <summary>
        /// 启动
        /// </summary>
        void Start();
        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}

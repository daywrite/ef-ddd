using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Reflection;

namespace OBear.Datas.Ef
{
    /// <summary>
    /// Entity Framework工作单元
    /// </summary>
    public abstract class EfUnitOfWork : DbContext
    {
        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="connectionName">连接字符串的名称</param>
        protected EfUnitOfWork(string connectionName)
            : base(connectionName)
        {
            
        }
       
        /// <summary>
        /// 添加映射配置
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (IEntityMapper mapper in GetEntityMappers())
                mapper.RegistTo(modelBuilder.Configurations);
        }

        /// <summary>
        /// 获取映射配置
        /// </summary>
        private IEnumerable<IEntityMapper> GetEntityMappers()
        {
            var result = new List<IEntityMapper>();
            foreach (var assembly in GetAssemblies())
                result.AddRange(Reflection.GetByInterface<IEntityMapper>(assembly));
            return result;
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected virtual Assembly[] GetAssemblies()
        {
            return new[] { GetType().Assembly };
        }
    }
}

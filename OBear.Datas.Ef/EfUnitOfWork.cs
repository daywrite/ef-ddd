using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace OBear.Datas.Ef
{
    /// <summary>
    /// Entity Framework工作单元
    /// </summary>
    public abstract class EfUnitOfWork : DbContext, IUnitOfWork
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

        /// <summary>
        /// 启动标识
        /// </summary>
        private bool IsStart { get; set; }

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; private set; }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            IsStart = true;
        }

        /// <summary>
        /// 提交更新
        /// </summary>
        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //throw new ConcurrencyException(ex);
            }
            catch (DbEntityValidationException ex)
            {
                var s = ex.EntityValidationErrors;
                //throw new EfValidationException(ex);
            }
            finally
            {
                IsStart = false;
            }
        }

        /// <summary>
        /// 通过启动标识执行提交，如果已启动，则不提交
        /// </summary>
        internal void CommitByStart()
        {
            if (IsStart)
                return;
            Commit();
        }

    }
}

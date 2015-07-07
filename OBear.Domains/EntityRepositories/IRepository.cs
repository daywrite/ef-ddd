using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Datas;

namespace OBear.Domains.EntityRepositories
{
    /// <summary>
    /// 实体仓储模型的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRepository<TEntity, in TKey> : IDependency where TEntity : class, IAggregateRoot<TKey> 
    {
        #region 属性

        /// <summary>
        /// 获取 当前单元操作对象
        /// </summary>
        IUnitOfWork GetUnitOfWork();

        /// <summary>
        /// 获取 当前实体类型的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add(TEntity entity);
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entities">实体</param>
        void Add(IEnumerable<TEntity> entities);

        #endregion
    }
}

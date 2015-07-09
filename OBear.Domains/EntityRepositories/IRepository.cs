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
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add(TEntity entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entities">实体</param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// 查找实体集合
        /// </summary>
        List<TEntity> FindAll();
       
        /// <summary>
        /// 查找实体集合
        /// </summary>
        IQueryable<TEntity> Find();

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        TEntity Find(params object[] id);

        #endregion
    }
}

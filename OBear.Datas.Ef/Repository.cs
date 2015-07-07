using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Domains;
using OBear.Domains.EntityRepositories;

namespace OBear.Datas.Ef
{
    /// <summary>
    /// EntityFramework的仓储实现
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IAggregateRoot<TKey> 
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (EfUnitOfWork)unitOfWork;
        }

        /// <summary>
        /// Ef工作单元
        /// </summary>
        protected EfUnitOfWork UnitOfWork { get; private set; }

        //private readonly DbSet<TEntity> _dbSet;
        //private readonly IUnitOfWork _unitOfWork;

        //public Repository(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //    _dbSet = ((DbContext)unitOfWork).Set<TEntity>();
        //}

        /// <summary>
        /// 获取 当前单元操作对象
        /// </summary>
        //public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }

        /// <summary>
        /// 获取 当前实体类型的查询数据集
        /// </summary>
        public IQueryable<TEntity> Entities { get { return UnitOfWork.Set<TEntity>(); } }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.CommitByStart();
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entities">实体</param>
        public void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return;
            UnitOfWork.Set<TEntity>().AddRange(entities);
            UnitOfWork.CommitByStart();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            UnitOfWork.Commit();
        }

         /// <summary>
        /// 获取工作单元
        /// </summary>
        public IUnitOfWork GetUnitOfWork() {
            return UnitOfWork;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Domains;
using OBear.ApplicationServices;
using OBear.Datas;
using OBear.Domains;

namespace Applications.Services
{
    /// <summary>
    /// 批操作服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public abstract class BatchServiceBase<TEntity, TDto, TQuery> : BatchService<TEntity, TDto, TQuery, Guid>
        where TEntity : class, IAggregateRoot<Guid>, new()
        where TDto : IDto, new()
        //where TQuery : IPager
    {
        /// <summary>
        /// 初始化批操作服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected BatchServiceBase(IUnitOfWork unitOfWork, IRepositoryBase<TEntity> repository)
            : base(unitOfWork, repository)
        {
        }
    }
}

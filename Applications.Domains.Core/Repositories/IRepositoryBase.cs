using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Domains;
using OBear.Domains.EntityRepositories;

namespace Applications.Domains
{
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepositoryBase<TEntity> : IRepository<TEntity, Guid> where TEntity : class, IAggregateRoot<Guid> 
    {
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Datas.Ef;
using OBear.Domains;

namespace Applications.Datas.Ef.Repositories
{
    /// <summary>
    /// 基仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class RepositoryBase<TEntity> : Repository<TEntity, Guid> where TEntity : EntityBase<Guid>
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBear.Datas.Ef;
using OBear.Domains;

namespace Applications.Datas.Ef.Mappings
{
    /// <summary>
    /// 聚合根映射
    /// </summary>
    /// <typeparam name="TEntity">聚合根类型</typeparam>
    public abstract class AggregateMapBase<TEntity> : AggregateMapBase<TEntity, Guid> where TEntity : AggregateRoot<Guid>
    {
    }
}

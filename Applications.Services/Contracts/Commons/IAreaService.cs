using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Domains.Commons.Models;
using OBear;

namespace Applications.Services.Contracts.Commons
{
    public interface IAreaService : IDependency
    {
        /// <summary>
        /// 获取查询数据集
        /// </summary>
        IQueryable<Area> Areas { get; }
    }
}

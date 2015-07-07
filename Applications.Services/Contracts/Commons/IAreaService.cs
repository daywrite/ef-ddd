using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Queries;
using Applications.Services.Dtos.Commons;
using OBear;
using OBear.ApplicationServices;

namespace Applications.Services.Contracts.Commons
{
    public interface IAreaService : IBatchService<AreaDto, AreaQuery>, IDependency
    {
        /// <summary>
        /// 获取查询数据集
        /// </summary>
        IQueryable<Area> Areas { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Domains;
using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Queries;
using Applications.Domains.Commons.Repositories;
using Applications.Services.Contracts.Commons;
using Applications.Services.Dtos.Commons;

namespace Applications.Services.Impl.Commons
{
    /// <summary>
    /// 地区服务
    /// </summary>
    public class AreaService : BatchServiceBase<Area, AreaDto, AreaQuery>, IAreaService
    {
        private readonly IRepositoryBase<Area> _areaRepository;

        #region 构造方法

        /// <summary>
        /// 初始化地区服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">地区仓储</param>
        public AreaService(IApplicationUnitOfWork unitOfWork, IAreaRepository repository)
           : base( unitOfWork, repository ) 
        {
            _areaRepository = repository;
        }

        /// <summary>
        /// 获取 
        /// </summary>
        public IQueryable<Area> Areas
        {
            get { return _areaRepository.Entities; }
        }
        #endregion
    }
}

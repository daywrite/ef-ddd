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
    public class AreaService : TreeBatchService<Area, AreaDto, AreaQuery>, IAreaService
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

        #endregion

        #region 实体与Dto转换

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override AreaDto ToDto(Area entity)
        {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Area ToEntity(AreaDto dto)
        {
            return dto.ToEntity();
        }

        #endregion
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Applications.Domains.Commons.Queries;
using Applications.Services.Contracts.Commons;
using Applications.Services.Dtos.Commons;
using Presentation.Base;

namespace Presentation.Areas.Areas.Controllers
{
    public class AreaController : GridControllerBase<AreaDto, AreaQuery>
    {
        /// <summary>
        /// 初始化地区控制器
        /// </summary>
        /// <param name="service">地区服务</param>
        public AreaController(IAreaService service)
            : base(service)
        {
            Service = service;
        }

        /// <summary>
        /// 地区服务
        /// </summary>
        protected IAreaService Service { get; private set; }

        public ActionResult Index()
        {
            //Service.Save();
            return View();
        }

    }
}

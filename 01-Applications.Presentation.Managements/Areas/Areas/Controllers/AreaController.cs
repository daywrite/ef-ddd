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
        protected new IAreaService Service { get; private set; }

        public ActionResult Index()
        {
            var addList = "[{\"ParentId\":\"e5f351a9-6bc1-4675-82b3-7038b3996ecd\",\"Cod,nulle\":null,\"Text\":\"123\",\"Path\":\"\",\"Level\":0,\"SortId\":37,\"PinYin\":\"123\",\"FullPinYin\":\"123\",\"Enabled\":true,\"CreateTime\":\"2015-07-07T11:54:30.6476865+08:00\",\"Version\":null,\"Id\":\"e5f351a9-6bc1-4675-82b3-7038b3996ecd\"}]";
            var listAdd = OBear.Json.ToObject<List<AreaDto>>(addList);
            var listUpdate = OBear.Json.ToObject<List<AreaDto>>("[]");
            var listDelete = OBear.Json.ToObject<List<AreaDto>>("[]");
            Service.Save(listAdd, listUpdate, listDelete);
            return View();
        }

    }
}

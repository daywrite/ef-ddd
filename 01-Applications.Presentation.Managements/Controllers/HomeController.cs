using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Applications.Domains.Commons.Models;
using Applications.Services;
using Applications.Services.Contracts.Commons;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAreaService _areaService;
        public HomeController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        public ActionResult Index()
        {
            //List<Area> number = _areaService.Areas.ToList();

            return View();
        }
    }    
}

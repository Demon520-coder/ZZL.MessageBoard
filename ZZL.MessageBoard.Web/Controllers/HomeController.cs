using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.MessageBoard.Service.IService;
using PagedList.Mvc;
using PagedList;
using ZZL.MessageBoard.Web.Filter;
using ZZL.MessageBoard.Entity;

namespace ZZL.MessageBoard.Web.Controllers
{
    [NotLoginFilter]
    public class HomeController : Controller
    {
        readonly IMessageService _mesageService;

        public HomeController(IMessageService messageService)
        {
            _mesageService = messageService;
        }

        public ActionResult Index(int? pageIndex)
        {
            pageIndex = (pageIndex == null || pageIndex < 0) ? 1 : pageIndex;
            var pageResult = _mesageService.GetMessageEntities(new { PageIndex = pageIndex, PageSize = 20 }).ToPagedList(pageIndex.Value, 20);
            return View(pageResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
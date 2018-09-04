using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Security;
using ZZL.Common;
using ZZL.MessageBoard.Entity;
using ZZL.MessageBoard.Service.IService;
using ZZL.MessageBoard.Service.Service;
using ZZL.MessageBoard.Web.Cusomer;

namespace ZZL.MessageBoard.Web.Filter
{
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userCookie = filterContext.HttpContext.Request.Cookies["user"];
            var user = UserTicketHelper.GetUserFromCookie(userCookie);
            if (user != null)
            {
                filterContext.Controller.ViewData["userInfo"] = user;
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}
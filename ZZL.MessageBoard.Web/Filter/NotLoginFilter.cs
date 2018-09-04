using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZZL.Common;
using ZZL.MessageBoard.Entity;
using ZZL.MessageBoard.Service.IService;
using ZZL.MessageBoard.Service.Service;
using ZZL.MessageBoard.Web.Cusomer;

namespace ZZL.MessageBoard.Web.Filter
{
    public class NotLoginFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var user = UserTicketHelper.GetUserFromCookie(filterContext.HttpContext.Request.Cookies["user"]);
            if (user != null)
            {
                filterContext.Controller.ViewData["userInfo"] = user;
            }

            base.OnResultExecuting(filterContext);
        }
    }
}
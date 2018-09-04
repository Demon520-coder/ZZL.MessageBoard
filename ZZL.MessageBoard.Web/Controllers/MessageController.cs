using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZZL.MessageBoard.Entity;
using ZZL.MessageBoard.Service.IService;
using ZZL.MessageBoard.Web.Filter;
using ZZL.MessageBoard.Web.Models;

namespace ZZL.MessageBoard.Web.Controllers
{
    [LoginFilter]
    public class MessageController : Controller
    {
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: Message
        public ActionResult LeaveMessage(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveMessage(MessageViewModel message)
        {
            if (ModelState.IsValid)
            {
                var user = ViewData["userInfo"] as CurrentUser;
                if (user != null)
                {
                    MessageEntity msgEntity = new MessageEntity
                    {
                        Title = message.Title,
                        Body = message.Body,
                        CreateDate = DateTime.Now,
                        Status = 1,
                        UserId = user.UserId,
                        UserName = user.UserName
                    };

                    _messageService.Save(msgEntity, "Save");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }             
            }

            return View(message);
        }
    }
}
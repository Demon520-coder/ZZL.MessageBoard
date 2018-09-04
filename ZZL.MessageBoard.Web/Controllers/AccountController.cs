using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZZL.Common;
using ZZL.MessageBoard.Service.IService;
using static ZZL.MessageBoard.Web.Models.AccountViewModel;

namespace ZZL.MessageBoard.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel userModel, string returnUrl)
        {
            //var url = System.Web.HttpUtility.UrlDecode(returnUrl);

            //if (!Url.IsLocalUrl(url))
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            var code = TempData["code"]?.ToString();

            if (code.IsNullOrEmpty())
            {
                ModelState.AddModelError("ValidateCode", "验证码超时");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var userInfo = _userService.Login(userModel.UserName, userModel.PassWord.ToMD5());
                    if (userInfo != null)
                    {
                        //更难登陆时间
                        userInfo.LastLoginTime = DateTime.Now;
                        _userService.Update(userInfo);
                        //写入cookie;
                      
                        var userTicket = new FormsAuthenticationTicket(1, "ticket", DateTime.Now, DateTime.Now.AddDays(3), false, userInfo.Id + "," + userInfo.UserName);

                        //FormsAuthentication.SetAuthCookie("", false, "");
                        HttpCookie cookie = new HttpCookie("user", Convert.ToBase64String(Encoding.UTF8.GetBytes(FormsAuthentication.Encrypt(userTicket))));
                        cookie.HttpOnly = true;
                        cookie.Expires = DateTime.Now.AddDays(3);  
                        Response.Cookies.Add(cookie);
                     

                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(LoginViewModel.UserName), "用户名或密码错误");
                    }

                }
            }

            return View(userModel);
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            Common.ValidateCode validate = new Common.ValidateCode();
            var code = validate.CreateValidateCode(4);
            TempData["code"] = code;
            return File(validate.CreateValidateGraphic(code), "image/jpg");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                //01.注册用户
                if (_userService.IsExistsUserName(registerModel.UserName))
                {
                    ModelState.AddModelError(nameof(registerModel.UserName), "用户名已经存在");

                    return View(registerModel);
                }

                if (_userService.IsExistsEmail(registerModel.Email))
                {
                    ModelState.AddModelError(nameof(registerModel.Email), "邮箱已经存在");

                    return View(registerModel);
                }

                var result = _userService.Register(new Entity.UserEntity
                {
                    UserName = registerModel.UserName?.Trim(),
                    Pwd = registerModel.PassWord.ToMD5(),
                    Email = registerModel.Email,
                    Status = 1,
                    CreateDate = DateTime.Now
                });

                if (result)
                {
                    return RedirectToAction(nameof(Login), "Account");
                }

                ModelState.AddModelError("error", "注册失败");
            }

            return View(registerModel);
        }
    }
}
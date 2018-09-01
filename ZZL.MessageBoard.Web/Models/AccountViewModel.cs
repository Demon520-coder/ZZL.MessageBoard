using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZZL.MessageBoard.Web.Models
{
    public class AccountViewModel
    {
        public class LoginViewModel
        {

            [Display(Name = "用户名")]
            [Required(ErrorMessage = "用户名不能为空")]
            public string UserName { get; set; }

            [Display(Name = "密码")]
            [Required(ErrorMessage = "密码不能为空")]
            public string PassWord { get; set; }

            [Display(Name = "验证码")]
            [Required(ErrorMessage = "验证码不能为空")]
            public string ValidateCode { get; set; }
        }

        public class RegisterViewModel
        {
            [Display(Name = "用户名")]
            [Required(ErrorMessage = "用户名不能为空")]
            public string UserName { get; set; }

            [Display(Name = "密码")]
            [Required(ErrorMessage = "密码不能为空")]
            public string PassWord { get; set; }

            [Display(Name = "确认密码")]
            [Required(ErrorMessage = "确认密码不能为空")]
            [Compare("PassWord", ErrorMessage = "两次密码输入不一致")]
            public string ConfirmPassWord { get; set; }

           
            [Display(Name = "邮箱")]
            [Required(ErrorMessage = "邮箱不能为空")]
            [EmailAddress(ErrorMessage = "邮箱格式错误")]
            public string Email { get; set; }
        }





    }
}
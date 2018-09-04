using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using ZZL.Common;
using ZZL.MessageBoard.Entity;
using ZZL.MessageBoard.Service.IService;
using ZZL.MessageBoard.Service.Service;
using ZZL.MessageBoard.Web.Models;

namespace ZZL.MessageBoard.Web.Cusomer
{
    /// <summary>
    /// 用户信息获取
    /// </summary>
    public class UserTicketHelper
    {
        public static CurrentUser GetUserFromCookie(HttpCookie userCookie)
        {
            if (userCookie != null && !userCookie.Value.IsNullOrEmpty())
            {
                var userInfo = FormsAuthentication.Decrypt(Encoding.UTF8.GetString(Convert.FromBase64String(userCookie.Value)));
                //02.获得用户的Id;
                var userInfoArray = StringHelper.SplitMulti(userInfo.UserData, ",");
                //03.获取用户信息
                IUserService userService = new UserService();
                UserEntity userEntity = userService.Find(userInfoArray[0].TryToInt());
                if (userEntity != null)
                {
                    //04.判断用户名是否一致
                    if (userEntity.UserName == userInfoArray[1])
                    {
                        return new CurrentUser
                        {
                            UserName = userEntity.UserName,
                            UserId = userEntity.Id
                        };
                    }
                }
            }

            return null;

        }
    }
}
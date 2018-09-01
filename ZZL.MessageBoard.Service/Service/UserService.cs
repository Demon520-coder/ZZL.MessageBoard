using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.DataAccess;
using ZZL.MessageBoard.Entity;
using ZZL.MessageBoard.Service.IService;

namespace ZZL.MessageBoard.Service.Service
{
    public class UserService : BaseDao<UserEntity, int>, IUserService
    {
        public bool IsExistsEmail(string email)
        {
            return IsExists(new { Email = email }, "IsExsistsEmail");
        }

        public bool IsExistsUserName(string userName)
        {
            return IsExists(new { UserName = userName }, "IsExsistsUserName");
        }

        public UserEntity Login(string userName, string pwd)
        {
            UserEntity user = new UserEntity
            {
                UserName = userName,
                Pwd = pwd
            };

            user = GetList(user, "Login").FirstOrDefault();

            return user;
        }

        public bool Register(UserEntity entity)
        {
            return Save(entity, "Save");
        }
    }
}

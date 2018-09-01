using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.DataAccess;
using ZZL.MessageBoard.Entity;

namespace ZZL.MessageBoard.Service.IService
{
    public interface IUserService : IBaseDao<UserEntity, int>
    {
        UserEntity Login(string userName, string pwd);

        bool Register(UserEntity entity);

        bool IsExistsUserName(string userName);

        bool IsExistsEmail(string email);
    }
}

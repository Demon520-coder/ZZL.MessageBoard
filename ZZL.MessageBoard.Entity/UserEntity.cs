using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.Common;
using ZZL.DataAccess;

namespace ZZL.MessageBoard.Entity
{
    [Scope(Name = "TB_USER")]
    public class UserEntity : EntityBase<int>
    {
        public string UserName { get; set; }

        public string Pwd { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string Email { get; set; }
    }
}

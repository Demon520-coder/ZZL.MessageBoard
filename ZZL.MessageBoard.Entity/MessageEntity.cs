using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.Common;
using ZZL.DataAccess;

namespace ZZL.MessageBoard.Entity
{


    [Scope(Name = "TB_MESSAGE")]
    /// <summary>
    /// 消息实体
    /// </summary>
    public class MessageEntity : EntityBase<int>
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
       
    }
}

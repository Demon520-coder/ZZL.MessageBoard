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
    public class MessageService : BaseDao<MessageEntity, int>, IMessageService
    {
        public IEnumerable<MessageEntity> GetMessageEntities(object param)
        {
            return GetList(param);
        }
    }
}

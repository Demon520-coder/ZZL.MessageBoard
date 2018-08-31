using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.DataAccess;
using ZZL.MessageBoard.Entity;

namespace ZZL.MessageBoard.Service.IService
{
    public interface ICustomerService : IBaseDao<CustomerEntity, int>
    {
    }
}

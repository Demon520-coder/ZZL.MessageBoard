using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZL.Common;
using ZZL.DataAccess;

namespace ZZL.MessageBoard.Entity
{
    [Scope(Name = "TB_Customers")]
    public class CustomerEntity : EntityBase<int>
    {
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }
}

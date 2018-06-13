using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class Bill
    {

        public long BillID { get; set; }

        public String Name { get; set; }

        public String DeliveryAddress { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public String DeliveryStatus { get; set; }

        public bool? Paid { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}

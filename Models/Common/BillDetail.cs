using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class BillDetail
    {
        public long BillID { get; set; }

        public String BookName { get; set; }

        public String CoverPhoto { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}

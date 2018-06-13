using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class StatisticSaleBook
    {
        public String BookName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}

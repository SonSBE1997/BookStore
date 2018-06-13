using Models.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class StatisticDAO
    {
        BookStoreDbContext db;

        public StatisticDAO()
        {
            db = new BookStoreDbContext();
        }

        public decimal getTotalPriceBillByMonth(int month, int year)
        {
            var price = from t2 in db.OrderDetails
                        group t2 by t2.OrderID into gb
                        join t1 in db.Orders
                        on gb.Key equals t1.ID
                        where t1.OrderDate.Value.Month == month && t1.OrderDate.Value.Year == year
                        select new {
                            t1.ID,
                            t1.DeliveryAddress,
                            t1.OrderDate,
                            t1.DeliveryDate,
                            t1.DeliveryStatus,
                            t1.Paid,
                            total = gb.Sum(_ => (_.Price * _.Quantity))
                        };

            return price.Sum(_ => _.total) == null ? 0 : (decimal)price.Sum(_ => _.total);
        }

        //Doanh thu hàng tháng theo năm
        public List<decimal> statisticGroupByMonth(int year)
        {
            return new List<decimal>()
            {
                getTotalPriceBillByMonth(1,year),
                getTotalPriceBillByMonth(2,year),
                getTotalPriceBillByMonth(3,year),
                getTotalPriceBillByMonth(4,year),
                getTotalPriceBillByMonth(5,year),
                getTotalPriceBillByMonth(6,year),
                getTotalPriceBillByMonth(7,year),
                getTotalPriceBillByMonth(8,year),
                getTotalPriceBillByMonth(9,year),
                getTotalPriceBillByMonth(10,year),
                getTotalPriceBillByMonth(11,year),
                getTotalPriceBillByMonth(12,year)
            };
        }

        //Doanh thu theo năm
        public decimal getTotalPriceBillByYear(int year)
        {
            var price = from t2 in db.OrderDetails
                        group t2 by t2.OrderID into gb
                        join t1 in db.Orders
                        on gb.Key equals t1.ID
                        where t1.OrderDate.Value.Year == year
                        select new {
                            t1.ID,
                            t1.DeliveryAddress,
                            t1.OrderDate,
                            t1.DeliveryDate,
                            t1.DeliveryStatus,
                            t1.Paid,
                            total = gb.Sum(_ => (_.Price * _.Quantity))
                        };

            return price.Sum(_ => _.total) == null ? 0 : (decimal)price.Sum(_ => _.total);
        }


        public List<StatisticSaleBook> getPriceGroupByBook(int month, int year)
        {
            return (from t1 in db.Orders
                    join t2 in db.OrderDetails
                    on t1.ID equals t2.OrderID
                    where t1.OrderDate.Value.Month == month && t1.OrderDate.Value.Year == year
                    group t2 by t2.BookID into gb
                    join t3 in db.Books
                    on gb.Key equals t3.ID
                    select new StatisticSaleBook
                    {
                        BookName = t3.Name,
                        Price = t3.Price,
                        Quantity = gb.Sum(_ => _.Quantity),
                        TotalPrice = gb.Sum(_ => (_.Price * _.Quantity))
                    }).ToList();
        }

    }
}

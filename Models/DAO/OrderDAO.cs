using Models.Common;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDAO
    {
        BookStoreDbContext db;


        public OrderDAO()
        {
            db = new BookStoreDbContext();
        }

        public List<BillDetail> getOrderDetailByOrderID(long id)
        {
            var model = from t1 in db.OrderDetails
                        join t2 in db.Books
                        on t1.BookID equals t2.ID
                        where t1.OrderID == id
                        select new BillDetail()
                        {
                            BillID = id,
                            BookName = t2.Name,
                            CoverPhoto = t2.CoverPhoto,
                            Quantity = t1.Quantity,
                            Price = t1.Price,
                            TotalPrice = t1.Quantity * t1.Price
                        };
            return model.ToList();

        }


        public IEnumerable<Bill> GetListBillPaging(string searchString, int page, int pageSize)
        {
            var model = from t1 in db.OrderDetails
                        group t1 by t1.OrderID into gb
                        join t2 in db.Orders
                        on gb.Key equals t2.ID

                        join t3 in db.Users
                        on (long)t2.UserID equals t3.ID
                        select new Bill()
                        {
                            BillID = t2.ID,
                            Name = t3.Name,
                            DeliveryAddress = t2.DeliveryAddress,
                            DeliveryDate = t2.DeliveryDate,
                            DeliveryStatus = t2.DeliveryStatus,
                            OrderDate = t2.OrderDate,
                            Paid = t2.Paid,
                            TotalPrice = gb.Sum(_ => (_.Price * _.Quantity))
                        };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Name.Contains(searchString));
            }
            return model.OrderBy(_ => _.OrderDate).ToPagedList(page, pageSize);
        }

        public Bill GetBillByOrderID(long id)
        {
            var model = from t1 in db.OrderDetails
                        group t1 by t1.OrderID into gb
                        join t2 in db.Orders
                        on gb.Key equals t2.ID

                        join t3 in db.Users
                        on (long)t2.UserID equals t3.ID
                        select new Bill()
                        {
                            BillID = t2.ID,
                            Name = t3.Name,
                            DeliveryAddress = t2.DeliveryAddress,
                            DeliveryDate = t2.DeliveryDate,
                            DeliveryStatus = t2.DeliveryStatus,
                            OrderDate = t2.OrderDate,
                            Paid = t2.Paid,
                            TotalPrice = gb.Sum(_ => (_.Price * _.Quantity))
                        };
            return model.SingleOrDefault(_ => _.BillID == id);
        }

        public bool ChangePayment(long id)
        {
            Order order = db.Orders.Find(id);
            order.Paid = !order.Paid;
            db.SaveChanges();
            return (bool)order.Paid;
        }

        public String ChangeDeliveryStatus(long id)
        {
            Order order = db.Orders.Find(id);
            order.DeliveryStatus = order.DeliveryStatus == "Chưa giao hàng" ? "Đã giao hàng" : "Chưa giao hàng";
            db.SaveChanges();
            return order.DeliveryStatus;
        }

        public bool Insert(Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public Order getOrderByUserIDandOrderDate(DateTime orderDate, long userId)
        {
            return db.Orders.SingleOrDefault(_ => _.UserID == userId && _.OrderDate == orderDate);
        }

        public long getLastID()
        {
            List<Order> ls = db.Orders.ToList();
            if (ls.Count == 0) return 0;
            return ls.ElementAt(ls.Count - 1).ID;
        }
    }
}

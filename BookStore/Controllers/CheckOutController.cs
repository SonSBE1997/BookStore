using BookStore.Models;
using Models.Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            var cart = Session[Constant.CART_ITEM];
            List<CartItem> list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            if (Session[Constant.CLIENT_SESSION] != null)
            {
                ViewBag.ClientName = ((UserLogin)Session[Constant.CLIENT_SESSION]).Name;
            }
            else ViewBag.ClientName = "";
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string txtName, string txtEmail, string txtAddress, string txtPhoneNumber)
        {
            var sessionCart = Session[Constant.CART_ITEM];
            if (sessionCart == null || ((List<CartItem>)sessionCart).Count == 0)
            {
                TempData["AlertMessage"] = "Chưa có sản phẩm trong giỏ hàng!";
                TempData["AlertType"] = "alert-warning";
                return RedirectToAction("Index");
            }
            var sessionClient = Session[Constant.CLIENT_SESSION];
            if (sessionClient == null)
            {
                TempData["AlertMessage"] = "Bạn phải đăng nhập trước!";
                TempData["AlertType"] = "alert-warning";
                return RedirectToAction("Index");
            }

            OrderDAO orderDAO = new OrderDAO();
            long userID = ((UserLogin)sessionClient).UserID;
            DateTime now = DateTime.Now;
            long orderID = orderDAO.getLastID() + 1;
            orderDAO.Insert(new Order()
            {
                ID = orderID,
                UserID = userID,
                Paid = false,
                OrderDate = now,
                DeliveryStatus = "Chưa giao hàng",
                DeliveryDate = now.AddDays(10),
                DeliveryAddress = txtAddress
            });


            List<CartItem> ls = (List<CartItem>)sessionCart;
            OrderDetailDAO dao = new OrderDetailDAO();
            BookDAO bookDAO = new BookDAO();
            foreach (var item in ls)
            {
                dao.Insert(new OrderDetail()
                {
                    BookID = item.BookPur.ID,
                    OrderID = orderID,
                    Price = item.BookPur.Price,
                    Quantity = item.Quantity
                });
                bookDAO.SaleBook(item.BookPur.ID, item.Quantity);
            }

            TempData["AlertMessage"] = "Đặt hàng thành công";
            TempData["AlertType"] = "alert-success";
            Session[Constant.CART_ITEM] = new List<CartItem>();
            return RedirectToAction("Index");
        }
    }
}
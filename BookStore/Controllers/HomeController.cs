using BookStore.Models;
using Models.Common;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BookDAO dao = new BookDAO();
            ViewBag.New = dao.getListNewBook();
            ViewBag.Hot = dao.getListHotBook();
            ViewBag.Normal = dao.getListBookNormal();
            return View();
        }

        public ActionResult AddItem(long bookId, int quantity)
        {
            var book = new BookDAO().getBookByID(bookId);
            var cart = Session[Constant.CART_ITEM];
            if (cart != null)
            {
                bool hasItem = false;
                List<CartItem> list = (List<CartItem>)Session[Constant.CART_ITEM];
                foreach (var item in list)
                {
                    if (bookId == item.BookPur.ID)
                    {
                        item.Quantity += quantity;
                        hasItem = true;
                        break;
                    }
                }

                if (!hasItem) list.Add(new CartItem()
                {
                    BookPur = book,
                    Quantity = quantity
                });

                Session[Constant.CART_ITEM] = list;
            }
            else
            {
                var item = new CartItem();
                item.BookPur = book;
                item.Quantity = quantity;
                List<CartItem> list = new List<CartItem>();
                list.Add(item);
                Session[Constant.CART_ITEM] = list;
            }

            return RedirectToAction("Index");
        }


        [ChildActionOnly]
        public PartialViewResult AccountName()
        {
            if (Session[Constant.CLIENT_SESSION] == null)
            {
                ViewBag.Name = "Đăng nhập";
            }
            else
            {
                ViewBag.Name = "Xin chào:" + ((UserLogin)Session[Constant.CLIENT_SESSION]).UserName;
            }
            return PartialView();
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public PartialViewResult CategoryList()
        {
            var model = new CategoryDAO().getListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public PartialViewResult Slide()
        {
            var model = new SlideDAO().getListSlide();
            return PartialView(model);
        }


        [ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public PartialViewResult CartHeader()
        {
            var cart = Session[Constant.CART_ITEM];
            List<CartItem> list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}
using BookStore.Models;
using Models.Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Constant.CART_ITEM];
            List<CartItem> list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
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


        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessoinCart = (List<CartItem>)Session[Constant.CART_ITEM];

            if (sessoinCart != null)
            {
                foreach (var item in sessoinCart)
                {
                    var jsonItem = jsonCart.SingleOrDefault(_ => _.BookPur.ID == item.BookPur.ID);
                    if (jsonItem != null)
                    {
                        item.Quantity = jsonItem.Quantity;
                    }
                }
            }
            Session[Constant.CART_ITEM] = sessoinCart;
            return Json(new {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[Constant.CART_ITEM] = null;
            return Json(new { status = true });
        }


        public JsonResult Delete(long id)
        {
            var sessoinCart = (List<CartItem>)Session[Constant.CART_ITEM];
            sessoinCart.RemoveAll(_ => _.BookPur.ID == id);
            Session[Constant.CART_ITEM] = sessoinCart;
            return Json(new {
                status = true
            });
        }
    }
}
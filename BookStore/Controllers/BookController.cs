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
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(String searchString = "", int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            BookDAO dao = new BookDAO();
            var model = dao.GetListBookPagingSortByPrice(searchString, ref totalRecord, page, pageSize);
            ViewBag.PreviousPage = page - 1;
            ViewBag.CurrentPage = page;
            ViewBag.NextPage = page + 1;
            ViewBag.LastPage = Math.Ceiling((double)totalRecord / pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }


        public ActionResult Hot(int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            BookDAO dao = new BookDAO();
            var model = dao.GetListBookHotPagingSortByPrice(ref totalRecord, page, pageSize);
            ViewBag.PreviousPage = page - 1;
            ViewBag.CurrentPage = page;
            ViewBag.NextPage = page + 1;
            ViewBag.LastPage = Math.Ceiling((double)totalRecord / pageSize);
            return View(model);
        }


        public ActionResult New(int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            BookDAO dao = new BookDAO();
            var model = dao.GetListBookNewPagingSortByPrice(ref totalRecord, page, pageSize);
            ViewBag.PreviousPage = page - 1;
            ViewBag.CurrentPage = page;
            ViewBag.NextPage = page + 1;
            ViewBag.LastPage = Math.Ceiling((double)totalRecord / pageSize);
            return View(model);
        }

        public ActionResult Category(long category, int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            ViewBag.Category = new CategoryDAO().getBookCategoryByID(category);
            BookDAO dao = new BookDAO();

            ViewBag.TreeCategory = dao.getTreeCategoryByIDChild(category);
            var model = dao.getListBookByCategoryID(category, ref totalRecord, page, pageSize);
            ViewBag.PreviousPage = page - 1;
            ViewBag.CurrentPage = page;
            ViewBag.NextPage = page + 1;
            ViewBag.LastPage = Math.Ceiling((double)totalRecord / pageSize);
            return View(model);
        }


        public ActionResult BookDetail(long bookId)
        {
            BookDAO dao = new BookDAO();
            Book book = dao.getBookByID(bookId);

            long category = (long)book.BookCategory;
            ViewBag.Category = new CategoryDAO().getBookCategoryByID(category);
            ViewBag.TreeCategory = dao.getTreeCategoryByIDChild(category);

            ViewBag.SimilarProduct = dao.getListSimilarProduct(category, 4);
            ViewBag.SameAuthor = dao.getListSameAuthor((long)book.BookAuthor, 4) == null ? new List<Book>() : dao.getListSameAuthor((long)book.BookAuthor, 4);

            return View(book);
        }

        public ActionResult AddItem(long bookId, int quantity, String searchString)
        {
            addNewItem(bookId, quantity);
            return Redirect("/Book/Index?searchString=" + searchString);
        }

        public ActionResult AddItem4(long bookId, int quantity)
        {
            addNewItem(bookId, quantity);
            return RedirectToAction("Hot");
        }

        public ActionResult AddItem1(long bookId, int quantity)
        {
            addNewItem(bookId, quantity);
            return RedirectToAction("New");
        }


        public ActionResult AddItem2(long bookId, int quantity, long category)
        {
            addNewItem(bookId, quantity);

            return Redirect("/Book/Category?category=" + category);
        }

        public ActionResult AddItem3(long bookId, int quantity)
        {
            addNewItem(bookId, quantity);
            return Redirect("/Book/Category?bookId=" + bookId);
        }



        void addNewItem(long bookId, int quantity)
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
        }
    }
}
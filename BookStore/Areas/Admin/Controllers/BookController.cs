using Models.Common;
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {

        void SetViewBag(long? selectedAuthor = null, long? selectedPublisher = null, long? selectedCategory = null)
        {
            ViewBag.BookAuthor = new SelectList(new BookAuthorDAO().getListAll(), "ID", "Name", selectedAuthor);
            ViewBag.BookPublisher = new SelectList(new PublisherDAO().getListAll(), "ID", "Name", selectedPublisher);
            ViewBag.BookCategory = new SelectList(new CategoryDAO().getListAll(), "ID", "Name", selectedCategory);
        }

        // GET: Admin/Book
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            
            BookDAO dao = new BookDAO();
            var model = dao.GetListBookPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;

            ViewBag.DBContext = new BookStoreDbContext();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            
            if (ModelState.IsValid)
            {
                BookDAO dao = new BookDAO();
                bool success = dao.Insert(book);
                if (success)
                {
                    SetAlert("Thêm sách thành công", "success");
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    SetAlert("Thêm sách thất bại", "warning");
                    ModelState.AddModelError("", "Thêm sách không thành công");
                }
            }
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Book book = new BookDAO().getBookByID(id);
            SetViewBag(book.BookAuthor, book.BookPublisher, book.BookCategory);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            
            if (ModelState.IsValid)
            {
                bool success = new BookDAO().Update(book);
                if (success)
                {
                    SetAlert("Cập nhật thông tin sách thành công", "success");
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    SetAlert("Cập nhật  thông tin sách thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật  thông tin sách không thành công");
                }
            }
            return RedirectToAction("Index", "Book");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new BookDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa thông tin sách thành công", "success");
            }
            else
            {
                SetAlert("Xóa thông tin sách thất bại", "warning");
            }
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new BookDAO().ChangeStatus(id);
            return Json(new {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeNew(long id)
        {
            var result = new BookDAO().ChangeNewProduct(id);
            return Json(new {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeHot(long id)
        {
            var result = new BookDAO().ChangeHotProduct(id);
            return Json(new {
                status = result
            });
        }
    }
}
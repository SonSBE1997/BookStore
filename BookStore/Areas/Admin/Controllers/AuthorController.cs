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
    public class AuthorController : BaseController
    {
        // GET: Admin/Author
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            BookAuthorDAO dao = new BookAuthorDAO();
            var model = dao.GetListAuthorPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookAuthor author)
        {
           
            if (ModelState.IsValid)
            {
                BookAuthorDAO dao = new BookAuthorDAO();
                bool success = dao.Insert(author);
                if (success)
                {
                    SetAlert("Thêm tác gỉả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    SetAlert("Thêm tác gỉả thất bại", "warning");
                    ModelState.AddModelError("", "Thêm tác gỉả không thành công");
                }
            }
            return RedirectToAction("Index", "Author");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            BookAuthor author = new BookAuthorDAO().getAuthorByID(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(BookAuthor author)
        {
           
            if (ModelState.IsValid)
            {
                bool success = new BookAuthorDAO().Update(author);
                if (success)
                {
                    SetAlert("Cập nhật thông tin tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    SetAlert("Cập nhật  thông tin tác giả thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật  thông tin tác giả không thành công");
                }
            }
            return RedirectToAction("Index", "Author");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new BookAuthorDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa tác giả thành công", "success");
            }
            else
            {
                SetAlert("Xóa tác giả thất bại", "warning");
            }
            return RedirectToAction("Index", "Author");
        }
    }
}
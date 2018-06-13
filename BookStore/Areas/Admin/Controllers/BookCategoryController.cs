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
    public class BookCategoryController : BaseController
    {
        // GET: Admin/BookCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            CategoryDAO dao = new CategoryDAO();
            var model = dao.GetListCategoryPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.ParentCategory = dao.getListAll();
           
            return View(model);
        }

        public void SetViewBag(long? selectedId = null, long? id = null)
        {
            var dao = new CategoryDAO();
            List<BookCategory> lst = dao.getListAll();
            lst.Insert(0, new BookCategory()
            {
                ID = -100,
                Name = "",
                ParentID = null,
                Status = false
            });

            if (id != null)
                lst.Remove(dao.getBookCategoryByID((long)id));
            ViewBag.ParentID = new SelectList(lst, "ID", "Name", selectedId);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookCategory category)
        {
           
            if (ModelState.IsValid)
            {
                CategoryDAO dao = new CategoryDAO();
                bool success = dao.Insert(category);
                if (success)
                {
                    SetAlert("Thêm  danh mục sách thành công", "success");
                    return RedirectToAction("Index", "BookCategory");
                }
                else
                {
                    SetAlert("Thêm  danh mục sách thất bại", "warning");
                    ModelState.AddModelError("", "Thêm  danh mục sách không thành công");
                }
            }
            return RedirectToAction("Index", "BookCategory");
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            BookCategory category = new CategoryDAO().getBookCategoryByID(id);
            if (category.ParentID == null) SetViewBag(-100, id);
            else SetViewBag(category.ParentID, id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(BookCategory category)
        {
           
            if (ModelState.IsValid)
            {
                bool success = new CategoryDAO().Update(category);
                if (success)
                {
                    SetAlert("Cập nhật danh mục sách thành công", "success");
                    return RedirectToAction("Index", "BookCategory");
                }
                else
                {
                    SetAlert("Cập nhật  danh mục sách thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật  danh mục sách không thành công");
                }
            }
            return RedirectToAction("Index", "BookCategory");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new CategoryDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa  danh mục sách thành công", "success");
            }
            else
            {
                SetAlert("Xóa  danh mục sách thất bại", "warning");
            }
            return RedirectToAction("Index", "BookCategory");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new {
                status = result
            });
        }
    }
}
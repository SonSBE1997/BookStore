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
    public class PublisherController : BaseController
    {
        // GET: Admin/Publisher
        public ActionResult Index(string searchString, int page = 1, int pageSize = 1)
        {
            PublisherDAO dao = new PublisherDAO();
            var model = dao.GetListPublisherPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookPublisher publisher)
        {
            
            if (ModelState.IsValid)
            {
                PublisherDAO dao = new PublisherDAO();
                bool success = dao.Insert(publisher);
                if (success)
                {
                    SetAlert("Thêm nhà xuất bản thành công", "success");
                    return RedirectToAction("Index", "Publisher");
                }
                else
                {
                    SetAlert("Thêm nhà xuất bản thất bại", "warning");
                    ModelState.AddModelError("", "Thêm nhà xuất bản không thành công");
                }
            }
            return RedirectToAction("Index", "Publisher");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            BookPublisher publisher = new PublisherDAO().getPublisherByID(id);
            return View(publisher);
        }

        [HttpPost]
        public ActionResult Edit(BookPublisher publisher)
        {
            
            if (ModelState.IsValid)
            {
                bool success = new PublisherDAO().Update(publisher);
                if (success)
                {
                    SetAlert("Cập nhật nhà xuất bản thành công", "success");
                    return RedirectToAction("Index", "Publisher");
                }
                else
                {
                    SetAlert("Cập nhật  nhà xuất bản thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật  nhà xuất bản không thành công");
                }
            }
            return RedirectToAction("Index", "Publisher");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new PublisherDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa nhà xuất bản thành công", "success");
            }
            else
            {
                SetAlert("Xóa nhà xuất bản thất bại", "warning");
            }
            return RedirectToAction("Index", "Publisher");
        }
    }
}
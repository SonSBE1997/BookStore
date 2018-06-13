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
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            SlideDAO dao = new SlideDAO();
            var model = dao.GetListSlidePaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
           
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide slide)
        {
           
            if (ModelState.IsValid)
            {
                SlideDAO dao = new SlideDAO();
                bool success = dao.Insert(slide);
                if (success)
                {
                    SetAlert("Thêm slide thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Thêm slide thất bại", "warning");
                    ModelState.AddModelError("", "Thêm slide không thành công");
                }
            }
            return RedirectToAction("Index", "Slide");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Slide slide = new SlideDAO().getSlideByID(id);
            return View(slide);
        }

        [HttpPost]
        public ActionResult Edit(Slide slide)
        {
           
            if (ModelState.IsValid)
            {
                bool success = new SlideDAO().Update(slide);
                if (success)
                {
                    SetAlert("Cập nhật slide thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Cập nhật slide thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật slide không thành công");
                }
            }
            return RedirectToAction("Index", "Slide");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new SlideDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa slide thành công", "success");
            }
            else
            {
                SetAlert("Xóa slide thất bại", "warning");
            }
            return RedirectToAction("Index", "Slide");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new SlideDAO().ChangeStatus(id);
            return Json(new {
                status = result
            });
        }
    }
}
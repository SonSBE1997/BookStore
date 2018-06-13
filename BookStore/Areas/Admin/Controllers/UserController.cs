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
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            UserDAO dao = new UserDAO();
            var model = dao.GetListUserPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
           
            if (ModelState.IsValid)
            {
                UserDAO dao = new UserDAO();
                bool success = dao.Insert(user);
                if (success)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm người dùng thất bại", "warning");
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            User user = new UserDAO().GetUserByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
           
            if (ModelState.IsValid)
            {
                bool success = new UserDAO().Update(user);
                if (success)
                {
                    SetAlert("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Cập nhật người dùng thất bại", "warning");
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            }
            return RedirectToAction("Index", "User");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool success = new UserDAO().Delete(id);
            if (success)
            {
                SetAlert("Xóa người dùng thành công", "success");
            }
            else
            {
                SetAlert("Xóa người dùng thất bại", "warning");
            }
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeRole(long id)
        {
            var result = new UserDAO().ChangeRole(id);
            return Json(new {
                role = result
            });
        }
    }
}
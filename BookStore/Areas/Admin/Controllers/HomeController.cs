using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NameLogin()
        {
            if (Session[Constant.USER_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Name = ((UserLogin)Session[Constant.USER_SESSION]).Name;
            return PartialView();
        }
    }
}
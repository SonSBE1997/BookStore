using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session[Constant.CLIENT_SESSION] = null;
            Session[Constant.CART_ITEM] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
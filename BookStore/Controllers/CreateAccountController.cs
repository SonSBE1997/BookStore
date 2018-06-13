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
    public class CreateAccountController : Controller
    {
        // GET: CreateAccount
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {

            if (ModelState.IsValid)
            {

                UserDAO dao = new UserDAO();
                bool success = dao.Register(user);
                if (success)
                {
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID;
                    userSession.Name = user.Name;

                    Session.Add(Constant.CLIENT_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký thất bại");
                }

            }
            else
            {
                ModelState.AddModelError("", "Đăng ký thất bại");
            }
            return RedirectToAction("Index");
        }
    }
}


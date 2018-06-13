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
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            
            OrderDAO dao = new OrderDAO();
            var model = dao.GetListBillPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;

            return View(model);
        }

        public ActionResult ViewDetail(long id)
        {
            OrderDAO orderDAO = new OrderDAO();
            Bill model = orderDAO.GetBillByOrderID(id);
            ViewBag.OrderDetail = orderDAO.getOrderDetailByOrderID(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult ChangePayment(long id)
        {
            var result = new OrderDAO().ChangePayment(id);
            return Json(new {
                payment = result
            });
        }


        [HttpPost]
        public JsonResult ChangeDeliveryStatus(long id)
        {
            return Json(new {
                deliveryStatus = new OrderDAO().ChangeDeliveryStatus(id)
            });
        }
    }
}
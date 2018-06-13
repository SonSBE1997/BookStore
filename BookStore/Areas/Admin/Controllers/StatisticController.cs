using Models.Common;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class StatisticController : BaseController
    {
        // GET: Admin/Statistic
        public ActionResult Index(int id = 2018)
        {
            
            StatisticDAO dao = new StatisticDAO();
            ViewBag.Year = id;
            ViewBag.Month = dao.statisticGroupByMonth(id);
            ViewBag.List = new List<decimal>() { dao.getTotalPriceBillByYear(id-1),
                dao.getTotalPriceBillByYear(id),
                dao.getTotalPriceBillByYear(id+1) };
            return View();
        }

        public ActionResult ViewDetail(string id = "2018_1")
        {
            string[] result = id.Split('_');
            int year = Int32.Parse(result[0]);
            int month = Int32.Parse(result[1]);
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Data = new StatisticDAO().getPriceGroupByBook(month, year);
            return View();
        }
    }
}
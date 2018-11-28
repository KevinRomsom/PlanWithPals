using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;

namespace PlanWithPals.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ActivityViewModel activityViewModel;
            ActivityLogic activityLogic = new ActivityLogic();
            var activities = new List<ActivityViewModel>();
            
            foreach (var activity in activityLogic.PassActivities())
            {
                activityViewModel = new ActivityViewModel(activity);
            }
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
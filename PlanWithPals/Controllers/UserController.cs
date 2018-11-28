using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using Models;

namespace PlanWithPals.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        //maybe redundant don't know yet
        public ActionResult CreateActivity()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        UserLogic userLogic = new UserLogic();

        [HttpPost]
        public ActionResult Login(string emailaddress, string password)
        {
        
                ViewData["Emailaddress"] = emailaddress;
                ViewData["Password"] = password;

                User user = new User(emailaddress, password);

                

                if (userLogic.checkLogin(user))
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Message = "You have submitted a wrong emailaddress or password";
                return View();
        
        }


        //maybe this is redundant don't know for sure yet
        [HttpPost]
        public ActionResult CreateActivity(string name, string surname, string emailaddress, string password)
        {
                ViewData["Name"] = name;
                ViewData["Surname"] = surname;
                ViewData["Emailaddress"] = emailaddress;
                ViewData["Password"] = password;

                return View();
           
        }

        [HttpPost]
        public ActionResult Register(string name, string surname, string emailaddress, string password, string address, string city)
        {
            ViewData["Name"] = name;
            ViewData["Surname"] = surname;
            ViewData["Emailaddress"] = emailaddress;
            ViewData["Password"] = password;
            ViewData["Address"] = address;
            ViewData["City"] = city;

            User user = new User(name, surname, emailaddress, password, address, city);

            if(userLogic.pushToDB(user) == "succes")
            {
                return RedirectToAction("Login", "User");
            }
            else if(userLogic.pushToDB(user) == "failed")
            {
                ViewBag.Message = "The user already exists";
                return View();
            }

            ViewBag.Message = "Did you fill in all the fields?";
            return View();
        }
    }
}
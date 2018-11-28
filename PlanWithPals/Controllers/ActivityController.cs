using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Logic;

namespace PlanWithPals.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActivityCreate()
        {
            return View();
        }

        /* Ga kijken naar friendslist maken in een tabel in database, of iig dat een lijst van emailadressen in de database kan worden opgeslagen.
         * en hoe moet dit dan. Vervolgens moeten terwijl je op de view de emailadressen intypt ze onder het typ veld gedisplayed worden. Vragen hoe. 
         * vervolgens op de knop send invites moeten er mails naar die mailadressen gestuurd worden en dan de lijst van mailadressen, of gekoppeld aan accounts worden, of 
         * opgeslagen worden als een lijst van mailadressen in de tabel van activity. daarna kan ik ze gaan displayen op de index met viewmodels, link staat in bladwijzer van chrome
         * hoe ziet een veel op veel relatie eruit in code. Dus als ik meerdere mensen heb die deelenemen aan een activiteit maar die mensen ook individueel deelnemen aan andere activiteiten
         * hoe ziet dat data gewijs eruit en dus hoe kan ik er mee werken
         */

        ActivityLogic activityLogic = new ActivityLogic();

        [HttpPost]
        public ActionResult ActivityCreate(string activityname, string address, string city, DateTime datetime)
        {
            ViewData["ActivityName"] = activityname;
            ViewData["Address"] = address;
            ViewData["City"] = city;
            ViewData["DateTime"] = datetime;

            Activity activity = new Activity(activityname, address, city, datetime);

            activityLogic.pushToDB(activity);

            return RedirectToAction("Index", "Home");
        }
    }
}
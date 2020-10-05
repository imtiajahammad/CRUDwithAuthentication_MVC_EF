using CRUDwithAuthentication_MVC_EF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDwithAuthentication_MVC_EF.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UserManager<ApplicationUser> userManager;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."
                + User.Identity.GetUserId() +"also "+
                HttpContext.User.Identity.GetUserName()+ " -||- "+
                HttpContext.User.Identity.GetUserId();
;
            /*Do it only if user is User.Identity.IsAuthenticated*/
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String username, String password)
        {
            if(username == "esprit" && password == "1234")
            {
                Session["username"] = username;
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View();
            }
        }
    }
}
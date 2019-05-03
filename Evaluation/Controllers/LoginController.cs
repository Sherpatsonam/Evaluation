using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class LoginController : Controller
    {
        User user = new User();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            user.username = username;
            user.password = password;

            if (username == "teacher")
            {
                if (password == "teacher")
                {
                    return View("../Teacher/index", user);

                }
                else return View("Error");
            }
            if (username == "student")
            {
                if (password == "student")
                {
                    return View("../Student/Evaluation", user);

                }
                else return View("Error");
            }
            if (username == "department")
            {
                if (password == "department")
                {
                    return View("../DeptHead/findEvaluation", user);

                }
                else return View("Error");
            }

           
            return View();
        }
    }
}
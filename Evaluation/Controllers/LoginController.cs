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
        private EvaluationDB db = new EvaluationDB();
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
                    List<int> stList = db.Evaluations.Select(m => m.StudentID).ToList();
                    ViewBag.Studlist = new SelectList(stList);
                    return View("../Teacher/index", user);

                }
                else return View("Unauthorized");
            }
            if (username == "student")
            {
                if (password == "student")
                {
                    List<int> stList = db.Evaluations.Select(m => m.StudentID).ToList();
                    ViewBag.Studlist = new SelectList(stList);

                    return View("../Student/Index", user);

                }
                else return View("Unauthorized");
            }
            if (username == "department")
            {
                if (password == "department")
                {
                    return View("../DeptHead/findEvaluation", user);

                }
                else return View("Unauthorized");
            }

           
            return View();
        }
    }
}
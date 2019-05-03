using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Evaluation(User user)
        {
            if (user.username == "student")
            {
                return View();
            }
            return RedirectToAction("../Login/Login");
        }
    }
}
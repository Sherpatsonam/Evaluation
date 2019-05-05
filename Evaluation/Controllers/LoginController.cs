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

            User person = db.Users.Where(m => m.username == username).FirstOrDefault();

            if (username == person.username)
            {
                if (password == person.password)
                {
                    if (person.status == "teacher")
                    {
                        List<int> stList = db.Evaluations.Select(m => m.StudentID).ToList();
                        ViewBag.Studlist = new SelectList(stList);
                        List<string> teachList = db.Teachers.Select(m => m.Name).ToList();
                        ViewBag.Teachlist = new SelectList(teachList);
                      
                        return View("../Teacher/index", person);

                    }
                }
               
                else return View("Unauthorized");
            }
            if (username == person.username)
            {
                if (password == person.password)
                {
                    if (person.status == "student")
                    {
                        List<int> stList = db.Students.Select(m => m.StudentID).ToList();
                        ViewBag.Studlist = new SelectList(stList);
                        List<string> teachList = db.Teachers.Select(m => m.Name).ToList();
                        ViewBag.Teachlist = new SelectList(teachList);
                        return View("../Student/Index", person);
                    }

                   

                }
                else return View("Unauthorized");
            }
            if (username == person.username)
            {
                if (password == person.password)
                {
                    if (person.status == "department")
                    {
                        List<string> teachList = db.Teachers.Select(m => m.Name).ToList();
                        ViewBag.Teachlist = new SelectList(teachList);
                        return View("../DeptHead/findEvaluation", person);
                    }
                   

                }
                else return View("Unauthorized");
            }

           
            return View();
        }
    }
}
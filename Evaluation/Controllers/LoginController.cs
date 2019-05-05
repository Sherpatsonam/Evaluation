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
            if (person != null)
            {
                if (username == person.username)
                {
                    if (password == person.password)
                    {
                        if (person.status == "teacher")
                        {

                            Teacher teacher = db.Teachers.Where(m => m.username == user.username).FirstOrDefault();
                            TempData["teacherName"] = teacher.Name;
                            List<int> stList = db.Evaluations.Where(m => m.TeacherID == teacher.TeacherID).Select(m => m.StudentID).ToList();
                            ViewBag.Studlist = new SelectList(stList);
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
                            Student stud = db.Students.Where(m => m.username == user.username).FirstOrDefault();
                            @TempData["studentId"] = stud.StudentID;
                            @TempData["studentName"] = stud.Name;
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

            return View("Unauthorized"); ;


        }
    }
}
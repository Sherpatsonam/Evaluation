using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class TeacherController : Controller
    {
        private EvaluationDB db = new EvaluationDB();
        // POST: Teacher
        // Select a teacher ID to determine which evaluation to show
        public ActionResult Index(User user)
        {
            if (user.status == "teacher")
            {
                return View();
            }
            return RedirectToAction("../Login/Login");
        }

        // GET: Evaluations
        // Show a teacher's evaluation results
        public ActionResult Details(string teachername, int? std, string graded)
        {
            if (graded != "yes")
            {
                return View("Unauthorized");
            }
            if (teachername == null && std == null) 
            {
                return View("Error");
            }

            // request a complete evaluation form based on teacherID
            Teacher teacher = db.Teachers.Where(x => x.Name == teachername).FirstOrDefault();
            Student student = db.Students.Where(x => x.StudentID == std).FirstOrDefault();
            Evaluation.Models.Evaluation eval = db.Evaluations.Where(x => x.TeacherID == teacher.TeacherID && x.StudentID==std).FirstOrDefault();
            eval.Teacher = teacher;
            eval.Student = student;
            if (eval == null)
            {
                return View("Error");
            }
            return View(eval);
        }
    }
}
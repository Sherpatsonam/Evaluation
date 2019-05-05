using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class DeptHeadController : Controller
    {
        private EvaluationDB db = new EvaluationDB();
        // GET: DeptHead
        public ActionResult getEvaluations(string teachername)
        {

            if (teachername == null)
            {
                return View("Error");
            }

            // request a complete evaluation form based on teacherID
           
            

            List<Evaluation.Models.Evaluation> eval = db.Evaluations.Where(x => x.Teacher.Name== teachername).ToList();
            foreach( var item in eval)
            {
                Teacher teacher = db.Teachers.Where(m => m.Name == teachername).FirstOrDefault();
                item.Teacher = teacher;
                Student student = db.Students.Where(m => m.StudentID == item.StudentID).FirstOrDefault();
                item.Student= student;

            }
            if (eval == null)
            {
                return View("Error");
            }
            return View(eval);
        }

        public ActionResult findEvaluation(User user)
        {
            if (user.status == "department")
            {
                return View();
            }
            return RedirectToAction("../Login/Login");
        }


    }
}
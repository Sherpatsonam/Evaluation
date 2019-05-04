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
            if (user.username == "teacher")
            {
                return View();
            }
            return RedirectToAction("../Login/Login");
        }

        // GET: Evaluations
        // Show a teacher's evaluation results
        public ActionResult Details(int? teacherid, int? std, string graded)
        {
            if (graded != "yes")
            {
                return View("Unauthorized");
            }
            if (teacherid==null && std == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // request a complete evaluation form based on teacherID
            Evaluation.Models.Evaluation eval = db.Evaluations.Where(x => x.TeacherID == teacherid && x.StudentID==std).FirstOrDefault();
            if (eval == null)
            {
                return View("Error");
            }
            return View(eval);
        }
    }
}
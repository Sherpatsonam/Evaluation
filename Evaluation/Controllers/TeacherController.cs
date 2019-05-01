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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Evaluations
        // Show a teacher's evaluation results
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // request a complete evaluation form based on teacherID
            Evaluation.Models.Evaluation eval = db.Evaluations.Where(x => x.TeacherID == id).FirstOrDefault();
            if (eval == null)
            {
                return HttpNotFound();
            }
            return View(eval);
        }
    }
}
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
        public ActionResult getEvaluations(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // request a complete evaluation form based on teacherID
            List<Evaluation.Models.Evaluation> eval = db.Evaluations.Where(x => x.TeacherID == id).ToList();
            if (eval == null)
            {
                return HttpNotFound();
            }
            return View(eval);
        }

        public ActionResult findEvaluation()
        {
            return View();
        }

       
    }
}
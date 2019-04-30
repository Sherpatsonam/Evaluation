using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class DeptHeadController : Controller
    {
        private EvaluationDB db = new EvaluationDB();
        // GET: DeptHead
        public ActionResult getEvaluations()
        {
            var data = db.Evaluations.ToList();
            return View(data);
        }
    }
}
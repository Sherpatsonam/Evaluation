using Evaluation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            
            return View(db.Evaluations.ToList());
        }

        public ActionResult findEvaluation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult findEvaluation(string teacherName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49942/DeptHead/findEvaluations");


                //HTTP POST
                string json = JsonConvert.SerializeObject(teacherName, Formatting.Indented);
                var httpContent = new StringContent(json);
                var postTask = client.PostAsync("DeptHead/getEvaluations",httpContent);
                
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(teacherName);
        }
    }
}
using Evaluation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluation.Controllers
{
    public class StudentController : Controller
    {
        private EvaluationDB db = new EvaluationDB();
        // GET: Student
        
        public ActionResult Index(User user)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            if (user.username == "student")
            {
                
                             
                return View();
            }
            return RedirectToAction("../Login/Login");
        }
        
        public ActionResult Evaluation(int? std)
        {
            if (std != null)
            {
                TempData["std"] = std;
                return View();
            }

            return View("Error");
            
          
        }
       

        [HttpPost]
       
        public ActionResult Evaluation([Bind(Include = "TeacherID, EffectiveTeaching, ProvidesFeedback, learningClimate,DemonstrateKnowlege,professionalism,overAllRanking ")] Evaluation.Models.Evaluation eval)
        {
            eval.StudentID = Convert.ToInt32(TempData["std"]);
            Student stud = db.Students.Where(m => m.StudentID == eval.StudentID).FirstOrDefault();
            eval.Student = stud;
            //Teacher teacher = db.Teachers.Where(m => m.TeacherID == eval.TeacherID).FirstOrDefault();
            //eval.Teacher = teacher;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Evaluations.Add(eval);
                    db.SaveChanges();
                    return View("Submitted");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(eval );
        }
    }
}
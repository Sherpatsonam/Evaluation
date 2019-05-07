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
            if (user.status == "student")
            {
                
                return View();
            }
            return RedirectToAction("../Login/Login");
        }
        
        public ActionResult Evaluation(int? std, string teachername)
        {
            if (std != null)
            {
                Teacher teacher = db.Teachers.Where(m => m.Name == teachername).FirstOrDefault();
                Student stud = db.Students.Where(m => m.StudentID == std).FirstOrDefault();
                TempData["teacher"] = teacher;
                TempData["course"] = teacher.CourseID;
                TempData["std"] = stud;
                TempData["semester"] = stud.Semester;
                TempData["year"] = stud.Year;
                db.ThisObjectContext.Detach(teacher);
                db.ThisObjectContext.Detach(stud);
                return View();
            }

            return View("Error");
            
          
        }
       

        [HttpPost]
       
        public ActionResult Evaluation([Bind(Include = " EffectiveTeaching, ProvidesFeedback, learningClimate,DemonstrateKnowlege,professionalism,overAllRanking ")] Evaluation.Models.Evaluation eval)
        {
           
            Teacher teacher= TempData["teacher"] as Teacher;
            Student student= TempData["std"] as Student;
            eval.TeacherID = teacher.TeacherID;
            eval.StudentID = student.StudentID;
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
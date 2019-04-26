using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
      
        public string CourseID { get; set; }

        public virtual ICollection<Teacher> teachers { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }

    }
}
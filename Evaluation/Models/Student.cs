using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string Semester { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
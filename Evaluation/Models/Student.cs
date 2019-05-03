using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    [Table("Student")]
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
       
        public string Semester { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
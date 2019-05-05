using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    [Table("Teacher")]
    public class Teacher
    {   
        [Key]
        public int TeacherID { get; set; }
        public string Name { get; set; }
      
        public string CourseID { get; set; }

        
        public virtual ICollection<Evaluation> Evaluations { get; set; }

    }
}
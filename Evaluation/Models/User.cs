using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    public class User
    {   [Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string status { get; set; }

    }
}
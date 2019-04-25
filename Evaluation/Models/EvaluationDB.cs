using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Evaluation.Models
{
    public class EvaluationDB: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
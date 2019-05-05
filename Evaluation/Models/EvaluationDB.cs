using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Evaluation.Models
{
    public class EvaluationDB: DbContext
    {
        public EvaluationDB() : base("EvaluationDB")
        {

        }

        public ObjectContext ThisObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
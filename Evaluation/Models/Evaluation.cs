using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation.Models
{
    public class Evaluation
    {
        public int ID { get; set; }

        public int TeacherID { get; set; }

        public int StudentID { get; set; }
        public string EffectiveTeaching{ get; set; }

        public string ProvidesFeedback{ get; set; }
        public string learningClimate { get; set; }
        public string DemonstrateKnowlege { get; set; }
        public string professionalism { get; set; }
        public string overAllRanking { get; set; }
      
    }
}
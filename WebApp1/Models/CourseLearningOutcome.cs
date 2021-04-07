using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{

    public class CourseLearningOutcome
    {
        public int Id { get; set; }
        public string Course { get; set; }
        public string Instructor { get; set; }
        public string CourseLearningOutcomeDescription { get; set; }
        public int TotalStudents { get; set; }
        public int CompleteLevel { get; set; }
        public int SatisfactoryLevel { get; set; }
        public int NotMet { get; set; }
        public int NotMeasurable { get; set; } 
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> b9bb2329eac1893a631f16227e0981cd0ffc93aa

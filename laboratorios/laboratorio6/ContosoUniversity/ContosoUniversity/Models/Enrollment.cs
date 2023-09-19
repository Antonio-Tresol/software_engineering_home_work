using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models{
    public enum Grade{
        A, B, C, D, F
    }

    public class Enrollment{
        // primary key
        public int EnrollmentID { get; set; }
        // foreign key from Course relation 
        public int CourseID { get; set; }
        // foreign key from Student relation (relations are called entities in entity framework)
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        // ? means nullable
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
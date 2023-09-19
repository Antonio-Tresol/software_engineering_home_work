namespace ContosoUniversity.Models {
    public class Student {
        // entity framework takes attributes called ID or class id as primary key.
        // you can also use [Key] attribute to specify primary key.
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // navigation property that holds other entities that are related to this entity.
        // that is to say, a Student can be enrolled in many courses, so this property
        // holds other entities that are related to this entity such as courses.
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data {
    // This class defines the context that will handle database access using Entity Framework Core. 
    public class SchoolContext : DbContext {
        // This constructor creates a new instance of SchoolContext and passes in an instance of DbContextOptions that will be used to initiate DbContext.
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        // This property represents the Student table in the database using DbSet, which provides an in-memory representation of the database data. 
        public DbSet<Student> Students { get; set; }
        // This property represents the Enrollment table in the database using DbSet, which provides an in-memory representation of the database data.
        public DbSet<Enrollment> Enrollments { get; set; }
        // This property represents the Course table in the database using DbSet, which provides an in-memory representation of the database data.
        public DbSet<Course> Courses { get; set; }

        // This method defines the database schema for the context.
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // This method modifies the Course entity's table name to Course in the database.
            modelBuilder.Entity<Course>().ToTable("Course");
            // This method modifies the Enrollment entity's table name to Enrollment in the database.
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            // This method modifies the Student entity's table name to Student in the database.
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}

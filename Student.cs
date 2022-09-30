using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace school_ef_livecoding
{
    //[Table("student")]
    //[Index(nameof(Email), IsUnique = true)]
    public class Student
    {
        //[Key]
        public int StudentId { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        //[Column("student_email")]
        public string Email { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Course> FrequentedCourses { get; set; }
    }
}

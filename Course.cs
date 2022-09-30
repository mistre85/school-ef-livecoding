using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using school_ef_livecoding;

namespace school_ef_livecoding
{
    //[Table("course")]
    public class Course
    {
        //[Key]
        public int CourseId { get; set; }
        public string Name { get; set; }

        public CourseImage CourseImage { get; set; }

        public List<Student> StudentsEnrolled { get; set; }
    }

}


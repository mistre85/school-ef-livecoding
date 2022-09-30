// See https://aka.ms/new-console-template for more information
using school_ef_livecoding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//[Table("course_image")]
public class CourseImage
{
    //[Key]
    public int CourseImageId { get; set; }
    public byte[] Image { get; set; }
    public string Caption { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}

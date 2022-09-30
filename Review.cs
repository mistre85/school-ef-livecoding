// See https://aka.ms/new-console-template for more information
using school_ef_livecoding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//[Table("review")]
public class Review
{
    //[Key]
    public int ReviewId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}

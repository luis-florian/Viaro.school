
namespace School.Core.Entities;

public class GradeStudent
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GradeId { get; set; }
    public required string Section { get; set; }
    public Student? Student { get; set; }
    public Grade? Grade { get; set; }
}
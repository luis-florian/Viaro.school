
namespace School.Core.Entities;
public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();
}

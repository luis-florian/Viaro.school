
namespace School.Core.Entities;

public class Teacher
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}

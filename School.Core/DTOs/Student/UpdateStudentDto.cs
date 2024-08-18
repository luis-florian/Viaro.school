
namespace School.Core.DTOs.Student;

public class UpdateStudentDto
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public DateTime BirthDate { get; set; }
}


namespace School.Core.DTOs.Grade;

public class CreateGradeDto
{
    public int TeacherId { get; set; }
    public required string Name { get; set; }
}

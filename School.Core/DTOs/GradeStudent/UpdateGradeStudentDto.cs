
namespace School.Core.DTOs.GradeStudent;

public class UpdateGradeStudentDto
{
    public int StudentId { get; set; }
    public int GradeId { get; set; }
    public required string Section { get; set; }
}

using System.Text.Json.Serialization;

namespace School.Core.Entities;

public class Grade
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public Teacher? Teacher { get; set; }
    public ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();
}

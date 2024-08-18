namespace School.Web.Model
{
    public class GradeStudentModel
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string? Section { get; set; }
    }

    public class UpdateGradeStudentModel
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public required string Section { get; set; }
    }
}

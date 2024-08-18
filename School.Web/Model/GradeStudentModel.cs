namespace School.Web.Model
{
    public class GradeStudentModel
    {
        public required string Section { get; set; }
    }

    public class UpdateGradeStudentModel
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public required string Section { get; set; }
    }
}

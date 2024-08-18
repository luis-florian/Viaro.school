using Refit;
using School.Web.Model;

namespace School.Web.Services
{
    public interface IGradeService
    {
        [Get("/api/grades")]
        Task<ApiResponse<List<GradeModel>>> GetGradesAsync();

        [Get("/api/grades/{id}")]
        Task<ApiResponse<GradeModel>> GetGradesByIdAsync(int id);

        [Post("/api/grades")]
        Task CreateGradesAsync([Body] GradeModel grade);

        [Put("/api/grades/{id}")]
        Task UpdateGradesAsync(int id, [Body] GradeModel grade);

        [Delete("/api/grades/{id}")]
        Task DeleteGradesAsync(int id);

        [Post("/api/grade/{gradeId}/student/{studentId}")]
        Task CreateStudentGradeAsync(int gradeId, int studentId, [Body] GradeStudentModel gradeStudent);

        [Put("/api/gradeStudent/{gradeStudentId}")]
        Task UpdateStudentGradeAsync(int gradeStudentId, [Body] UpdateGradeStudentModel gradeStudent);
    }
}

using Refit;
using School.Web.Model;

namespace School.Web.Services;

public interface IStudentService
{
    [Get("/api/students")]
    Task<ApiResponse<List<StudentModel>>> GetStudentsAsync();

    [Get("/api/students/{id}")]
    Task<ApiResponse<StudentModel>> GetStudentByIdAsync(int id);

    [Post("/api/students")]
    Task CreateStudentAsync([Body] StudentModel student);

    [Put("/api/students/{id}")]
    Task UpdateStudentAsync(int id, [Body] StudentModel student);

    [Delete("/api/students/{id}")]
    Task DeleteStudentAsync(int id);
}

using Refit;
using School.Web.Model;

namespace School.Web.Services;

public interface ITeacherService
{
    [Get("/api/teachers")]
    Task<ApiResponse<List<TeacherModel>>> GetTeachersAsync();

    [Get("/api/teachers/{id}")]
    Task<ApiResponse<TeacherModel>> GetTeacherByIdAsync(int id);

    [Post("/api/teachers")]
    Task CreateTeacherAsync([Body] TeacherModel student);

    [Put("/api/teachers/{id}")]
    Task UpdateTeacherAsync(int id, [Body] TeacherModel student);

    [Delete("/api/teachers/{id}")]
    Task DeleteTeacherAsync(int id);
}

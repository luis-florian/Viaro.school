using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Grade
{
    public class IndexModel(IGradeService gradeService, ITeacherService teacherService) : PageModel
    {
        private readonly IGradeService _gradeService = gradeService;
        private readonly ITeacherService _teacherService = teacherService;
        public List<GradeModel> Grades { get; set; } = [];
        public List<TeacherModel> Teachers { get; set; } = [];
        public async Task OnGet()
        {
            var response = await _gradeService.GetGradesAsync();

            if (response.IsSuccessStatusCode)
            {
                Grades = response.Content;
            }

            var teachersResponse = await _teacherService.GetTeachersAsync();

            if (response.IsSuccessStatusCode)
            {
                Teachers = teachersResponse.Content;
            }

            foreach (var grade in Grades)
            {
                var teacher = Teachers.FirstOrDefault(t => t.Id == grade.TeacherId);
                if (teacher != null)
                {
                    grade.TeacherName = teacher.Name;
                }
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _gradeService.DeleteGradesAsync(id);

            return RedirectToPage();
        }
    }
}

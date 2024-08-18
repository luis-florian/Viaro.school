using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Grade
{
    public class AssignModel(IGradeService gradeService, IStudentService studentService) : PageModel
    {
        private readonly IGradeService _gradeService = gradeService;
        private readonly IStudentService _studentService = studentService;
        public List<StudentModel> Students { get; set; } = [];
        public List<GradeModel> Grades { get; set; } = [];

        [BindProperty]
        public GradeStudentModel GradeStudent { get; set; } = new GradeStudentModel();
        public async Task OnGet()
        {
            var tresponse = await _studentService.GetStudentsAsync();

            if (tresponse.IsSuccessStatusCode)
            {
                Students = tresponse.Content;
            }

            var gresponse = await _gradeService.GetGradesAsync();

            if (gresponse.IsSuccessStatusCode)
            {
                Grades = gresponse.Content;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _gradeService.CreateStudentGradeAsync(GradeStudent.GradeId, GradeStudent.StudentId, GradeStudent);

            return RedirectToPage("./Index");
        }

    }
}

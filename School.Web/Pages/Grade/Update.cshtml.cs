using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Grade
{
    public class UpdateModel(IGradeService gradeService, ITeacherService teacherService) : PageModel
    {
        private readonly IGradeService _gradeService = gradeService;
        private readonly ITeacherService _teacherService = teacherService;

        public List<TeacherModel> Teachers { get; set; } = new List<TeacherModel>();

        [BindProperty]
        public GradeModel Grade { get; set; } = new GradeModel();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var gradeResponse = await _gradeService.GetGradesByIdAsync(id);

            if (!gradeResponse.IsSuccessStatusCode || gradeResponse.Content == null)
            {
                return NotFound();
            }

            Grade = gradeResponse.Content;

            var teachersResponse = await _teacherService.GetTeachersAsync();
            if (teachersResponse.IsSuccessStatusCode)
            {
                Teachers = teachersResponse.Content;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             await _gradeService.UpdateGradesAsync(Grade.Id, Grade);

            return RedirectToPage("./Index");
        }
    }
}

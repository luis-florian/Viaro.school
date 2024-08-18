using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Grade
{
    public class CreateModel(IGradeService gradeService, ITeacherService teacherService) : PageModel
    {
        private readonly IGradeService _gradeService = gradeService;
        private readonly ITeacherService _teacherService = teacherService;
        public List<TeacherModel> Teachers { get; set; } = [];
        [BindProperty]
        public GradeModel Grade { get; set; } = new GradeModel();
        public async Task OnGet()
        {
            var response = await _teacherService.GetTeachersAsync();

            if (response.IsSuccessStatusCode)
            {
                Teachers = response.Content;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _gradeService.CreateGradesAsync(Grade);

            return RedirectToPage("./Index");
        }
    }
}

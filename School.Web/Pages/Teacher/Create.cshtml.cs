using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Teacher
{
    public class CreateModel(ITeacherService teacherService) : PageModel
    {
        private readonly ITeacherService _teacherService = teacherService;

        [BindProperty]
        public TeacherModel Teacher { get; set; } = new TeacherModel();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _teacherService.CreateTeacherAsync(Teacher);

            return RedirectToPage("./Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Teacher
{
    public class UpdateModel(ITeacherService teacherService) : PageModel
    {
        private readonly ITeacherService _teacherService = teacherService;

        [BindProperty]
        public TeacherModel Teacher { get; set; } = new TeacherModel();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _teacherService.GetTeacherByIdAsync(id);

            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                return NotFound();
            }

            Teacher = response.Content;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _teacherService.UpdateTeacherAsync(Teacher.Id, Teacher);

            return RedirectToPage("/Teacher/Index");
        }
    }
}

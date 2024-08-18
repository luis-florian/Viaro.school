using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Student
{
    public class CreateModel(IStudentService studentService) : PageModel
    {
        private readonly IStudentService _studentService = studentService;

        [BindProperty]
        public StudentModel Student { get; set; } = new StudentModel();
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentService.CreateStudentAsync(Student);

            return RedirectToPage("./Index");
        }
    }
}

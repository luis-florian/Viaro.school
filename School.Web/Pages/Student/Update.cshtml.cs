using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Student
{
    public class UpdateModel(IStudentService studentService) : PageModel
    {
        private readonly IStudentService _studentService = studentService;

        [BindProperty]
        public StudentModel Student { get; set; } = new StudentModel();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _studentService.GetStudentByIdAsync(id);

            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                return NotFound();
            }

            Student = response.Content;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentService.UpdateStudentAsync(Student.Id, Student);

            return RedirectToPage("/Student/Index");
        }
    }
}

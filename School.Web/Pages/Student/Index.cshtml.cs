using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Student
{
    public class IndexModel(IStudentService studentService) : PageModel
    {
        private readonly IStudentService _studentService = studentService;
        public List<StudentModel> Students { get; set; } = [];
        public async Task OnGetAsync()
        {
            var response = await _studentService.GetStudentsAsync();

            if (response.IsSuccessStatusCode)
            {
                Students = response.Content;
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _studentService.DeleteStudentAsync(id);

            return RedirectToPage();
        }
    }
}

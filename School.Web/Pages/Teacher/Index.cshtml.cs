using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.Web.Model;
using School.Web.Services;

namespace School.Web.Pages.Teacher
{
    public class IndexModel(ITeacherService teacherService) : PageModel
    {
        private readonly ITeacherService _teacherService = teacherService;
        public List<TeacherModel> Teachers { get; set; } = [];
        public async Task OnGetAsync()
        {
            var response = await _teacherService.GetTeachersAsync();

            if (response.IsSuccessStatusCode)
            {
                Teachers = response.Content;
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);

            return RedirectToPage();
        }
    }
}

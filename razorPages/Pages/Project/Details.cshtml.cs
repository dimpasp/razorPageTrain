using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using System.Threading.Tasks;

namespace razorPages.Pages.Project
{
    public class DetailsModel : PageModel
    {
        private readonly IProjectRepository _projectepository;
        public RazorPages.Models.Project project { get; private set; }
        public DetailsModel(IProjectRepository projectepository)
        {
            this._projectepository = projectepository;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            project = await _projectepository.getProjectByIdAsync(id);
            if (project == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}


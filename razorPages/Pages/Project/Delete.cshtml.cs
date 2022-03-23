using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using System.Threading.Tasks;

namespace razorPages.Pages.Project
{
    public class DeleteModel : PageModel
    {
        private readonly IProjectRepository _projectepository;
        [BindProperty]
        public RazorPages.Models.Project Project { get; set; }
        public DeleteModel(IProjectRepository projectepository)
        {
            this._projectepository = projectepository;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Project = await _projectepository.getProjectByIdAsync(id);

            if (Project == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            RazorPages.Models.Project deletedProject = await _projectepository.DeleteAsync(Project.id);

            if (deletedProject == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Index");
        }
    }
}





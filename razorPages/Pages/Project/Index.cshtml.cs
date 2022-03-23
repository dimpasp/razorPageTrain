using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using System.Collections.Generic;


namespace razorPages.Pages.Project
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        private readonly IProjectRepository _projectepository;

        public IEnumerable<RazorPages.Models.Project> Projects { get; set; }

        public IndexModel(IProjectRepository projectRepository)
        {
            this._projectepository = projectRepository;
        }
        public void OnGet()
        {
            Projects = _projectepository.Search(SearchTerm);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace razorPages.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public Employee Employee { get; private set; }
        [BindProperty(SupportsGet =true)]
        public string Message { get; set; }
        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public IActionResult OnGet(int id)
        {
            Employee=_employeeRepository.GetEmployee(id); 
            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
         }
    } 
}

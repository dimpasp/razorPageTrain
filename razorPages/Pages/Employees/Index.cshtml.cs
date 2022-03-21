using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Models;
using System.Collections;
using System.Collections.Generic;

namespace razorPages.Pages.Employees
{
    public class IndexModel : PageModel
    {
        //BindProperty default είναι για post,οποτε πρεπει να θέσω το SupportGet = true
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        private readonly IEmployeeRepository _employeeRepository;

        public IEnumerable<Employee> Employees { get; set; }

        public IndexModel(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
            Employees=_employeeRepository.Search(SearchTerm);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RazorPages.Models;
using RazorPages.Services;

namespace razorPages.ViewComponents
{
    public class HeadCountViewComponent:ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;
        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        //next step InvokeAsync
        //=null =>ετσι δημιουργω optional parameter
        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = employeeRepository.EmployeeCountByDept(department);
            return View(result);
        }
    }
}

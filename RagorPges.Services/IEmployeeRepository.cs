using RazorPages.Models;
using System;
using System.Collections.Generic;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> Search(string searchTerm);
        Employee Update(Employee updatedEmployee);
        Employee Delete(int id);
        Employee Add(Employee newEmployee);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);
    }
}

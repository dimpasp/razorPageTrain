using RazorPages.Models;
using System;
using System.Collections.Generic;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
    }
}

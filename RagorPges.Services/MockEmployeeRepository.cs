using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPages.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        //initialize employee list in constructor for test
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR,
                    Email = "mary@pragimtech.com", PhotoPath="mary.png" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT,
                    Email = "john@pragimtech.com", PhotoPath="john.png" },
                new Employee() { Id = 3, Name = "Sara", Department = Dept.IT,
                    Email = "sara@pragimtech.com", PhotoPath="sara.png" },
                new Employee() { Id = 4, Name = "David", Department = Dept.Payroll,
                    Email = "david@pragimtech.com"},
            };
        }

        public Employee Add(Employee newEmployee)
        {
            //i will do it in auto mode,now just for test
           newEmployee.Id=_employeeList.Max(x => x.Id)+1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _employeeList.FirstOrDefault(x => x.Id == id);
            if (employeeToDelete != null)
            {
                _employeeList.Remove(employeeToDelete);
            }
            return employeeToDelete;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(l => l.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee=_employeeList.FirstOrDefault(x=>x.Id == updatedEmployee.Id);    
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;   
                employee.Department = updatedEmployee.Department;
                employee.Email = updatedEmployee.Email; 
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }
            return employee;
        }
    }
}

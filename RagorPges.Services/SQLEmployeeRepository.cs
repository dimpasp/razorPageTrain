using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPages.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee newEmployee)
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = context.Employees;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department)
                                .Select(g => new DeptHeadCount()
                                {
                                    Department = g.Key.Value,
                                    Count = g.Count()
                                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Set<Employee>().SingleOrDefault(s => s.Id == id);

            ////αν θελω να χρησιμοποιησω stored procedure
            //SqlParameter parameter = new SqlParameter("@Id", id);
            //return context.Employee
            //        .FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter)
            //        .ToList()
            //        .FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Employees;
            }

            return context.Employees.Where(e => e.Name.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = context.Employees.Attach(updatedEmployee);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return updatedEmployee;
        }
    }
}

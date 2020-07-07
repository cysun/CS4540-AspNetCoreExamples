using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVC.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;

        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetEmployees()
        {
            return _db.Employees.ToList();
        }
    }

    public class MockEmployeeService : IEmployeeService
    {
        private List<Employee> employees;

        public MockEmployeeService()
        {
            var john = new Employee
            {
                Id = 1,
                Name = "John",
                DateHired = new DateTime(2015, 1, 16),
                Supervisor = null
            };
            var jane = new Employee
            {
                Id = 2,
                Name = "Jane",
                DateHired = new DateTime(2015, 1, 16),
                Supervisor = john
            };
            employees = new List<Employee> { john, jane };
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}

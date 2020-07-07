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

        Employee GetEmployee(int id);

        void AddEmployee(Employee e);
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

        public Employee GetEmployee(int id)
        {
            return _db.Employees.Find(id);
        }

        public void AddEmployee(Employee e)
        {
            _db.Employees.Add(e);
            _db.SaveChanges();
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

        public Employee GetEmployee(int id)
        {
            return employees[id - 1];
        }

        public void AddEmployee(Employee e)
        {
            e.Id = employees.Count;
            employees.Add(e);
        }
    }
}

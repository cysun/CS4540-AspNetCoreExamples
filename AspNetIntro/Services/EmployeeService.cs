using AspNetIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIntro.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }

    public class MockEmployeeService : IEmployeeService
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee{ Id = 1, Name = "John"},
            new Employee{ Id = 2, Name = "Jane"},
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}

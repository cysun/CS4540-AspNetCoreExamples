using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVC.Models;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public WebApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("api/employees")]
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        [HttpGet("api/employees/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        [HttpPut("api/employees/{employeeId}/supervisor/{supervisorId}")]
        public IActionResult SetSupervisor(int employeeId, int supervisorId)
        {
            var employee = _employeeService.GetEmployee(employeeId);
            if (employee != null)
            {
                employee.SupervisorId = supervisorId;
                _employeeService.SaveChanges();
            }

            return Ok();
        }
    }
}

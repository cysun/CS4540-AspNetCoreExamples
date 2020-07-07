using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult List()
        {
            return View(_employeeService.GetEmployees());
        }
    }
}

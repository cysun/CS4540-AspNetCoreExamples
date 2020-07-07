using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVC.Models;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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

        public IActionResult View(int id)
        {
            return View(_employeeService.GetEmployee(id));
        }

        public IActionResult Two(int id1, int id2)
        {
            return View((_employeeService.GetEmployee(id1), _employeeService.GetEmployee(id2)));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee e)
        {
            _employeeService.AddEmployee(e);
            return RedirectToAction(nameof(List));
        }
    }
}

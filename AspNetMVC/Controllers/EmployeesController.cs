using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVC.Models;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            e.Hash = BCrypt.Net.BCrypt.HashPassword("abcd");
            _employeeService.AddEmployee(e);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Supervisors = _employeeService.GetEmployees().Where(e => e.Id != id).Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            return View(_employeeService.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            var employee = _employeeService.GetEmployee(e.Id);
            employee.Name = e.Name;
            employee.DateHired = e.DateHired;
            employee.SupervisorId = e.SupervisorId;
            _employeeService.SaveChanges();
            return RedirectToAction(nameof(View), new { id = e.Id });
        }
    }
}

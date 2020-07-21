using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMVC.Models;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace AspNetMVC.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAuthorizationService _authorizationService;

        public EmployeesController(IEmployeeService employeeService, IAuthorizationService authorizationService)
        {
            _employeeService = employeeService;
            _authorizationService = authorizationService;
        }

        public IActionResult List()
        {
            return View(_employeeService.GetEmployees());
        }

        public async Task<IActionResult> ViewAsync(int id)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, id, "CanAccessEmployee");
            if (!authResult.Succeeded)
                return Forbid();
            return View(_employeeService.GetEmployee(id));
        }

        public IActionResult Two(int id1, int id2)
        {
            return View((_employeeService.GetEmployee(id1), _employeeService.GetEmployee(id2)));
        }

        [HttpGet]
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Add(Employee e)
        {
            e.Hash = BCrypt.Net.BCrypt.HashPassword("abcd");
            _employeeService.AddEmployee(e);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, id, "CanAccessEmployee");
            if (!authResult.Succeeded)
                return Forbid();

            ViewBag.Supervisors = _employeeService.GetEmployees().Where(e => e.Id != id).Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            return View(_employeeService.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Employee e)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, e.Id, "CanAccessEmployee");
            if (!authResult.Succeeded)
                return Forbid();

            var employee = _employeeService.GetEmployee(e.Id);
            employee.Name = e.Name;
            employee.DateHired = e.DateHired;
            employee.SupervisorId = e.SupervisorId;
            _employeeService.SaveChanges();
            return RedirectToAction(nameof(ViewAsync), new { id = e.Id });
        }
    }
}

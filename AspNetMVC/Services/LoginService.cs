using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetMVC.Services
{
    public class LoginService
    {
        private readonly IEmployeeService _employeeService;

        public LoginService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ClaimsIdentity Login(string username, string password)
        {
            var employee = _employeeService.GetEmployee(username);
            if (employee == null || !BCrypt.Net.BCrypt.Verify(password, employee.Hash))
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, employee.Name),
                new Claim("IsAdmin", employee.IsAdmin.ToString())
            };

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

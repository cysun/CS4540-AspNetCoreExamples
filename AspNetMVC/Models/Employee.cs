using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateHired { get; set; }
        public Employee Supervisor { get; set; }
    }
}

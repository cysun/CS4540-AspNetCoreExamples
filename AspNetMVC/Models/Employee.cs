using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Hash { get; set; }

        public DateTime DateHired { get; set; }

        public int? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }

        public bool IsAdmin { get; set; }
    }
}

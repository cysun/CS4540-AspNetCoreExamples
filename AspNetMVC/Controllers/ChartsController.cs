using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Dates = new List<string> { "6/7/2020", "6/8/2020", "6/9/2020", "6/10/2020" };
            return View(new List<int> { 10, 12, 15, 20 });
        }
    }
}

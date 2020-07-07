using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Index(string path)
        {
            // We have to use the View(viewName, model) method here because
            // if we simply do View(path), ASP.NET Core will be using the
            // View(viewName) method, i.e. treating path as viewName instead
            // of a model.
            return View("Index", path);
        }
    }
}

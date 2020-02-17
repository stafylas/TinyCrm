using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TinyCrmWeb.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult SayHello()
        {
            var model = new Models.NameViewModel()
            {
                Name = " dimitris"
            };
            return View(model);
        }
    }
}
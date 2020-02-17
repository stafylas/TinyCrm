using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;

namespace TinyCrmWeb.Controllers
{
    public class CustomerController : Controller
    {
       
        private TinyCrmDbContext Context { get; set; }

        private TinyCrm.Core.Services.ICustomerService customers_;
        public CustomerController(TinyCrmDbContext context,TinyCrm.Core.Services.ICustomerService customers)
        {
            Context = context;
            customers_ = customers;
        }

        public async Task<IActionResult> Index()
        {
            var customerList =await Context
                .Set<Customer>()
                .Take(100)
                .ToListAsync();
            return View(customerList);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Models.CreateCustomerViewModel model)
        {
            var result =await customers_.CreateCustomerAsync(model?.CreateOptions);
            
            return View(model);
        }
        
    }
}

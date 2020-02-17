using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCrm.Core.Model;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Core;
using TinyCrm.Core.Model.Options;
using Autofac;

namespace TinyCrmWeb.Controllers
{
   
    public class ProductController : Controller
    {
        
        private TinyCrmDbContext Context { get; set; }

        private TinyCrm.Core.Services.IProductService products_;


        public ProductController(TinyCrmDbContext context, TinyCrm.Core.Services.ProductService products)
        {
            Context = context;
            products_ = products;
        }
        public IActionResult Index()
        {
            var productList = Context
                .Set<Product>()
                .Take(100)
                .ToList();

            return View(productList);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CreateProductViewModel model)
        {
            var result = products_.AddProduct(model?.CreateOptions);

            return View(model);
        }

    }
}

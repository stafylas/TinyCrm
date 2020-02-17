using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyCrmWeb.Models
{
    public class CreateProductViewModel
    {
        public TinyCrm.Core.Model.Options.AddProductOptions CreateOptions { get; set; }
        public string ErrorText { get; set; }

        public string Name { get; set; }
    }
}

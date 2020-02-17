using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyCrmWeb.Models
{
    public class CreateCustomerViewModel
    {
        public TinyCrm.Core.Model.Options.CreateCustomerOptions CreateOptions { get; set; }
        public string ErrorText { get; set; }
    }
}

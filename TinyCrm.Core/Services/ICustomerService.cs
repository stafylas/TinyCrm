using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
  public  interface ICustomerService
    {
        public bool CreateCustomer(Model.Options.CreateCustomerOptions options);
        ICollection<Model.Customer> SearchCustomer(SearchCustomerOptions options);
        public bool UpdateCustomer(string CustomerId, UpdateCustomerOptions options);
    }
}

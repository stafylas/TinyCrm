using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model.Options
{
   public class SearchCustomerOptions
    {
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public DateTimeOffset CreatedFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
       public DateTimeOffset CreateTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }
}

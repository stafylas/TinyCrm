using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model
{
   public class Order
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress { get; set; }

        //public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Order()
        {
            //Products = new list <OrderProduct>();
        }
    }
}

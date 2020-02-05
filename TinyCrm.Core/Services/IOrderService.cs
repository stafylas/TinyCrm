using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services
{
    interface IOrderService
    {
        public bool updateOrder(string orderId);

        public Order getOrderbyId(string orderId);
     }
}

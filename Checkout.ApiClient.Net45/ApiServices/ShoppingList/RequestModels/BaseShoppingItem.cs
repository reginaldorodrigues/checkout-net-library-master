using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class BaseShoppingItem
    {
        public Drink Drink { get; set; }

        public int Quantity { get; set; }
    }
}

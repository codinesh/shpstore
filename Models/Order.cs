using System;
using System.Collections.Generic;
using Groc.Areas.Identity.Data;

namespace Groc.Models
{
    public class Order : BaseModel
    {
        public int UserId {get;set;}

        public virtual GroceriesUser User {get;set;}

        public virtual List<OrderLineItem> OrderLineItem {get;set;}
 
        public float OrderTotal {get;set;}
    }
}
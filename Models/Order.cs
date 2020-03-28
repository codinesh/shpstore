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

    public class OrderLineItem : BaseModel {
        public int OrderId {get;set;}

        public int ItemId {get;set;}

        public float ItemQuantity {get;set;}

        public float Price {get;set;}

        public virtual Inventory Item {get;set;}

        public virtual Order Order {get;set;}
    }
}
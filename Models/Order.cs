using System;
using System.Collections.Generic;
using Groc.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Groc.Models
{
    public class OrderHeader : BaseModel
    {
        public int UserId { get; set; }

        public virtual GroceriesUser User { get; set; }

        public virtual List<OrderLineItem> OrderLineItem { get; set; }

        public float OrderTotal { get; set; }

        [Display(Name = "OrderStatus")]
        public OrderStatus Status { get; set; }
    }
}
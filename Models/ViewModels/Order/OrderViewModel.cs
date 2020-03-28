using System.Collections.Generic;

namespace Groc.Models.ViewModels.Order
{
    public class OrderViewModel : BaseModel
    {
        public int ItemId {get;set;}

        public float ItemQuantity {get;set;}

        public ICollection<Inventory> Item {get;set;}
    }
}
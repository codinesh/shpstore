namespace Groc.Models
{
    public class Availability : BaseModel
    {
        public int InventoryId { get; set; }

        public int AvailableQuantity { get; set; }

        public bool IsActive { get; set;}
    }
}
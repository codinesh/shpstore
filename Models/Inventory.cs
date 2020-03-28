namespace Groc.Models
{

    public class Inventory : BaseModel
    {
        public string Name {get;set;}

        public float PricePerUnit {get;set;}

        public UnitType UnitType {get;set;}
 
        public ItemCategory Category {get;set;}
    }
}
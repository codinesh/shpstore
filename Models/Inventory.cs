using System;
using System.ComponentModel.DataAnnotations;

namespace Groc.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }

        public int CreatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class Inventory : BaseModel
    {
        public string Name {get;set;}

        public float PricePerUnit {get;set;}

        public UnitType UnitType {get;set;}
 
        public ItemCategory Category {get;set;}
    }

    public enum UnitType {
        Kilo,
        
        Liter,

        Quantity
    }

    public enum ItemCategory {
        None,
        
        Vegetables,

        Fruits,

        FoodAndNutrition,

        Medical
    }
}
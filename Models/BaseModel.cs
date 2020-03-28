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
}
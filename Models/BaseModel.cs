using System;
using System.ComponentModel.DataAnnotations;

namespace Groc.Models
{
    public class BaseModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        public int CreatedByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}
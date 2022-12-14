using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}

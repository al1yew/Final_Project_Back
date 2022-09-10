using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Address : BaseModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsMain { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}

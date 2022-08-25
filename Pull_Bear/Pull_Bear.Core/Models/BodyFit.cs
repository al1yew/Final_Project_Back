using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class BodyFit : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }


        //relations one bodyfit - many ...
        public List<Product> Products { get; set; }


        //relations one ... - many bodyfits
        public Gender Gender { get; set; }
        public Nullable<int> GenderId { get; set; }
    }
}

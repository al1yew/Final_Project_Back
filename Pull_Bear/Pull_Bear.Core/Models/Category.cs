using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Category : BaseModel
    {
        //dotnet ef migrations add --startup-project ..\Pull_Bear.MVC InitialMigration
        //detnet ef --startup-project ..\Pull_Bear.MVC database update   
        //amma men adi kimi yazdim ishledi
        //Add-Migration InitialMigration2 -Project Pull_Bear.Data        Remove-Migration -Project Pull_Bear.Data      Update-Database
        public string Name { get; set; }

        public bool IsMain { get; set; }

        public Nullable<int> ParentId { get; set; }

        public Category Parent { get; set; }

        public IEnumerable<Category> Children { get; set; }

    }
}

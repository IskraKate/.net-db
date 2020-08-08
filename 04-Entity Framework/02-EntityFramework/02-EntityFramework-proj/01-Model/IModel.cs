using System.Collections.Generic;
using System.Data.Entity;

namespace HumanResourcesDepartment.ModelNamespace
{
     public  interface IModel
    {
        DbSet<PersonInfo> People { get; set; }
        void Insert(PersonInfo personInfo);
    }
}

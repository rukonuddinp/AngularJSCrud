using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_Crud_Angularjs.Data
{
    public class Mvc_Crud_AngularjsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Mvc_Crud_AngularjsContext() : base("name=Mvc_Crud_AngularjsContext")
        {
        }

        public System.Data.Entity.DbSet<Mvc_Crud_Angularjs.Models.PlayerInfo> PlayerInfoes { get; set; }
        public System.Data.Entity.DbSet<Mvc_Crud_Angularjs.Models.Country> Countrys { get; set; }
    }
}

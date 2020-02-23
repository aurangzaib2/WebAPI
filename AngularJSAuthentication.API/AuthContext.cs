using AngularJSAuthentication.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API
{
public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);

        //}

        public System.Data.Entity.DbSet<AngularJSAuthentication.API.Models.Ticket> Ticket { get; set; }
    }
}
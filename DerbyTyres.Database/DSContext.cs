using Microsoft.AspNet.Identity.EntityFramework;
using DerbyTyres.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerbyTyres.Database
{
    public class DSContext :IdentityDbContext<User>,IDisposable
    {
        public DSContext() : base("DTConnectionStrings")
        {

        }

        public static DSContext Create()
        {
            return new DSContext();
        }

        public DbSet<Tyre> Tyres { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Kutse_App.Models
{
    public class PeoContext: DbContext
    {

        public DbSet<Peo> Peod { get; set; }
    }
}
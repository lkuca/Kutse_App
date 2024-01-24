using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Kutse_App.Models
{
    public class GuestDBinitializer: CreateDatabaseIfNotExists<Guestcontext>
    {
        protected override void Seed(Guestcontext db)
        {
            base.Seed(db);
        }

    }
}
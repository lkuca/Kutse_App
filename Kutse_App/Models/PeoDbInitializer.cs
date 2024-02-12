using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
    public class PeoDBinitializer: CreateDatabaseIfNotExists<PeoContext>
    {
        protected override void Seed(PeoContext dabik)
        {
            base.Seed(dabik);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Kutse_App.Models
{
    public class PeoDbInitializer : CreateDatabaseIfNotExists<PeoContext>
    {
        protected override void Seed(PeoContext dabik)
        {
            base.Seed(dabik);
        }
    }
}
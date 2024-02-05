using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Kutse_App.Models
{
    public class Peo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sisesta Peo siia")]
        public string Name { get; set; }

    }
}
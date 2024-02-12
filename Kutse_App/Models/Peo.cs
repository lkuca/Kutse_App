using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Kutse_App.Models
{
    public class Peo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Sissesta nimi")]

        public string Nimi { get; set; }


        public bool? WillAttend { get ; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using firstPrjAspCore.Models.RepositorIes;

namespace firstPrjAspCore.Models
{
    public class Etudiant
    {
        public int id { get; set; }
        [Required]

        public string nom { get; set; }
        [Required]

        public string prenome { get; set; }
        [Required]

        public string CIN { get; set; }
        [Required]

        public string Adress { get; set; }
    }
}

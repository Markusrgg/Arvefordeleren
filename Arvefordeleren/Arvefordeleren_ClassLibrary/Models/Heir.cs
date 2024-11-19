using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Heir : Person
    {
        [Required]
        public string Relation {  get; set; }

        [Required]
        public string InheritanceShare { get; set; }
    }
}

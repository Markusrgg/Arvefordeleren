using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Testator : Person 
    {
        [Required]
        public WillType WillType { get; set; }

        [Required]
        public bool MaritalStatus { get; set; }

        [Required]
        public string ForcedInheritance {  get; set; }

        [Required]
        public string FreeInheritance { get; set; }

        [Required]
        public DateTime Date {  get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();
    }
}

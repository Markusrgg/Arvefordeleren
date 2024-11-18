using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Testator : Person 
    {
        public WillType WillType { get; set; }

        public string? MaritalStatus { get; set; }

        public string? ForcedInheritance {  get; set; }

        public string? FreeInheritance { get; set; }

        public DateTime Date {  get; set; }

    }
}

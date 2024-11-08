using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Heir : Person
    {
        public string Relation {  get; set; }

        public string InheritanceShare { get; set; }
    }
}

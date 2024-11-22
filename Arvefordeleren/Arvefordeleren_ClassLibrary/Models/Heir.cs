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
        public Heir(string relation, string inheritanceShare)
        {
            Id = Guid.NewGuid();
            Relation = relation;
            InheritanceShare = inheritanceShare;
        }

        public string? Relation {  get; set; }

        public string? InheritanceShare { get; set; }
    }
}

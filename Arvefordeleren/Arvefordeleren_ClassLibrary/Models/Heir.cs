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
        public Guid Mid { get; set; }
        public Guid Fid { get; set; }

        public RelationType RelationType { get; set; }

        public Heir(){}

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

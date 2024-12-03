using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Heir : Person, ICloneable<Heir>
    {
        //Forældre id så stamtræet kan virke 
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

        public Heir Clone()
        {
            return new Heir()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Address = this.Address,
                Relation = this.Relation,
                InheritanceShare = this.InheritanceShare,
                RelationType = this.RelationType,
                Mid = this.Mid,
                Fid = this.Fid,
            };
        }
    }
}

using Arvefordeleren_ClassLibrary.Enums;
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

        public Heir()
        {
            Id = Guid.NewGuid();
        }
        public Heir Clone()
        {
            return new Heir()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                RelationType = this.RelationType,
                Mid = this.Mid,
                Fid = this.Fid,
                Percent = this.Percent
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Testator : Person, ICloneable<Testator>
    {
        public Testator() 
        {
            Id = Guid.NewGuid();
        }
        public Testator(WillType willType, string maritalStatus, string forcedInheritance, string freeInheritance, DateTime date)
        {
            WillType = willType;
            MaritalStatus = maritalStatus;
            ForcedInheritance = forcedInheritance;
            FreeInheritance = freeInheritance;
            Date = date;
        }

        public WillType WillType { get; set; }

        public string? MaritalStatus { get; set; }

        public string? ForcedInheritance {  get; set; }

        public string? FreeInheritance { get; set; }

    
        public DateTime Date {  get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();

        public Testator Clone()
        {
            return new Testator
            {
                Id = this.Id, 
                WillType = this.WillType,
                MaritalStatus = this.MaritalStatus,
                ForcedInheritance = this.ForcedInheritance,
                FreeInheritance = this.FreeInheritance,
                Date = this.Date,
                Heirs = this.Heirs.Select(heir => heir.Clone()).ToList() 
            };
        }
    }
}

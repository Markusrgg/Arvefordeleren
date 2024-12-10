using Arvefordeleren_ClassLibrary.Enums;
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
            //Lav en unik id-værdi 
            Id = Guid.NewGuid();
        }

        public Testator(WillType willType, RelationType relationType)
        {
            WillType = willType;
            RelationType = relationType;
        }

        public int Percent { get; set; }

        public InheritanceType InheritanceType { get; set; }

        public WillType WillType { get; set; }

        public RelationType RelationType { get; set; }

        public List<Person> Persons { get; set; } = new List<Person>();

        //En liste der indeholder Guids, de unikke værdier 
        public List<Guid> Pids { get; set; } = new List<Guid>(); 

        public Testator Clone()
        {
            //Opret en ny instans af Testor klassen 
            return new Testator
            {
                Id = this.Id,
                WillType = this.WillType,
                RelationType = this.RelationType,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Pids = this.Pids,
                InheritanceType = this.InheritanceType,
                Percent = this.Percent,
                Persons = this.Persons
            };
        }

    }
}

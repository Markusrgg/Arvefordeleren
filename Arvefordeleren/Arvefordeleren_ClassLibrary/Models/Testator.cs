﻿using System;
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

        public Testator(WillType willType, RelationType relationType, string forcedInheritance, string freeInheritance, DateTime date)
        {
            WillType = willType;
            RelationType = relationType;
            ForcedInheritance = forcedInheritance;
            FreeInheritance = freeInheritance;
            Date = date;
        }

        public int Percent { get; set; }

        public InheritanceType InheritanceType { get; set; }

        public WillType WillType { get; set; }

        public RelationType RelationType { get; set; }

        public string? ForcedInheritance {  get; set; }

        public string? FreeInheritance { get; set; }

        public DateTime Date {  get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();

        public List<Person> Persons { get; set; } = new List<Person>();

        public Testator Clone()
        {
            //Opret en ny instans af Testor klassen 
            return new Testator
            {
                Id = this.Id,
                WillType = this.WillType,
                RelationType = this.RelationType,
                ForcedInheritance = this.ForcedInheritance,
                FreeInheritance = this.FreeInheritance,
                Date = this.Date,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Pids = this.Pids,
                Heirs = this.Heirs.Select(heir => heir.Clone()).ToList(),
                InheritanceType = this.InheritanceType,
                Percent = this.Percent,
                Persons = this.Persons
            };
        }

        //En liste der indeholder Guids, de unikke værdier 
        public List<Guid> Pids { get; set; } = new List<Guid>(); 
    }
}

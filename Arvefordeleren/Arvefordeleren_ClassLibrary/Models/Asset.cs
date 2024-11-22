using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class Asset : Model, ICloneable<Asset>
    {
        public Asset()
        {
        }

        public Asset(string separateEstate = "Ingen valgt") 
        {
            Id = Guid.NewGuid();
            SeparateEstate = separateEstate;
        }

        public Asset(string name, double value, string separateEstate) : this(separateEstate)
        {
            Name = name;
            Value = value;
        }
        public string? Name { get; set; }
        public double Value { get; set; }
        public string? SeparateEstate { get; set; }

        public Asset Clone()
        {
            return new Asset
            {
                Id = this.Id,
                Name = this.Name,
                Value = this.Value,
                SeparateEstate = this.SeparateEstate
            };
        }
    }
}

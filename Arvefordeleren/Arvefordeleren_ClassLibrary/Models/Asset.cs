using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arvefordeleren_ClassLibrary.Models
{
    public class Asset : Model, ICloneable<Asset>
    {
        public Asset()
        {
            //En unik id-værdi skal skabes 
            Id = Guid.NewGuid();
        }
        public Asset(Guid id)
        {
            Id = id;
        }
        [Required]
        public string Name { get; set; }
        public string? SeparateEstate { get; set; }

        //Implementering af Clone skaber en ny instans af Asset ved brug af Id. 
        public Asset Clone()
        {
            return new Asset(this.Id)
            {
                Name = this.Name,
                SeparateEstate = this.SeparateEstate
            };
        }
    }
}

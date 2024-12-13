using Arvefordeleren_ClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public abstract class Person : Model
    {
        [Required(ErrorMessage = "Fornavn er påkrævet")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Efternavn er påkrævet")]
        public string? LastName { get; set; }

        public string? FullName => $"{FirstName} {LastName}";

        public int Percent { get; set; }
        public RelationType RelationType { get; set; }

    }
}

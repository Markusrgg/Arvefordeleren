using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public enum RelationType
    {
        [Display(Name = "Gift")]
        MARRIED,
        [Display(Name = "Forældre")]
        PARENT,
        [Display(Name = "Samlever")]
        PARTNER,
        [Display(Name = "Single")]
        INDIVIDUAL,
        [Display(Name = "Fælles Barn")]
        CHILD,
        [Display(Name = "Sær Barn")]
        CHILD_SEPERATE,
        [Display(Name = "Søskende")]
        SIBLING,
        [Display(Name = "Andre")]
        OTHER,
        [Display(Name = "Barnebarn")]
        GRAND_CHILD,
    }
}

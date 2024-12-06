using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public enum InheritanceType
    {
        [Display(Name = "Ligelig fordeling")]
        SPLIT,
        [Display(Name = "50% ægtefælle")]
        FIFTY,
    }
}

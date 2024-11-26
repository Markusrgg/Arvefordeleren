using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public class JointTestators
    {
        [Required]
        public Testator Testator1 { get; set; } = new Testator();

        [Required]
        public Testator Testator2 { get; set; } = new Testator();
    }
}

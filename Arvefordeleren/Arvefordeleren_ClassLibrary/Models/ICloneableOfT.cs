using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
   // Models som skal lagres skal implementere dette interface, for at kunne lave en deep-copy af objektet
   // når de hentes fra Repositories. Istedet for blot at hente en kopi af referencerne til samme objekter.
    public interface ICloneable<T>
    {
        T Clone();
    }
    
}

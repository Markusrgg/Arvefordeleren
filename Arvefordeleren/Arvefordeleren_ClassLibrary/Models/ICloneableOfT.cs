using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
   //Her laves et generisk interface 
    public interface ICloneable<T>
    {
        T Clone();
    }
    
}

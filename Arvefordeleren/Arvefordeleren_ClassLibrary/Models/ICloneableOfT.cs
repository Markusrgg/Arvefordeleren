using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    // Clone interface, forced upon non-abstract methods to allow Repository to deep-copy our _list and not just return reference types to the same objects of the original list.
    public interface ICloneable<T>
    {
        T Clone();
    }
    
}

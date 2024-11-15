using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public static class TestatorRepository
    {
        private static List<Testator> testators = new List<Testator>();

        public static void AddTestator(Testator testator)
        { 
            testators.Add(testator);
        }

       
    }
}

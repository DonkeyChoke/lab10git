using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAnimals
{
    public class AnimalNameComparer : IComparer<Animal>
    {
        public int Compare(Animal a, Animal b)
        {
            return string.Compare(a.Name, b.Name);
        }
    }
}

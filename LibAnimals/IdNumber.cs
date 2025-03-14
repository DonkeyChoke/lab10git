using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAnimals
{
    public class IdNumber
    {
        public int Number { get; set; }

        public IdNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException("Число должно быть не меньше 0.");
            Number = number;
        }

        public override bool Equals(object obj)
        {
            if (obj is IdNumber other)
            {
                return Number == other.Number;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Id: {Number}";
        }
    }
}

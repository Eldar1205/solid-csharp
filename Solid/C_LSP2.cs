using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.C_LSP2
{
    public class Arrays_Violate_Liskov
    {
        public void ThrowsNotSupportedException()
        {
            var numbers = new int[10];
            Work(numbers);
        }

        public void Work(IList<int> numbers)
        {
            numbers.Add(5);
        }
    }
}

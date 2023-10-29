using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class MacierzView
    {
        int wysokoscBufora;
        int szerokoscBufora;
        public MacierzView()
        {
            wysokoscBufora = Console.BufferHeight;
            szerokoscBufora = Console.BufferWidth;
        }
    }
}

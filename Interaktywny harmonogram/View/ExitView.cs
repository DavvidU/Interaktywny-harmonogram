using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class ExitView
    {
        public ExitView() { }
        public void WypiszTekst()
        {
            Console.WriteLine("Czy na pewno chcesz wyjsc?");
            Console.WriteLine("T - Tak  N - Nie");
        }
    }
}

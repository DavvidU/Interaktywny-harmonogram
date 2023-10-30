using Interaktywny_harmonogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class ZadaniaView
    {
        private int wysokoscOkna;
        private int szerokoscOkna;
        public ZadaniaView(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;
        }
        public void WypiszZadania(List<Zadanie> zadaniaDoWyswietlenia)
        {
            foreach (Zadanie zadanie in zadaniaDoWyswietlenia)
            {
                Console.WriteLine(zadanie.naglowek);
                Console.WriteLine(zadanie.opis);
                if (zadanie.pilne)
                    Console.WriteLine("Pilne");
                else
                    Console.WriteLine("Niepilne");
                if (zadanie.wazne)
                    Console.WriteLine("Wazne");
                else
                    Console.WriteLine("Niewazne");
                if (zadanie.wykonane)
                    Console.WriteLine("Wykonane");
                else
                    Console.WriteLine("Niewykonane");
                Console.WriteLine("-----");
            }
        }
        public void WypiszZadania(Miesiac miesiacDoWyswietlenia)
        {
            int wyswietloneZadania = 0;
            foreach (Dzien dzien in miesiacDoWyswietlenia.GetDni())
            {
                if (dzien.GetZadania().Count() > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("+++++");
                    Console.WriteLine(dzien.GetDzien() + "." + miesiacDoWyswietlenia.GetMiesiac());
                    Console.WriteLine("+++++");
                    Console.WriteLine();
                }

                foreach (Zadanie zadanie in dzien.GetZadania())
                {
                    wyswietloneZadania++;
                    Console.WriteLine(zadanie.naglowek);
                    Console.WriteLine(zadanie.opis);
                    if (zadanie.pilne)
                        Console.WriteLine("Pilne");
                    else
                        Console.WriteLine("Niepilne");
                    if (zadanie.wazne)
                        Console.WriteLine("Wazne");
                    else
                        Console.WriteLine("Niewazne");
                    if (zadanie.wykonane)
                        Console.WriteLine("Wykonane");
                    else
                        Console.WriteLine("Niewykonane");
                    Console.WriteLine("-----");
                }
            }
            if(wyswietloneZadania == 0)
                Console.WriteLine("Brak zadań w tym miesiącu.");
        }
    }
}

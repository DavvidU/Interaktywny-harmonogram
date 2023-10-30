using Interaktywny_harmonogram.Model;
using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class ZadaniaController
    {
        private static ZadaniaController instance = new ZadaniaController();
        private ZadaniaController() { }
        public void ZadaniaViewListener(List<Zadanie>? zadaniaDoWyswietlenia, Miesiac? miesiacDoWyswietlenia)
        {
            Console.Clear();
            //Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo cki;

            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;

            ZadaniaView zv = new ZadaniaView(wysokoscOkna, szerokoscOkna);
            if (zadaniaDoWyswietlenia != null)
                zv.WypiszZadania(zadaniaDoWyswietlenia);
            if (miesiacDoWyswietlenia != null)
                zv.WypiszZadania(miesiacDoWyswietlenia);

            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowHeight != wysokoscOkna || Console.WindowWidth != szerokoscOkna)
                    {
                        wysokoscOkna = Console.WindowHeight;
                        szerokoscOkna = Console.WindowWidth;
                        //zv.AktualizujRozdzielczosc(wysokoscOkna, szerokoscOkna);
                        Console.Clear();
                        try
                        {
                            if (zadaniaDoWyswietlenia != null)
                                zv.WypiszZadania(zadaniaDoWyswietlenia);
                            if (miesiacDoWyswietlenia != null)
                                zv.WypiszZadania(miesiacDoWyswietlenia);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                }

                cki = Console.ReadKey(true);
                ObsluzInputUsera(cki);

            } while (true);
        }
        private void ObsluzInputUsera(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Escape)
            {
                MenuController menuController = MenuController.GetInstance();
                menuController.MenuViewListener();
            }
        }
        public static ZadaniaController GetInstance() { return instance; }
    }
}

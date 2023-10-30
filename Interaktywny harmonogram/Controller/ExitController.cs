using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class ExitController
    {
        private static ExitController instance = new ExitController();
        private ExitController() { }
        public void ExitViewListener()
        {
            Console.Clear();
            //Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo cki;

            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;

            ExitView ev = new ExitView();
            ev.WypiszTekst();

            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowHeight != wysokoscOkna || Console.WindowWidth != szerokoscOkna)
                    {
                        wysokoscOkna = Console.WindowHeight;
                        szerokoscOkna = Console.WindowWidth;

                        Console.Clear();
                        try
                        {
                            ev.WypiszTekst();
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                }

                cki = Console.ReadKey(true);
                OblsuzInputUsera(cki);

            } while (true);
        }
        private void OblsuzInputUsera(ConsoleKeyInfo input)
        {
            if(input.Key == ConsoleKey.T)
            {
                Environment.Exit(0);
            }
            else if(input.Key == ConsoleKey.N)
            {
                MenuController menuController = MenuController.GetInstance();
                menuController.MenuViewListener();

            }
        }
        public static ExitController GetInstance() { return instance; }
    }
}

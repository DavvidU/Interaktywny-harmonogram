using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class MenuController
    {
        public static MenuController Instance = new MenuController();
        private MenuController() { }
        public void MenuViewListener()
        {
            ConsoleKeyInfo cki; //wcisniety przycisk w konsoli (np. x albo ctrl + C)

            // Obsługa CTRL + C i CTRL + BREAK
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            // Okreslenie aktualnej rozdzielczosci do wypelnienia
            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;
            
            MenuView  mv = new MenuView(wysokoscOkna, szerokoscOkna);
            mv.Rysuj();

            do
            {
                if (Console.WindowHeight != wysokoscOkna || Console.WindowWidth != szerokoscOkna)
                {
                    wysokoscOkna = Console.WindowHeight;
                    szerokoscOkna = Console.WindowWidth;
                    mv.AktualizujRozdzielczosc(wysokoscOkna, szerokoscOkna);
                    Console.Clear();
                    mv.Rysuj();
                }

            }while(true);
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }

        public static MenuController GetInstance() { return Instance; }
    }
}

using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class MenuController
    {
        public static MenuController Instance = new MenuController();
        private MenuController() { }
        
        // Poruszanie sie po menu
        int pozycjaWskaznikaKolumna = 0;
        int pozycjaWskaznikaWiersz = 0;
        public void MenuViewListener()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            ConsoleKeyInfo cki; //wcisniety przycisk w konsoli (np. x albo ctrl + C)

            

            // Okreslenie aktualnej rozdzielczosci do wypelnienia
            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;

            //Task sprawdzanieRozdzielczosci = new Task(sprawdzRozdzielczosc, wysokoscOkna);
            
            MenuView  mv = new MenuView(wysokoscOkna, szerokoscOkna);
            mv.RysujTlo();
            mv.WypiszTekst();
            mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);

            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowHeight != wysokoscOkna || Console.WindowWidth != szerokoscOkna)
                    {
                        wysokoscOkna = Console.WindowHeight;
                        szerokoscOkna = Console.WindowWidth;
                        mv.AktualizujRozdzielczosc(wysokoscOkna, szerokoscOkna);
                        Console.Clear();
                        try
                        {
                            mv.RysujTlo();
                            mv.WypiszTekst();
                            mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                }
                
                cki = Console.ReadKey(true);
                ObsluzInputUsera(cki, mv);

            } while(true);
        }
        private void ObsluzInputUsera(ConsoleKeyInfo input, MenuView mv)
        {
            if (input.Key == ConsoleKey.RightArrow || input.Key == ConsoleKey.D)
            {
                pozycjaWskaznikaKolumna = 1;
                mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.S)
            {
                pozycjaWskaznikaWiersz = 1;
                mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.A)
            {
                pozycjaWskaznikaKolumna = 0;
                mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.W)
            {
                pozycjaWskaznikaWiersz = 0;
                mv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.D1 || (input.Key == ConsoleKey.Enter && pozycjaWskaznikaKolumna == 0
                                                    && pozycjaWskaznikaWiersz == 0))
            {
                MacierzController macierzController = MacierzController.GetInstance();
                macierzController.MacierzViewListener();
            }
            else if (input.Key == ConsoleKey.D2 || (input.Key == ConsoleKey.Enter && pozycjaWskaznikaKolumna == 1
                                                    && pozycjaWskaznikaWiersz == 0))
            {
                KalendarzController kalendarzController = KalendarzController.GetInstance();
                kalendarzController.KalendarzViewListener();
            }
            else if (input.Key == ConsoleKey.D3 || (input.Key == ConsoleKey.Enter && pozycjaWskaznikaKolumna == 0
                                                    && pozycjaWskaznikaWiersz == 1))
            {
                ConfigController configController = ConfigController.GetInstance();
                configController.ConfigViewListener();
            }
            else if (input.Key == ConsoleKey.D4 || (input.Key == ConsoleKey.Enter && pozycjaWskaznikaKolumna == 1
                                                    && pozycjaWskaznikaWiersz == 1))
            {
                ExitController exitController = ExitController.GetInstance();
                exitController.ExitViewListener();
            }
        }
        public static MenuController GetInstance() { return Instance; }
    }
}
using Interaktywny_harmonogram.Model;
using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class MacierzController
    {
        private static MacierzController instance = new MacierzController();
        private MacierzController() { }
        // Poruszanie sie po menu
        int pozycjaWskaznikaKolumna = 0;
        int pozycjaWskaznikaWiersz = 0;
        public void MacierzViewListener()
        {
            Console.Clear();

            ConsoleKeyInfo cki;

            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;

            MacierzView kv = new MacierzView(wysokoscOkna, szerokoscOkna);
            kv.RysujTlo();
            kv.WypiszTekstMacierzy();
            kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);

            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowHeight != wysokoscOkna || Console.WindowWidth != szerokoscOkna)
                    {
                        wysokoscOkna = Console.WindowHeight;
                        szerokoscOkna = Console.WindowWidth;
                        kv.AktualizujRozdzielczosc(wysokoscOkna, szerokoscOkna);
                        Console.Clear();
                        try
                        {
                            kv.RysujTlo();
                            kv.WypiszTekstMacierzy();
                            kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                }

                cki = Console.ReadKey(true);
                ObsluzInputUsera(cki, kv);

            } while (true);
        }
        private void ObsluzInputUsera(ConsoleKeyInfo input, MacierzView kv)
        {
            if (input.Key == ConsoleKey.RightArrow || input.Key == ConsoleKey.D)
            {
                pozycjaWskaznikaKolumna = 1;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.S)
            {
                pozycjaWskaznikaWiersz = 1;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.A)
            {
                pozycjaWskaznikaKolumna = 0;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.W)
            {
                pozycjaWskaznikaWiersz = 0;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                List<Zadanie> zadaniaDoWyswietlenia;
                if (pozycjaWskaznikaKolumna == 0 && pozycjaWskaznikaWiersz == 0)
                {
                    zadaniaDoWyswietlenia = DostepDoDanychController.GetZadania("PW");
                }
                else if (pozycjaWskaznikaKolumna == 1 && pozycjaWskaznikaWiersz == 0)
                {
                    zadaniaDoWyswietlenia = DostepDoDanychController.GetZadania("NW");
                }
                else if (pozycjaWskaznikaKolumna == 0 && pozycjaWskaznikaWiersz == 1)
                {
                    zadaniaDoWyswietlenia = DostepDoDanychController.GetZadania("PN");
                }
                else if (pozycjaWskaznikaKolumna == 1 && pozycjaWskaznikaWiersz == 1)
                {
                    zadaniaDoWyswietlenia = DostepDoDanychController.GetZadania("NN");
                }
                else
                {
                    zadaniaDoWyswietlenia = DostepDoDanychController.GetZadania("PW");
                }
                ZadaniaController zadaniaController = ZadaniaController.GetInstance();
                zadaniaController.ZadaniaViewListener(zadaniaDoWyswietlenia, null);
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                MenuController menuController = MenuController.GetInstance();
                menuController.MenuViewListener();
            }
        }
        public static MacierzController GetInstance() { return instance; }
    }
}

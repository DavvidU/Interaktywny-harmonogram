using Interaktywny_harmonogram.Model;
using Interaktywny_harmonogram.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class KalendarzController
    {
        DateTime aktualna_data;
        private static KalendarzController instance = new KalendarzController();
        private KalendarzController() { }
        // Poruszanie sie po menu
        int pozycjaWskaznikaKolumna = 0;
        int pozycjaWskaznikaWiersz = 0;

        int wyswietlanyMiesiac;
        int wyswietlanyRok;

        List<int[]> wybraneDni;
        public void KalendarzViewListener()
        {
            Console.Clear();
            //Console.SetCursorPosition(0, 0);
            aktualna_data = DateTime.Now;

            wyswietlanyMiesiac = aktualna_data.Month;
            wyswietlanyRok = aktualna_data.Year;

            ConsoleKeyInfo cki;

            int wysokoscOkna = Console.WindowHeight;
            int szerokoscOkna = Console.WindowWidth;

            KalendarzView kv = new KalendarzView(wysokoscOkna, szerokoscOkna, wyswietlanyRok, wyswietlanyMiesiac);
            kv.RysujTlo();
            kv.WypiszTekstKalendarza();
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
                            kv.WypiszTekstKalendarza();
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
        private void ObsluzInputUsera(ConsoleKeyInfo input, KalendarzView kv)
        {
            if (input.Key == ConsoleKey.RightArrow || input.Key == ConsoleKey.D)
            {
                pozycjaWskaznikaKolumna = (pozycjaWskaznikaKolumna + 1) % 7;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.S)
            {
                pozycjaWskaznikaWiersz = (pozycjaWskaznikaWiersz + 1) % 7;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.A)
            {
                pozycjaWskaznikaKolumna = (pozycjaWskaznikaKolumna - 1);
                if (pozycjaWskaznikaKolumna == -1)
                    pozycjaWskaznikaKolumna = 6;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.W)
            {
                pozycjaWskaznikaWiersz = pozycjaWskaznikaWiersz - 1;
                if (pozycjaWskaznikaWiersz == -1)
                    pozycjaWskaznikaWiersz = 6;
                kv.RysujWskaznik(pozycjaWskaznikaKolumna, pozycjaWskaznikaWiersz);
            }
            else if (input.Key == ConsoleKey.Q)
            {
                --wyswietlanyMiesiac;
                if (wyswietlanyMiesiac == 0)
                {
                    wyswietlanyMiesiac = 12;
                    --wyswietlanyRok;
                }
                if (wyswietlanyRok < 2022)
                {
                    MenuController menuController = MenuController.GetInstance();
                    menuController.MenuViewListener();
                }
                kv.AktualizujDate(wyswietlanyRok, wyswietlanyMiesiac);
                kv.WypiszTekstKalendarza();
            }
            else if (input.Key == ConsoleKey.E)
            {
                ++wyswietlanyMiesiac;
                if (wyswietlanyMiesiac == 13)
                {
                    wyswietlanyMiesiac = 1;
                    ++wyswietlanyRok;
                }
                if (wyswietlanyRok > 2031)
                {
                    MenuController menuController = MenuController.GetInstance();
                    menuController.MenuViewListener();
                }
                kv.AktualizujDate(wyswietlanyRok, wyswietlanyMiesiac);
                kv.WypiszTekstKalendarza();
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                Miesiac miesiacDoWyswietlenia;
                miesiacDoWyswietlenia = DostepDoDanychController.GetMiesiac(wyswietlanyMiesiac, wyswietlanyRok);

                ZadaniaController zadaniaController = ZadaniaController.GetInstance();
                zadaniaController.ZadaniaViewListener(null, miesiacDoWyswietlenia);
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                MenuController menuController = MenuController.GetInstance();
                menuController.MenuViewListener();
            }
        }
        public static KalendarzController GetInstance() { return instance; }
    }
}

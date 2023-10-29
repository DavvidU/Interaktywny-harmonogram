using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class MenuView
    {
        /*
         * Calkowita szerokosc bufora menu = 12x + 4
         * 
         * Absolutnie zarezerwowane 4 kolumny
         * Szerokosc do podzialu relatywnego = szerokoscOkna - 4
         * 
         * 12x = szerokoscOkna - 4
         * Dla macierzy: 4x = szerokoscOkna/3 - 4/3
         * Dla kalendarza: 8x = szerokoscOkna/1,5 - 4/1,5
         * 
         * W rzeczywistości:
         * Dla macierzy: 4x = szerokoscOkna/3 - 1
         * Dla kalendarza: 8x = reszta - 4 (4x - 4)
         * 
         * gdzie x = szerokosc komorki dnia.
         * Na macierz przypada 4x, a na kalendarz 8x
         * + Po dwie kolumny na lewy i prawy padding obu
         * 
         * Ostatecznie szerokosc macierzy = 1/3*SO, szerokoscKal. = 2/3*SO - 4
         */

        // Wymiary Okna
        private int wysokoscOkna;
        private int szerokoscOkna;

        // Wymiary Macierzy
        private int wysokoscMacierzy;
        private int szerokoscMacierzy;

        // Wymiary Kalendarza
        private int wysokoscKalendarza;
        private int szerokoscKalendarza;

        // Wymiary Config
        private int wysokoscConfig;
        private int szerokoscConfig;

        // Wymiary Exit
        private int wysokoscExit;
        private int szerokoscExit;
        public MenuView(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;
            
            szerokoscMacierzy = szerokoscOkna / 3;
            szerokoscKalendarza = szerokoscOkna - szerokoscMacierzy - 4;
            szerokoscConfig = szerokoscMacierzy;
            szerokoscExit = szerokoscKalendarza;

            wysokoscExit = wysokoscOkna / 5;
            wysokoscConfig = wysokoscExit;
            wysokoscKalendarza = wysokoscOkna - wysokoscExit - 4;
            wysokoscMacierzy = wysokoscKalendarza;

        }
        public void Rysuj()
        { 
            // Pierwszy wiersz:' 1------------ ' '2 ----------------------- ' '
            Console.WriteLine();
            Console.Write(' ');
            Console.Write(1);
            for (int i = 1; i < szerokoscMacierzy - 4; ++i)
            {
                Console.Write('═');
            }
            Console.Write('\\');
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(2);
            for (int i = 1; i < szerokoscKalendarza - 4; ++i)
            {
                Console.Write('═');
            }
            Console.Write('\\');
            Console.Write(' ');
            Console.Write(' ');
            Console.WriteLine();
            // Od drugiego wiersza pionowe (+ ukosne) linie W zaleznosci czy macierz czy kalendarz
            // Dla wszystkich wierszy do konca macierzy i kalendarza (frontowej wysokosci)
            for (int i = 0; i < wysokoscMacierzy - 3; ++i)
            {
                //Idz po wierszach
                Console.Write(' ');
                // W zakresie macierzy ------------------
                for (int j = 0; j < szerokoscMacierzy - 4; ++j)
                {
                    if (j == 0 || j == (szerokoscMacierzy - 4) / 2 || j == szerokoscMacierzy - 5)
                        Console.Write('║');
                    else if (i == (wysokoscMacierzy - 3) / 2 || i == wysokoscMacierzy - 4) //Jesli nie pisz kolumny i w srodku macierzy to przedzialka
                        Console.Write('═');
                    else
                        Console.Write(' ');
                }
                //Padding macierzy --------------------
                if (i == 0)
                {
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if (i == 1)
                {
                    Console.Write(' ');
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(' ');
                    Console.Write(' ');
                    Console.Write('|');
                    Console.Write(' ');
                }
                //W zakresie kalendarza ---------------
                for (int j = 0; j < szerokoscKalendarza - 4; ++j)
                {
                    if (j == 0 || j == (szerokoscKalendarza - 4) /7 || 
                        j == ((szerokoscKalendarza - 4) * 2) / 7 ||
                        j == ((szerokoscKalendarza - 4) * 3) / 7 ||
                        j == ((szerokoscKalendarza - 4) * 4) / 7 ||
                        j == ((szerokoscKalendarza - 4) * 5) / 7 ||
                        j == ((szerokoscKalendarza - 4) * 6) / 7 || j == szerokoscKalendarza - 5)
                        Console.Write('║');
                    else if (i == (wysokoscKalendarza - 3) / 7 ||
                        i == ((wysokoscKalendarza - 3) * 2) / 7 ||
                        i == ((wysokoscKalendarza - 3) * 3) / 7 ||
                        i == ((wysokoscKalendarza - 3) * 4) / 7 ||
                        i == ((wysokoscKalendarza - 3) * 5) / 7 ||
                        i == ((wysokoscKalendarza - 3) * 6) / 7 || i == wysokoscKalendarza - 4)
                        Console.Write('═');
                    else
                        Console.Write(' ');
                }
                //Padding Kalendarza ----------
                if (i == 0)
                {
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if (i == 1)
                {
                    Console.Write(' ');
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(' ');
                    Console.Write(' ');
                    Console.Write('|');
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            // Dolny padding Macierzy i Kalendarza

            // For ( int P;) dla 3 wierszy Paddingu Dolnego M i K
            for (int P = 0; P < 3; ++P)
            {
                Console.Write(' ');
                // Przejscie po froncie macierzy (M - 4) z Paddingiem (+ 4 )
                for (int j = 0; j < szerokoscMacierzy; ++j)
                {
                    if (j == 0 + P || j == szerokoscMacierzy - 5 + P)
                        Console.Write('\\');
                    else if (j == szerokoscMacierzy - 2) //Przedostatni Padding
                        Console.Write('|');
                    else if (P == 2 && j > 2 && j != szerokoscMacierzy - 1)
                        Console.Write('-');
                    else
                        Console.Write(' ');
                }
                // Przejscie po froncie Kalendarza (K - 4) z Paddingiem (+4)
                for (int j = 0; j < szerokoscKalendarza; ++j)
                {
                    if (j == 0 + P || j == szerokoscKalendarza - 5 + P)
                        Console.Write('\\');
                    else if (j == szerokoscKalendarza - 2)
                        Console.Write('|');
                    else if (P == 2 && j > 2 && j != szerokoscKalendarza - 1)
                        Console.Write('-');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            // Teraz Padding Gorny dla Config i Exit
            Console.WriteLine();
        }
        public void AktualizujRozdzielczosc(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;

            szerokoscMacierzy = szerokoscOkna / 3;
            szerokoscKalendarza = szerokoscOkna - szerokoscMacierzy - 4;
            szerokoscConfig = szerokoscMacierzy;
            szerokoscExit = szerokoscKalendarza;

            wysokoscExit = wysokoscOkna / 5;
            wysokoscConfig = wysokoscExit;
            wysokoscKalendarza = wysokoscOkna - wysokoscExit - 4;
            wysokoscMacierzy = wysokoscKalendarza;
        }
    }
}

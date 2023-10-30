using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class MacierzView
    {
        private int wysokoscOkna;
        private int szerokoscOkna;

        private int wysokoscMacierzy;
        private int szerokoscMacierzy;

        private int wysokoscKomorkiKategorii;
        private int szerokoscKomorkiKategorii;
        public MacierzView(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;

            szerokoscMacierzy = szerokoscOkna - 6; // Paddingi: 3, 3
            wysokoscMacierzy = wysokoscOkna - 4; // Paddingi: 1, 3

            wysokoscKomorkiKategorii = (wysokoscMacierzy - 3 - 3) / 2;
            szerokoscKomorkiKategorii = (szerokoscMacierzy - 3 - 3) / 2;
        }
        public void RysujTlo()
        {
            // Padding Gorny Kalendarza

            Console.WriteLine();

            // Przejscie wierszami od Pierwszego Wiersza Kalendarza do Ostatniego Wiersza Kal. przed Paddingiem dolnym

            for (int i = 0; i < wysokoscMacierzy - 3; ++i)
            {
                // Lewy Padding szerokosci
                for(int j = 0; j < 3; ++j)
                    Console.Write(' ');

                // Przejscie przez szerokosc Macierzy
                for (int j = 0; j < szerokoscMacierzy - 3; ++j)
                {
                    if (i == 0 || i == wysokoscMacierzy - 4)
                        Console.Write('═');
                    else if (j == 0 || j == (szerokoscMacierzy - 3) / 2 || j == szerokoscMacierzy - 4)
                        Console.Write('║');
                    else if (i == (wysokoscMacierzy - 3) / 2 || i == wysokoscMacierzy - 3)
                        Console.Write('═');
                    else
                        Console.Write(' ');
                }

                // Przejscie przez prawe 2D Macierzy
                //for(int j = 0; j < 3; ++j)
                //{
                if (i == 0)
                {
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if (i == 1)
                {
                    Console.Write(' ');
                    Console.Write('\\');
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if (i == 2)
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
                    Console.Write(' ');
                    Console.Write('|');
                }

                // Prawy Padding szerokosci
                for (int j = 0; j < 2; ++j)
                    Console.Write(' ');

                Console.WriteLine();
            }

            // Przejscie pod Macierz

            // Przejscie przez Dolne 2D Kalendarza 
            for (int i = 0; i < 3; ++i) // Dla 3 wierszy
            {
                for (int j = 0; j < 3; ++j) //Lewy padding
                    Console.Write(' '); 

                for (int j = 0; j <= szerokoscMacierzy; ++j)
                {
                    if (j == i)
                        Console.Write('\\');
                    else if (j == szerokoscMacierzy)
                        Console.Write('|');
                    else if (j == szerokoscMacierzy - 3 + i)
                        Console.Write('\\');
                    else if (i == 2 && j > 2)
                        Console.Write('-');
                    else
                        Console.Write(' ');

                }
                Console.WriteLine();
            }
        }
        public void WypiszTekstMacierzy()
        {
            for (int i = 0; i < 2; ++i)
            {
                // Ustalanie wiersza kursora
                Console.CursorTop = 2 + i * wysokoscKomorkiKategorii + i;

                // Dla kazdej kolumny w wierszu
                for (int j = 0; j < 2; ++j)
                {
                    // Ustalanie kolumny kursora
                    Console.CursorLeft = 5 + 2 + j * szerokoscKomorkiKategorii;

                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (szerokoscOkna > 60)
                                Console.Write("Pilne Ważne");
                            else
                                Console.Write("PW");
                        }
                        else
                        {
                            if (szerokoscOkna > 60)
                                Console.Write("Niepilne Ważne");
                            else
                                Console.Write("NW");
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (szerokoscOkna > 60)
                                Console.Write("Pilne Nieważne");
                            else
                                Console.Write("PN");
                        }
                        else
                        {
                            if (szerokoscOkna > 60)
                                Console.Write("Niepilne Nieważne");
                            else
                                Console.Write("NN");
                        }
                    }
                }
            }
        }
        public void RysujWskaznik(int pozycjaWskaznikaKolumna, int pozycjaWskaznikaWiersz)
        {
            // Wyczysc lewa gore
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 3; ++i)
                Console.Write(' ');
            Console.SetCursorPosition(0, 1);
            Console.Write(' ');
            Console.SetCursorPosition(0, 2);
            Console.Write(' ');

            // Wyczysc prawo gore
            Console.SetCursorPosition(Console.WindowWidth - 3, 0);
            for (int i = 0; i < 3; ++i)
                Console.Write(' ');
            Console.SetCursorPosition(Console.WindowWidth - 1, 1);
            Console.Write(' ');
            Console.SetCursorPosition(Console.WindowWidth - 1, 2);
            Console.Write(' ');

            // Wyczysc lewy dol
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            for (int i = 0; i < 3; ++i)
                Console.Write(' ');
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write(' ');
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write(' ');

            // Wyczysc prawy dol
            Console.SetCursorPosition(Console.WindowWidth - 3, Console.WindowHeight - 1);
            for (int i = 0; i < 3; ++i)
                Console.Write(' ');
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 2);
            Console.Write(' ');
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
            Console.Write(' ');

            // Rysuj aktualny wskaznik

            if (pozycjaWskaznikaKolumna == 0 && pozycjaWskaznikaWiersz == 0)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 3; ++i)
                    Console.Write('*');
                Console.SetCursorPosition(0, 1);
                Console.Write('*');
                Console.SetCursorPosition(0, 2);
                Console.Write('*');
            }
            if (pozycjaWskaznikaKolumna == 1 && pozycjaWskaznikaWiersz == 0)
            {
                Console.SetCursorPosition(Console.WindowWidth - 3, 0);
                for (int i = 0; i < 3; ++i)
                    Console.Write('*');
                Console.SetCursorPosition(Console.WindowWidth - 1, 1);
                Console.Write('*');
                Console.SetCursorPosition(Console.WindowWidth - 1, 2);
                Console.Write('*');
            }
            if (pozycjaWskaznikaKolumna == 0 && pozycjaWskaznikaWiersz == 1)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                for (int i = 0; i < 3; ++i)
                    Console.Write('*');
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write('*');
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.Write('*');
            }
            if (pozycjaWskaznikaKolumna == 1 && pozycjaWskaznikaWiersz == 1)
            {
                Console.SetCursorPosition(Console.WindowWidth - 3, Console.WindowHeight - 1);
                for (int i = 0; i < 3; ++i)
                    Console.Write('*');
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 2);
                Console.Write('*');
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
                Console.Write('*');
            }
        }
        public void AktualizujRozdzielczosc(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;

            szerokoscMacierzy = szerokoscOkna - 6; // Paddingi: 3, 3
            wysokoscMacierzy = wysokoscOkna - 4; // Paddingi: 1, 3

            wysokoscKomorkiKategorii = (wysokoscMacierzy - 3 - 3) / 2;
            szerokoscKomorkiKategorii = (szerokoscMacierzy - 3 - 3) / 2;
        }
    }
}

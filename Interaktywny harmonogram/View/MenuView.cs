using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            szerokoscKalendarza = szerokoscOkna - szerokoscMacierzy - 4; //szerokosc kalendarza
            szerokoscConfig = szerokoscMacierzy;
            szerokoscExit = szerokoscKalendarza;

            wysokoscExit = wysokoscOkna / 5;
            wysokoscConfig = wysokoscExit;
            wysokoscKalendarza = wysokoscOkna - wysokoscExit - 4;
            wysokoscMacierzy = wysokoscKalendarza;

        }
        public void RysujTlo()
        {
            /*
             * 
             * 
             * Macierz + Kalendarz
             * 
             * 
             */

            // Padding Gorny Macierzy i Kalendarza

            Console.WriteLine();

            // Pierwszy wiersz po Paddingu Gornym: (' 1------------ ' '2 ----------------------- ' ')

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

            // Od drugiego wiersza------------ (do ostatniej linii przed Paddingiem Dolnym)
            
            // pionowe (+ ukosne) linie W zaleznosci czy macierz czy kalendarz
            // Dla wszystkich wierszy do konca macierzy i kalendarza (frontowej wysokosci)
            for (int i = 0; i < wysokoscMacierzy - 3; ++i)
            {
                //Idz po wierszach
                Console.Write(' ');

                // W zakresie macierzy ------------------

                for (int j = 0; j < szerokoscMacierzy - 4; ++j)
                {
                    if (j == 0 || j == (szerokoscMacierzy - 4) / 2 || j == szerokoscMacierzy - 5) // Lewy bok, kolumna, prawy bok
                        Console.Write('║');
                    else if (i == (wysokoscMacierzy - 3) / 2 || i == wysokoscMacierzy - 4) // Wiersz, Dolny Bok Macierzy
                        Console.Write('═');
                    else // Puste przestrzenie
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
            Console.WriteLine();

            /*
             * 
             * 
             * Config + Exit
             * 
             * 
             */

            // Padding Gorny dla Config i Exit
           
            // !!!!!! Bez Paddingu Gornego bo jeden wiersz za duzo wychodzi !!!!!!

            // Pierwszy wiersz po Paddingu Gornym

            Console.Write(' ');
            Console.Write(3);
            for (int i = 1; i < szerokoscConfig - 4; ++i)
            {
                Console.Write('═');
            }
            Console.Write('\\');
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(' ');
            Console.Write(4);
            for (int i = 1; i < szerokoscExit - 4; ++i)
            {
                Console.Write('═');
            }
            Console.Write('\\');
            Console.Write(' ');
            Console.Write(' ');
            Console.WriteLine();

            // Od drugiego wiersza------------ (do ostatniej linii przed Paddingiem Dolnym)

            for (int i = 0; i < wysokoscConfig - 3; ++i)
            {
                //Idz po wierszach
                Console.Write(' ');

                // W zakresie Config ------------------

                for (int j = 0; j < szerokoscConfig - 4; ++j)
                {
                    if (j == 0 || j == szerokoscConfig - 5) // Lewy i Prawy bok Configa
                        Console.Write('║');
                    else if (i == wysokoscConfig - 4) // Dolny bok Configa
                        Console.Write('═');
                    else // Puste przestrzenie
                        Console.Write(' ');
                }

                //Padding Config --------------------

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

                //W zakresie Exit ---------------

                for (int j = 0; j < szerokoscExit - 4; ++j)
                {
                    if (j == 0 || j == szerokoscExit - 5) // Lewy i Prawy bok Exit
                        Console.Write('║');
                    else if (i == wysokoscExit - 4) // DOlny bok Exit
                        Console.Write('═');
                    else // Puste przestrzenie
                        Console.Write(' ');
                }

                //Padding Exit ----------

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

            // Dolny padding Config i Exit

            // For ( int P;) dla 3 wierszy Paddingu Dolnego Config i Exit
            for (int P = 0; P < 3; ++P)
            {
                Console.Write(' ');
                // Przejscie po froncie Configa (C - 4) z Paddingiem (+ 4 )
                for (int j = 0; j < szerokoscConfig; ++j)
                {
                    if (j == 0 + P || j == szerokoscConfig - 5 + P)
                        Console.Write('\\');
                    else if (j == szerokoscConfig - 2) //Przedostatni Padding
                        Console.Write('|');
                    else if (P == 2 && j > 2 && j != szerokoscConfig - 1)
                        Console.Write('-');
                    else
                        Console.Write(' ');
                }
                // Przejscie po froncie Exit (E - 4) z Paddingiem (+4)
                for (int j = 0; j < szerokoscExit; ++j)
                {
                    if (j == 0 + P || j == szerokoscExit - 5 + P)
                        Console.Write('\\');
                    else if (j == szerokoscExit - 2)
                        Console.Write('|');
                    else if (P == 2 && j > 2 && j != szerokoscExit - 1)
                        Console.Write('-');
                    else
                        Console.Write(' ');
                }
                if (P != 2)
                    Console.WriteLine();
            }
        }
        public void WypiszTekst()
        {
            WypiszTekstMacierzy();
            WypiszTekstKalendarza();
            WypiszTekstConfig();
            WypiszTekstExit();
        }
        private void WypiszTekstMacierzy()
        {
            // Lewa Gorna kolumna
            Console.SetCursorPosition(3, 3);
            if (szerokoscOkna > 99)
                Console.Write("Pilne Ważne");
            else
                Console.Write("PW");

            // Prawa Gorna kolumna
            Console.SetCursorPosition(((szerokoscMacierzy - 4) / 2) + 3, 3);
            if (szerokoscOkna > 111)
                Console.Write("Niepilne Ważne");
            else
                Console.Write("NW");

            // Lewa Dolna kolumna
            Console.SetCursorPosition(3, ((wysokoscMacierzy - 3) / 2) + 4);
            if (szerokoscOkna > 111)
                Console.Write("Pilne Nieważne");
            else
                Console.Write("PN");

            //Prawa Dolna kolumna
            Console.SetCursorPosition(((szerokoscMacierzy - 4) / 2) + 3, ((wysokoscMacierzy - 3) / 2) + 4);
            if (szerokoscOkna > 130)
                Console.Write("Niepilne Nieważne");
            else
                Console.Write("NN");
        }
        private void WypiszTekstKalendarza()
        {
            int ktoryDzienWypisac = 1;
            // Dla kazdego wiersza kalendarza
            for(int i = 0; i < 7; ++i)
            { 
                // Ustalanie wiersza kursora
                if (i == 6)
                    Console.CursorTop = (wysokoscKalendarza - 4 + 1);
                else // i == 0, 1, 2, 3, 4, 5
                    Console.CursorTop = ((wysokoscKalendarza - 3) * (i + 1)) / 7;

                // Poprawka dla parzystych wierszy (czasami krotszych o 1)
                if (i % 2 == 1) // Wiersz kalendarza jest parzysty <==> i jest nieparzyste
                    Console.CursorTop++;

                // Dla kazdej kolumny w wierszu
                for (int j = 0; j <  7; ++j)
                {
                    // Ustalanie kolumny kursora
                    if (j == 0)
                        Console.CursorLeft = szerokoscMacierzy + 1 + 1;
                    else // j == 1, 2, 3, 4, 5, 6
                        Console.CursorLeft = szerokoscMacierzy + 1 + (((szerokoscKalendarza - 4) * j) / 7) + 1;             

                    // Wypisywanie tekstu
                    if (i == 0) // Dla dni tygodnia
                    {
                        if (j == 0)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Poniedziałek");
                            else if(szerokoscOkna > 80)
                                Console.Write("Pon");
                            else
                                Console.Write("P");
                        }
                        if (j == 1)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Wtorek");
                            else if(szerokoscOkna > 80)
                                Console.Write("Wt");
                            else
                                Console.Write("W");
                        }
                        if (j == 2)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Środa");
                            else if (szerokoscOkna > 80)
                                Console.Write("Śr");
                            else
                                Console.Write("Ś");
                        }
                        if (j == 3)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Czwartek");
                            else if (szerokoscOkna > 80)
                                Console.Write("Czw");
                            else
                                Console.Write("C");
                        }
                        if (j == 4)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Piątek");
                            else if (szerokoscOkna > 80)
                                Console.Write("Pt");
                            else
                                Console.Write("P");
                        }
                        if (j == 5)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Sobota");
                            else if (szerokoscOkna > 80)
                                Console.Write("Sob");
                            else
                                Console.Write("S");
                        }
                        if (j == 6)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Niedziela");
                            else if (szerokoscOkna > 80)
                                Console.Write("Niedz");
                            else
                                Console.Write("N");
                        }
                    }
                    else // Numerowanie dni, W Widoku Menu bedzie po kolei od 1 do 31 bez rzeczywistych dni tygodnia
                    {
                        if (ktoryDzienWypisac < 32)
                            Console.Write(ktoryDzienWypisac++);
                        else
                            Console.Write("-");
                    }
                }
            }
        }
        private void WypiszTekstConfig()
        {
            Console.SetCursorPosition((szerokoscConfig - 3) / 2, 
                wysokoscMacierzy + 3 + ((wysokoscConfig - 4) / 2));
            if (szerokoscOkna > 75)
                Console.Write("Config");
            else
                Console.Write("C");
        }
        private void WypiszTekstExit()
        {
            Console.SetCursorPosition(szerokoscMacierzy + 1 + szerokoscKalendarza / 2,
                wysokoscKalendarza + 3 + ((wysokoscExit - 4) / 2));
            if (szerokoscOkna > 65)
                Console.Write("Exit");
            else
                Console.Write("E");
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

            if(pozycjaWskaznikaKolumna == 0 && pozycjaWskaznikaWiersz == 0)
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

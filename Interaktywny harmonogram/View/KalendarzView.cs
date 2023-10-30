using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.View
{
    internal class KalendarzView
    {
        private int wysokoscOkna;
        private int szerokoscOkna;

        private int wysokoscKalendarza;
        private int szerokoscKalendarza;

        private int wysokoscStrzalki;
        private int szerokoscStrzalki;

        private int wyswietlanyRok;
        private int wyswietlanyMiesiac;
        DateTime dt;
        DayOfWeek jakiDzienJestPierwszego;

        private int wysokoscKomorkiDnia;
        private int szerokoscKomorkiDnia; 

        public KalendarzView(int wysokoscOkna, int szerokoscOkna, int wyswietlanyRok, int wyswietlanyMiesiac)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;

            szerokoscKalendarza = (11 * szerokoscOkna / 13) - 8; // Paddingi: 1, 3, 3, 1
            wysokoscKalendarza = wysokoscOkna - 4; // Paddingi: 1, 3

            wysokoscStrzalki = wysokoscKalendarza / 4;
            szerokoscStrzalki = szerokoscKalendarza / 11;

            wysokoscKomorkiDnia = (wysokoscKalendarza - 3 - 8) / 7;
            szerokoscKomorkiDnia = (szerokoscKalendarza - 3 - 8) / 7;

            this.wyswietlanyRok = wyswietlanyRok;
            this.wyswietlanyMiesiac = wyswietlanyMiesiac;
            dt = new DateTime(wyswietlanyRok, wyswietlanyMiesiac, 1);
        }
        public void RysujTlo()
        {
            // Padding Gorny Kalendarza

            Console.WriteLine();

            // Przejscie wierszami od Pierwszego Wiersza Kalendarza do Ostatniego Wiersza Kal. przed Paddingiem dolnym

            for(int i = 0; i < wysokoscKalendarza - 3; ++i)
            {
                // Lewy Padding szerokosci

                Console.Write(' ');

                // Przejscie po kolumnach wierszy na szerokosci Strzalki w Lewo
                for (int j = 0; j < szerokoscStrzalki; ++j) // Co ma sie dziac na szerokosci strzalki
                {
                    if (i < wysokoscKalendarza / 2 - wysokoscStrzalki / 2
                        || i > wysokoscKalendarza / 2 + wysokoscStrzalki / 2) // Jesli nie ta wysokosc to pusto
                        Console.Write(' ');
                    else if (j == 0 && i == wysokoscKalendarza / 2)
                        Console.Write('(');
                    else if (j == szerokoscStrzalki - 1)
                        Console.Write('|');
                    else if (i == wysokoscKalendarza / 2 - j)
                        Console.Write('/');
                    else if (i == wysokoscKalendarza / 2 + j)
                        Console.Write('\\');
                    else if (i == wysokoscKalendarza / 2 && j == szerokoscStrzalki / 2)
                        Console.Write('Q');
                    else
                        Console.Write(' ');
                }

                // Przejscie po Paddingu Dlugim szerokosci
                for (int j = 0; j < 3; ++j)
                    Console.Write(' ');

                // Przejscie przez szerokosc Kalendarza

                for (int j = 0; j < szerokoscKalendarza - 4; ++j)
                {
                    if (i == 0)
                        Console.Write('═');
                    else if (j == 0 || j == (szerokoscKalendarza - 4) / 7 ||
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

                // Przejscie przez prawe 2D Kalendarza
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

                // Przejscie po Paddingu Dlugim szerokosci
                for (int j = 0; j < 3; ++j)
                    Console.Write(' ');

                // Przejscie po strzalce w prawo
                for (int j = 0; j < szerokoscStrzalki; ++j) // Co ma się dziać na szerokości strzałki
                {
                    if (i < wysokoscKalendarza / 2 - wysokoscStrzalki / 2
                        || i > wysokoscKalendarza / 2 + wysokoscStrzalki / 2) // Jeśli nie ta wysokość to pusto
                        Console.Write(' ');
                    else if (j == szerokoscStrzalki - 1 && i == wysokoscKalendarza / 2)
                        Console.Write(')');
                    else if (j == 0)
                        Console.Write('|');
                    else if (i == wysokoscKalendarza / 2 + (szerokoscStrzalki - j - 1))
                        Console.Write('/');
                    else if (i == wysokoscKalendarza / 2 - (szerokoscStrzalki - j - 1))
                        Console.Write('\\');
                    else if (i == wysokoscKalendarza / 2 && j == szerokoscStrzalki / 2)
                        Console.Write('E');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }

            // Przejscie pod kalendarz
      
            // Przejscie przez Dolne 2D Kalendarza 
            for (int i = 0; i < 3; ++i) // Dla 3 wierszy
            {
                Console.Write(' '); //Lewy padding

                // Pominiecie szerokosci strzalki w lewo
                for (int j = 0; j < szerokoscStrzalki; ++j)
                    Console.Write(' ');

                // Przejscie po Paddingu Dlugim szerokosci
                for (int j = 0; j < 3; ++j)
                    Console.Write(' ');
                for (int j = 0; j < szerokoscKalendarza; ++j)
                {
                    if (j == i)
                        Console.Write('\\');
                    else if (j == szerokoscKalendarza - 1)
                        Console.Write('|');
                    else if (j == szerokoscKalendarza - 3 - 1 + i)
                        Console.Write('\\');
                    else if (i == 2 && j > 2)
                        Console.Write('-');
                    else
                        Console.Write(' ');

                }
                Console.WriteLine();
            }
        }
        public void WypiszTekstKalendarza()
        {
            int ktoryDzienWypisac = 1;
            // Dla kazdego wiersza kalendarza
            for (int i = 0; i < 7; ++i)
            {
                // Ustalanie wiersza kursora
                Console.CursorTop = 2 + i * (wysokoscKalendarza - 3) / 7;
                //if (i == 6)
                    //Console.CursorTop = (wysokoscKalendarza - 4 + 1);
                //else // i == 0, 1, 2, 3, 4, 5
                    //Console.CursorTop = ((wysokoscKalendarza - 3) * (i + 1)) / 7;

                // Poprawka dla parzystych wierszy (czasami krotszych o 1)
                //if (i % 2 == 1) // Wiersz kalendarza jest parzysty <==> i jest nieparzyste
                    //Console.CursorTop++;

                // Dla kazdej kolumny w wierszu
                for (int j = 0; j < 7; ++j)
                {
                    // Ustalanie kolumny kursora
                    if (j == 0)
                        Console.CursorLeft = 1 + szerokoscStrzalki + 3 + 3;
                    else // j == 1, 2, 3, 4, 5, 6
                        Console.CursorLeft = 1 + szerokoscStrzalki + 3 + 3 + (((szerokoscKalendarza - 4) * j) / 7) + 1;

                    // Wypisywanie tekstu
                    if (i == 0) // Dla dni tygodnia
                    {
                        if (j == 0)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Poniedziałek");
                            else if (szerokoscOkna > 80)
                                Console.Write("Pon");
                            else
                                Console.Write("P");
                        }
                        if (j == 1)
                        {
                            if (szerokoscOkna > 160)
                                Console.Write("Wtorek");
                            else if (szerokoscOkna > 80)
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
                        jakiDzienJestPierwszego = dt.DayOfWeek;
                        if (i == 1)
                        {
                            if (jakiDzienJestPierwszego == DayOfWeek.Sunday)
                            {
                                if (j != 6)
                                    Console.Write("  ");
                                else
                                {
                                    Console.Write(ktoryDzienWypisac++);
                                    if (ktoryDzienWypisac <= 10)
                                        Console.Write(' ');
                                }
                            }
                            else
                            {
                                if (j + 1 < ((int)jakiDzienJestPierwszego))
                                    Console.Write("  ");
                                else
                                {
                                    Console.Write(ktoryDzienWypisac++);
                                    if (ktoryDzienWypisac <= 10)
                                        Console.Write(' ');
                                }
                            }
                        }
                        else
                        {
                            if (ktoryDzienWypisac > DateTime.DaysInMonth(wyswietlanyRok, wyswietlanyMiesiac))
                                Console.Write("  ");
                            else
                            {
                                Console.Write(ktoryDzienWypisac++);
                                if (ktoryDzienWypisac <= 10)
                                    Console.Write(' ');
                            }
                        }
                    }
                }
            }
            Console.SetCursorPosition(0, wysokoscKalendarza + 1);
            if(wyswietlanyMiesiac > 9)
                Console.Write($"{wyswietlanyMiesiac}.{wyswietlanyRok}");
            else
                Console.Write($"{wyswietlanyMiesiac}.{wyswietlanyRok} ");
        }
        public void RysujWskaznik(int pozycjaWskaznikaKolumna, int pozycjaWskaznikaWiersz)
        {
            
        }
        public void AktualizujRozdzielczosc(int wysokoscOkna, int szerokoscOkna)
        {
            this.wysokoscOkna = wysokoscOkna;
            this.szerokoscOkna = szerokoscOkna;

            szerokoscKalendarza = (11 * szerokoscOkna / 13) - 8;
            wysokoscKalendarza = wysokoscOkna - 4;

            wysokoscStrzalki = wysokoscKalendarza / 4;
            szerokoscStrzalki = szerokoscKalendarza / 11;

            wysokoscKomorkiDnia = (wysokoscKalendarza - 3 - 8) / 7;
            szerokoscKomorkiDnia = (szerokoscKalendarza - 3 - 8) / 7;
        }
        public void AktualizujDate(int wyswietlanyRok, int wyswietlanyMiesiac)
        {
            this.wyswietlanyRok = wyswietlanyRok;
            this.wyswietlanyMiesiac = wyswietlanyMiesiac;
            dt = new DateTime(wyswietlanyRok, wyswietlanyMiesiac, 1);
        }
    }
}

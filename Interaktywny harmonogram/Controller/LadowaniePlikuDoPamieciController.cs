using Interaktywny_harmonogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class LadowaniePlikuDoPamieciController
    {
        private static LadowaniePlikuDoPamieciController instance = new LadowaniePlikuDoPamieciController();
        private LadowaniePlikuDoPamieciController() { }
        public bool ZaladujRok(Rok rok)
        {
            if (rok == null) { return false; }

            Miesiac[] miesiace = rok.GetMiesiace();

            try
            {
                string sciezkaPliku = rok.GetRok() + ".txt";
                using (StreamReader sr = new StreamReader(sciezkaPliku))
                {
                    string wierszFizyczny; //rzeczywisty jeden wiersz w pliku
                    string wierszLogiczny = ""; //blok wierszy rzeczywistyh obejmujacy jedno zadanie

                    string miesiac = "";
                    string dzien = "";
                    string[] daneDoZapisu = new string[6];

                    // Czytanie calego pliku wiersz po wierszu (fizycznym)
                    while ((wierszFizyczny = sr.ReadLine()) != null)
                    {
                        // Sprawdz czy przeczytano date
                        if (wierszLogiczny.StartsWith("%%$#!"))
                        {
                            /* 
                             * jesli przeczytano date, ustal odpowiedni miesiac i dzien do modelu
                             * nastepnie przejdz do przeczytania kolejnego wiersza (zadania lub kolejnego dnia)
                             */
                            miesiac += wierszLogiczny[5];
                            miesiac += wierszLogiczny[6];
                            dzien += wierszLogiczny[8];
                            dzien += wierszLogiczny[9];

                            continue;
                        }
                        //od tad znany jest miesiac i dzien
                        
                        wierszLogiczny += wierszFizyczny;
                        // Sprawdzenie czy przeczytano logicznie pelny wiersz
                        if (!wierszFizyczny.EndsWith("%%@@"))
                        {
                            wierszLogiczny += System.Environment.NewLine;
                            continue;
                        }
                        // Tu przeczytano logicznie pelny wiersz + znana data

                        // Sformatowanie wiersza logicznego i zapis zadania do modelu
                        daneDoZapisu = wierszLogiczny.Split("%%+!", StringSplitOptions.RemoveEmptyEntries);

                        rok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].DodajZadanie(daneDoZapisu);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // TO DO
            }

            return true;
        }
        public static LadowaniePlikuDoPamieciController GetInstance() { return instance; }
        private int WyznaczInt(string s)
        {
            if (s[0] == '0')
                s.Remove(0, 1);
            int i = Int32.Parse(s);
            return i;

        }
    }
}

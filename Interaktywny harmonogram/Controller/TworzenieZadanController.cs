using Interaktywny_harmonogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class TworzenieZadanController
    {
        private static TworzenieZadanController instance = new TworzenieZadanController();
        private TworzenieZadanController() { }
        public void DodajZadanieDoMacierzy(string[] daneZadania, string kategorie)
        {
            /* Dynamiczne dodanie zadania poelga na:
             * a) dodaniu zadania do pamieci programu
             * b) dodaniu wpisu do pliku i zapisaniu go
             */
            
            // Dodanie zadania do pamieci programu
            Macierz macierz = Macierz.GetMacierz();
            macierz.DodajZadanie(daneZadania, kategorie);

            //Zapisanie pamieci do pliku
            string sciezkaPliku = "macierz.txt";

            //Jak chyba bedzie:
            //1.Czytaj linie
            //2.Sprawdz czy dobra kategoria (data), jesli nie - wroc do 1.
            //3.Zapamietaj jakos pozycje wskaznika? strumienia //w oddzielnej metodzie return i: po petli ze StreamRd.RL
            //4.Wklej przed nastepna kategoria (data) zadanie (wtedy godziny staja sie nieistotne w sortowaniu)
            //5.(Jesli godziny maja sie liczyc, wstaw przed nastepna data + przed nastepna zajeta godzina
        }
        public static TworzenieZadanController GetInstance() { return instance; }
    }
}

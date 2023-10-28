using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Model
{
    internal class Dzien
    {
        private int dzien;
        private List<Zadanie> zadania = new List<Zadanie>();
        public Dzien(int dzien)
        {
            this.dzien = dzien;
            //zadania.Add("eee");
        }
        public int GetDzien() { return dzien; }
        public List<Zadanie> GetZadania() {  return zadania; }
        public bool DodajZadanie(string[] daneZadania)
        {
            zadania.Add(new Zadanie(daneZadania[1], daneZadania[2],
                daneZadania[3] == "1", daneZadania[4] == "1", daneZadania[5] == "1"));
            return true; //if success
        }
        public bool UsunZadanie(Zadanie templateZadaniaDoUsunieca)
        {
            // Zlokalizuj zadanie
            Zadanie zadanieDoUsuniecia = ZlokalizujZadanie(templateZadaniaDoUsunieca);
            if (zadanieDoUsuniecia == null)
                return false; // Nie ma takiego zadania
           
            // Usun zadanie
            zadania.Remove(zadanieDoUsuniecia);
            return true; //if success
        }
        public bool EdytujZadanie(string[] noweDaneZadania, Zadanie templateZadaniaDoEdycji)
        {
            // Zlokalizuj zadanie
            Zadanie zadanieDoEdycji = ZlokalizujZadanie(templateZadaniaDoEdycji);
            if (zadanieDoEdycji == null)
                return false; // Nie ma takiego zadnia

            // Edytuj zadanie
            zadanieDoEdycji.naglowek = noweDaneZadania[1];
            zadanieDoEdycji.opis = noweDaneZadania[2];
            zadanieDoEdycji.pilne = noweDaneZadania[3] == "1";
            zadanieDoEdycji.wazne = noweDaneZadania[4] == "1";
            zadanieDoEdycji.wykonane = noweDaneZadania[5] == "1";
            return true; //if success
        }
        private Zadanie ZlokalizujZadanie(Zadanie templateDoZlokalizowania)
        {
            Zadanie zadanieDoZlokalizowania = null;
            foreach (Zadanie zadanie in zadania)
            {
                if (zadanie.Equals(templateDoZlokalizowania))
                    zadanieDoZlokalizowania = zadanie;
            }
            return zadanieDoZlokalizowania;
        }
    }
}

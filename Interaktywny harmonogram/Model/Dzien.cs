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
        public bool UsunZadanie()
        {
            return true; //if success
        }
        public bool EdytujZadanie()
        {
            return true; //if success
        }
    }
}

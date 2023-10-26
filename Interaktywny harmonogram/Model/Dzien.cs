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
        private List<string> zadania = new List<string>();
        public Dzien(int dzien)
        {
            this.dzien = dzien;
            //zadania.Add("eee");
        }
        public int GetDzien() { return dzien; }
        public List<string> GetZadania() {  return zadania; }
        public bool DodajZadanie(string[] daneZadania)
        {

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

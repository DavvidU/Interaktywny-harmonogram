using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Model
{
    internal class Macierz
    {
        private static Macierz macierz = new Macierz();
        public List<Zadanie> PilneWazne = new List<Zadanie>();
        public List<Zadanie> NiepilneWazne = new List<Zadanie>();
        public List<Zadanie> PilneNiewazne = new List<Zadanie>();
        public List<Zadanie> NiepilneNiewazne = new List<Zadanie>();

        private Macierz() { }
        public static Macierz GetMacierz() { return macierz; }
        public void DodajZadanie(string[] daneZadania, string kategorie)
        {
            if (kategorie == "PW")
                PilneWazne.Add(new Zadanie(Int32.Parse(daneZadania[1]), daneZadania[2], daneZadania[3],
                    daneZadania[4] == "1", daneZadania[5] == "1", daneZadania[6] == "1"));
            if (kategorie == "NW")
                NiepilneWazne.Add(new Zadanie(Int32.Parse(daneZadania[1]), daneZadania[2], daneZadania[3],
                    daneZadania[4] == "1", daneZadania[5] == "1", daneZadania[6] == "1"));
            if (kategorie == "PN")
                PilneNiewazne.Add(new Zadanie(Int32.Parse(daneZadania[1]), daneZadania[2], daneZadania[3],
                    daneZadania[4] == "1", daneZadania[5] == "1", daneZadania[6] == "1"));
            if (kategorie == "NN")
                NiepilneNiewazne.Add(new Zadanie(Int32.Parse(daneZadania[1]), daneZadania[2], daneZadania[3],
                    daneZadania[4] == "1", daneZadania[5] == "1", daneZadania[6] == "1"));
        }
        public void UsunZadanie()
        {
            
        }
        public void EdytujZadanie()
        {
            
        }
    }
}

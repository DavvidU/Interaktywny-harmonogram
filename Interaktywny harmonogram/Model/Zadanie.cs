﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Model
{
    internal class Zadanie
    {
        public string naglowek;
        public string opis;
        public bool pilne;
        public bool wazne;
        public bool wykonane;

        //konstruktor tworzacy
        public Zadanie(string naglowek, string opis,
            bool pilne, bool wazne, bool wykonane)
        {
            this.naglowek = naglowek;
            this.opis = opis;
            this.pilne = pilne;
            this.wazne = wazne;
            this.wykonane = wykonane;
        }
    }
}

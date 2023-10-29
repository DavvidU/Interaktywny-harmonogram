using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class ConfigController
    {
        int wysokoscBufora;
        int szerokoscBufora;
        ConsoleColor kolorTla;
        ConsoleColor kolorFontu;
        public static ConfigController Instance = new ConfigController();
        private ConfigController() { }
        public void ZaladujConfig()
        {

        }
        public void ZapiszConfig()
        {

        }
        public void ConfigViewListener()
        {

        }
        public static ConfigController GetInstance() { return Instance; }
    }
}

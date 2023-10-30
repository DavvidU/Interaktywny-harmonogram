using Interaktywny_harmonogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    internal class InicjalizacjaController
    {
        private Kalendarz kalendarz;
        private Macierz macierz;
        private DateTime aktualna_data;
        public InicjalizacjaController()
        {
            Initialize();
        }
        public bool Initialize()
        {
            aktualna_data = DateTime.Now;
            kalendarz = Kalendarz.GetKalendarz();
            macierz = Macierz.GetMacierz();

            ZainicjujPustyKalendarz();
            WypelnijStartowyKalendarz();
            WypelnijStartowaMacierz();
            //BYCMOZE ConfigController.ZaladujConfig()


            ConsoleKeyInfo cki; //wcisniety przycisk w konsoli (np. x albo ctrl + C)

            // Obsługa CTRL + C i CTRL + BREAK
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);



            Console.CursorVisible = false; //TO POTEM ODKOMOENTOWAC!!!!
            MenuController menuController = MenuController.GetInstance();
            menuController.MenuViewListener();

            return true;
        }
        
        private void ZainicjujPustyKalendarz()
        {
            //dodaj rok ubiegy, aktualny i 8 lat do przodu
            for (int i = 1; i > -9; --i)
            {
                kalendarz.lata.AddLast(new Rok(aktualna_data.Year - i));
            }
        }
        private void WypelnijStartowyKalendarz()
        {
            WczytywanieDanychController kontroler = WczytywanieDanychController.GetInstance();
            foreach (Rok rok in kalendarz.lata)
            {
                kontroler.ZaladujRokLubMacierz(rok, "rok");
            }
        }
        private void WypelnijStartowaMacierz()
        {
            WczytywanieDanychController kontroler = WczytywanieDanychController.GetInstance();
            kontroler.ZaladujRokLubMacierz(null, "macierz");
        }
        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

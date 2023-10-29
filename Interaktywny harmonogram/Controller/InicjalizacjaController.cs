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
        /*
        public DateTime PobierzAktualnaDate()
        {
            aktualna_data = DateTime.Now;
            return aktualna_data;
        } To bedzie prawdopodobnie w innym controllerze niz Initialize */
    }
}

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
        private DateTime aktualna_data;
        public InicjalizacjaController()
        {
            Initialize();
        }
        public bool Initialize()
        {
            aktualna_data = DateTime.Now;
            kalendarz = Kalendarz.GetKalendarz();

            ZainicjujPustyKalendarz();
            WypelnijStartowyKalendarz();

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
            LadowaniePlikuDoPamieciController kontroler = LadowaniePlikuDoPamieciController.GetInstance();
            foreach (Rok rok in kalendarz.lata)
            {
                kontroler.ZaladujRok(rok);
            }
        }
        /*
        public DateTime PobierzAktualnaDate()
        {
            aktualna_data = DateTime.Now;
            return aktualna_data;
        } To bedzie prawdopodobnie w innym controllerze niz Initialize */
    }
}

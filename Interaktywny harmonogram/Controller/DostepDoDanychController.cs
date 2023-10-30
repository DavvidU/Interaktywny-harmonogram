using Interaktywny_harmonogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaktywny_harmonogram.Controller
{
    static internal class DostepDoDanychController
    {
        public static List<Zadanie> GetZadania(int dzien, int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadanController tw = TworzenieEdycjaUsuwanieZadanController.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1].GetZadania();
        }
        public static List<Zadanie> GetZadania(string kategoria)
        {
            Macierz macierz = Macierz.GetMacierz();

            if (kategoria == "PW")
                return macierz.PilneWazne;
            else if (kategoria == "NW")
                return macierz.NiepilneWazne;
            else if (kategoria == "PN")
                return macierz.PilneNiewazne;
            else if (kategoria == "NN")
                return macierz.NiepilneNiewazne;
            else
                return macierz.PilneWazne;
        }
        public static Dzien GetDzien(int dzien, int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadanController tw = TworzenieEdycjaUsuwanieZadanController.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1].GetDni()[dzien - 1];
        }
        public static Miesiac GetMiesiac(int miesiac, int rok)
        {
            Kalendarz kalendarz = Kalendarz.GetKalendarz();
            TworzenieEdycjaUsuwanieZadanController tw = TworzenieEdycjaUsuwanieZadanController.GetInstance();

            Rok szukanyRok = tw.ZlokalizujRokWPamieci(rok);

            return szukanyRok.GetMiesiace()[miesiac - 1];
        }
    }
}

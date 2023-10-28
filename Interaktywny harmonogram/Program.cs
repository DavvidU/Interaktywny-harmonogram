using Interaktywny_harmonogram.Model;
using Interaktywny_harmonogram.Controller;
//using System.Threading.Channels;

/*
Console.WriteLine(kalendarz.lata.First.Value.GetRok());
Console.WriteLine(kalendarz.lata.First.Value.GetMiesiace()[0].GetDni()[0].GetZadania());
bool result = kalendarz.lata.First.Value.GetMiesiace()[0].GetDni()[0].EdytujZadanie();
*/



InicjalizacjaController kontroler_init = new InicjalizacjaController();


//@@@@@@@@@@@ Testowanie Dodawania, Edycji i Usuwania
/*
TworzenieEdycjaUsuwanieZadanController TEUController = TworzenieEdycjaUsuwanieZadanController.GetInstance();
Zadanie zadaniePrzykladowe = new Zadanie("TESTYTESTY", "OPISOPISopisOPIS", false, false, false);
string[] daneZadaniaDoDodania = new string[6] { "cokolwiek", "TESTYTESTY", "OPISOPISopisOPIS", "0", "0", "0" };
string[] daneZadaniaDoEdycji = new string[6] { "cokolwiek", "testytesty", "opisopisOPISopis", "1", "1", "1" };
*/
//@@@-@@@ Dodaj zadania do macierzy:

/*
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PW");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PW");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PW");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "NW");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PN");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PN");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "PN");
TEUController.DodajZadanieDoMacierzy(daneZadaniaDoDodania, "NN");
*/

//@@@-@@@ EDYCJA - edytuje od ostatniego wpisu jesli takie same (przez foreach(){})
/*

TEUController.EdytujZadanieWMacierzy(daneZadaniaDoEdycji, zadaniePrzykladowe, "PW");
TEUController.EdytujZadanieWMacierzy(daneZadaniaDoEdycji, zadaniePrzykladowe, "NW");
TEUController.EdytujZadanieWMacierzy(daneZadaniaDoEdycji, zadaniePrzykladowe, "PN");
TEUController.EdytujZadanieWMacierzy(daneZadaniaDoEdycji, zadaniePrzykladowe, "NN");
TEUController.EdytujZadanieWMacierzy(daneZadaniaDoEdycji, zadaniePrzykladowe, "PW");
*/

//@@@-@@@ USUWANIE - usuwa od pierwszego wpisu jesli takie same (przez "Remove()")
/*
TEUController.UsunZadanieZMacierzy(zadaniePrzykladowe, "PW");
TEUController.UsunZadanieZMacierzy(zadaniePrzykladowe, "NW");
TEUController.UsunZadanieZMacierzy(zadaniePrzykladowe, "PN");
TEUController.UsunZadanieZMacierzy(zadaniePrzykladowe, "NN");
*/

//@@@-@@@ Dodaj zadania do kalendarza:

//Dodaj w istniejace dni:
/*
TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 25, 10, 2023);
TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 27, 10, 2023);
TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 1, 11, 2023);

TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 2, 1, 2023);

TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 26, 10, 2023);

TEUController.DodajZadanieDoKalendarza(daneZadaniaDoDodania, 31, 12, 2023);
*/

//@@@-@@@ EDYCJA
/*
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 25, 10, 2023);
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 27, 10, 2023);
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 26, 10, 2023);
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 1, 11, 2023);
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 2, 1, 2023);
TEUController.EdytujZadanieWKalendarzu(daneZadaniaDoEdycji, zadaniePrzykladowe, 31, 12, 2023);
*/

//@@@-@@@ USUWANIE
/*
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 25, 10, 2023);
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 27, 10, 2023);
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 26, 10, 2023);
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 1, 11, 2023);
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 2, 1, 2023);
TEUController.UsunZadanieZKalendarza(zadaniePrzykladowe, 31, 12, 2023);
*/

// zaimplementowac dzien i dokladne tworzenie okresow


using Interaktywny_harmonogram.Model;
using Interaktywny_harmonogram.Controller;
//using System.Threading.Channels;

/*
Console.WriteLine(kalendarz.lata.First.Value.GetRok());
Console.WriteLine(kalendarz.lata.First.Value.GetMiesiace()[0].GetDni()[0].GetZadania());
bool result = kalendarz.lata.First.Value.GetMiesiace()[0].GetDni()[0].EdytujZadanie();
*/



InicjalizacjaController kontroler_init = new InicjalizacjaController();


/*
 * Napisanie pliku 400 kB ez
 */
/*
var file = File.Create("testy.txt");
Console.WriteLine("Stworzenie pliku");
file.Close();
StreamWriter writer = new StreamWriter("testy.txt");
Console.WriteLine("Zaczynam zapisywac 200kB");
for ( int i = 0; i < 365; i++ )
{
    for( int j = 0; j < 1000; j++ )
        writer.Write((j%9).ToString());
}
writer.Close();
Console.WriteLine("Zaczynam czytac 200kB");
StreamReader read = new StreamReader("testy.txt");
string kurwa = read.ReadToEnd();
read.Close();
StreamWriter writerr = new StreamWriter("testy.txt");
writerr.WriteLine("essa");
writerr.Close();
*/





//Console.WriteLine(Kalendarz.GetKalendarz().lata.First.Value.GetMiesiace()[0].GetDni()[0].GetDzien()); //test

// moze konstruktory dac prywatne/protected
// zaimplementowac dzien i dokladne tworzenie okresow


using System;
using System.Runtime.InteropServices.ComTypes;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int liczbaprob = 0;
            int liczba;
            string napiskoncowy = "Łatwym" ;
            int iloscprob = 5;
            int maxliczba = 100;
            Console.WriteLine("Witam w prostej grze zgadnij liczbe ");
            Console.WriteLine("Prosze wybrać poziom trudności");
            Console.WriteLine("Dostępne są 3 poziomy trudności \n Łatwy \n Średni \n Trudny");
            Console.WriteLine("Jeśli chcesz wybrać łatwy wpisz 1 \nJeśli chcesz wybrać średni wpisz 2 \nJeśli chcesz wybrać trudny wpisz 3 ");
             int wybor = int.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                iloscprob = 6;
                maxliczba = 30;
                napiskoncowy = "Łatwym";
            }
            else if (wybor == 2)
            {
                iloscprob = 5;
                maxliczba = 60;
                napiskoncowy = "Średnim";
            }
            else if (wybor == 3)
            {
                iloscprob = 4;
                maxliczba = 100;
                napiskoncowy = "Trundym";
            }
            Random nieznana = new Random();
            
            int los = nieznana.Next(1, maxliczba);
            Console.WriteLine("Podaj liczbe z zakresu od 1 do "+ maxliczba + ", masz " + iloscprob + " próby !");


            do
            {
                Console.Write("Wpisz liczbe: ");
                liczba = int.Parse(Console.ReadLine());
                 liczbaprob++ ;
                 if (iloscprob == liczbaprob)
                {
                    Console.WriteLine("Przykro mi , straciłeś wszystkie próby i przegrałeś gre :(");
                    break;
                }
                else if (liczba > los)
                {
                    Console.WriteLine("Za duża liczba spróbuj ponownie!");
                }
                else if (liczba < los)
                {
                    Console.WriteLine("Za mała liczba spróbuj ponownie!");

                }
              
                else
                {
                    Console.WriteLine("Gratulacje udało ci się odgadnąć liczbe na poziomie "+ napiskoncowy + "! Zajeło ci to "+ liczbaprob + " prób");
                }
            } while (los != liczba);
            Console.ReadLine();
        }
    }
}

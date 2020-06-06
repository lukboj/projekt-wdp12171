using System;
using System.Runtime.InteropServices.ComTypes;
using System.Xml;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            string zgoda;
            int liczbaprob = 0;
            int liczba;
            string napiskoncowy = "Łatwym";
            int iloscprob = 5;
            int maxliczba = 100;
            Console.WriteLine("Witam w prostej grze zgadnij liczbe ");
        gra:
            Console.WriteLine("Prosze wybrać poziom trudności");
            Console.WriteLine("Dostępne są 3 poziomy trudności \n Łatwy \n Średni \n Trudny");
            Console.WriteLine("Jeśli chcesz wybrać łatwy wpisz Łatwy \nJeśli chcesz wybrać średni wpisz Średni \nJeśli chcesz wybrać trudny wpisz Trudny\n Jeżeli chcesz wybrać ilość prób oraz zakres wpisz Własny ");
            string wybor = Console.ReadLine();
        powrot1:
            if (wybor == "Łatwy")
            {
                iloscprob = 6;
                maxliczba = 30;
                napiskoncowy = "Łatwym";
            }
            else if (wybor == "Średni")
            {
                iloscprob = 5;
                maxliczba = 60;
                napiskoncowy = "Średnim";
            }
            else if (wybor == "Trudny")
            {
                iloscprob = 5;
                maxliczba = 100;
                napiskoncowy = "Trundym";
            }
            else if (wybor == "Własny")
            {
                Console.WriteLine("Podaj ile chcesz mieć prób");
                iloscprob = int.Parse(Console.ReadLine());
                Console.WriteLine("Napisz do jakiej liczby ma być zakres ");
                maxliczba = int.Parse(Console.ReadLine());
                napiskoncowy = "Własnym";
            }
            else
            {
                Console.WriteLine("Prosze wpisać Łatwy, Średni, Trudny bądź Własny");
                goto powrot1;
            }
            Random nieznana = new Random();
            
            int los = nieznana.Next(1, maxliczba);
            Console.WriteLine("Podaj liczbe z zakresu od 1 do "+ maxliczba + ", masz " + iloscprob + " prób !");


            do
            {
                Console.Write("Wpisz liczbe: ");
                liczba = int.Parse(Console.ReadLine());
                 liczbaprob++ ;
                 if (iloscprob == liczbaprob)
                {
                    Console.WriteLine("Przykro mi , straciłeś wszystkie próby i przegrałeś gre ");
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
            Console.WriteLine("Czy chcesz zagrać ponownie ?");
            Console.WriteLine("Wpisz Tak albo nie");
            
            powrot:
            zgoda = Console.ReadLine();
            if (zgoda == "Tak")
            {
                goto gra;

            }
            else if (zgoda == "Nie")
            {
                Console.WriteLine("Dziękuje za gre");
                goto Koniec;
            }
            else
            {
                Console.WriteLine("Prosze wpisać Tak lub Nie");
                goto powrot;
            }
        Koniec:
            Console.ReadLine();
        }
    }
}

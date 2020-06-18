using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int fortuna = 0;
            int zakres;
            int oszustwa = 0;
            int iloscprob;
            Console.WriteLine("Witam w prostej grze konsolowej zgadnij liczbe ");
            powrot3:
            Console.WriteLine("Prosze wybrać poziom trudności \n Do wyboru \n Łatwy  \n Średni  \n Trudny  \n Własny (Wybierasz ilość prób oraz zakres) \nWybierz ktory poziom chcesz poprzez wpisanie w konsole słowa klucz z dużej litery");
            Console.WriteLine("Odpowiednio dla każdego poziomu \n Dla poziomu łatwego jest to: Łatwy \n Dla poziomu Średniego: Średni \n Dla poziomu Trudnego: Trudny \n Dla własnego: Własny ");

           
             string poziom = Console.ReadLine();

            if (poziom == "Łatwy" || poziom == "Średni" || poziom == "Trudny" || poziom == "Własny")
            {
                goto kontynuacja;
            }
            else 
            {
                Console.WriteLine("" +
                    "\nTo nie jest słowo klucz\n ");
                goto powrot3;
            }

            kontynuacja:
            
            iloscprob = Poziomtrudnosci(poziom);
            zakres = Poziomtrudnosci1(poziom);
            int proba;
            int liczbaprob = 0;
            int los = Maszynalosujaca(zakres);
            do
            {
                liczbaprob++;
                powrot5:
                Console.WriteLine("Prosze wpisać liczbę którą podejrzewasz ");
                try
                {
                    proba = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("To nie jest liczba !");
                    goto powrot5;
                }
                

                if (liczbaprob == iloscprob)
                {
                    if (fortuna == 1)
                    {
                        Console.WriteLine("Przykro mi, wykorzystałeś wszystie swoje próby liczba którą szukałeś to " + los + "Komputer oszukał cię " + oszustwa + "raz/razy");
                    }
                    else
                    {
                        Console.WriteLine("Przykro mi, wykorzystałeś wszystie swoje próby liczba którą szukałeś to " + los);
                    }
                    break;
                }
                if (proba == los)
                {
                    Console.WriteLine("Gratulacje odgadłeś liczbę, była to liczba "+ los +" zajeło ci to "+ liczbaprob + " prób.");
                }
                else if (proba > los)
                {
                    
                     fortuna = Oszustwo();
                    if (fortuna == 1)
                    {
                        Console.WriteLine("Podałeś za małą liczbę");
                        oszustwa++;
                    }
                    else
                    {
                        Console.WriteLine("Podałeś za dużą liczbę");
                    }
                    
                }
                else if (proba < los)
                {
                    
                     fortuna = Oszustwo();
                    if (fortuna == 1)
                    {
                        Console.WriteLine("Podałeś za dużą liczbę");
                        oszustwa++;
                    }
                    else
                    {
                        Console.WriteLine("Podałeś za małą liczbę");
                    }
                    
                }
            } while (los != proba);
            Console.WriteLine("Chcesz zagrać jeszcze raz ?");
            Console.WriteLine("Jeśli tak wpisz Tak jeśli nie wpisz Nie");
            string zgoda = Console.ReadLine();
            if (zgoda == "Tak")
            {
                goto powrot3;
            }
            else
            {
                Console.WriteLine("Dziękuje za gre");
                Environment.Exit(0);

            }





        }
        
        static int Maszynalosujaca(int zakres)
        {
            Random nieznana = new Random();
            int los = nieznana.Next(1, zakres);
            return los;

        }
        static int Poziomtrudnosci ( string poziom )
        {
            int iloscprob;
        powrot:
            if (poziom == "Łatwy")
            {
               iloscprob = 8;
               return iloscprob;
            }
            else if (poziom == "Średni")
            {
                iloscprob = 6;
                return iloscprob;
            }
            else if (poziom == "Trudny")
            {
                iloscprob = 4 ;
                return iloscprob;
            }
            else if (poziom == "Własny")
            {
                Console.WriteLine("Prosze wybrać ilość prób");
                int wybor1 = int.Parse(Console.ReadLine());
                iloscprob = wybor1;
                return iloscprob;
            }
            else
            {
                goto powrot;
            }
        

        }
        static int Poziomtrudnosci1 (string poziom)
        {
            int zakres ;
        powrot:
            if (poziom == "Łatwy")
            {
                zakres = 60;
                return zakres;
            }
            else if (poziom == "Średni")
            {
                zakres = 80;
                return zakres;
            }
            else if (poziom == "Trudny")
            {
                zakres = 100;
                return zakres;
            }
            else if (poziom == "Własny")
            {
            
                Console.WriteLine("Prosze wpisać liczbe do której maksymalnie zostanie wylosowana liczba");
                powrot2:
                int wybor2 = int.Parse(Console.ReadLine());
                if (wybor2 <= 1)
                {
                    Console.WriteLine("Prosze wybrać liczbe całkowitą oraz większą od 1");
                    goto powrot2;
                }
                else
                {
                    zakres = wybor2;
                    return zakres;
                }
                
                
                 }
            else
            {
                goto powrot;
            }
        }
        static int Losowanieoszustwa()
        {
            Random nieznana2 = new Random();
            int los2 = nieznana2.Next(1, 10);
            return los2;
        }
        static int Oszustwo()
        {
            int fortuna = 0;
            Losowanieoszustwa();
            int los2 = Losowanieoszustwa(); 
            
            if (los2 == 5 )
            {
                
                    
                    fortuna = 1; 
                    return fortuna ;
                
                  

            }
            else
            {
                fortuna = 0;
                return fortuna;
            }
        }
    }
}

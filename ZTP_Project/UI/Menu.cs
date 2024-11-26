using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Decorators;
using ZTP_Project.FactoryMethod;
using ZTP_Project.Singleton;

namespace ZTP_Project.UI
{
    public static class Menu
    {
        public static void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Budżet Domowy ===");
                Console.WriteLine("1. Wyświetl saldo");
                Console.WriteLine("2. Dodaj wydatek");
                Console.WriteLine("3. Wyświetl wydatki");
                Console.WriteLine("4. Eksportuj do CSV");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybierz opcję: ");

                string wybor = Console.ReadLine();
                switch (wybor)
                {
                    case "1":
                        WyswietlSaldo();
                        break;
                    case "2":
                        DodajWydatek();
                        break;
                    case "3":
                        WyswietlWydatki();
                        break;
                    case "4":
                        EksportujDoCSV();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Naciśnij Enter, aby kontynuować.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void WyswietlSaldo()
        {
            var budzet = GlobalnyBudzet.GetInstance().Budzet;
            Console.WriteLine($"\nPrzychody: {budzet.Przychody:C}");
            Console.WriteLine($"Wydatki: {budzet.Wydatki.Sum(w => w.Kwota):C}");
            Console.WriteLine($"Saldo: {budzet.ObliczSaldo():C}");
            Console.WriteLine("\nNaciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }

        private static void DodajWydatek()
        {
            Console.Write("\nPodaj nazwę wydatku: ");
            string nazwa = Console.ReadLine();
            Console.Write("Podaj kwotę wydatku: ");
            decimal kwota = decimal.Parse(Console.ReadLine());
            Console.Write("Podaj kategorię wydatku: ");
            string kategoria = Console.ReadLine();

            var wydatek = WydatekFactory.UtworzWydatek(nazwa, kwota, kategoria);
            GlobalnyBudzet.GetInstance().Budzet.DodajWydatek(wydatek);

            Console.WriteLine("Wydatek dodany! Naciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }

        private static void WyswietlWydatki()
        {
            var budzet = GlobalnyBudzet.GetInstance().Budzet;

            Console.WriteLine("\n=== Lista wydatków ===");
            foreach (var wydatek in budzet.Wydatki)
            {
                Console.WriteLine($"- {wydatek.Nazwa}: {wydatek.Kwota:C} ({wydatek.Kategoria})");
            }

            Console.WriteLine("\nNaciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }

        private static void EksportujDoCSV()
        {
            var budzet = GlobalnyBudzet.GetInstance().Budzet;
            var eksport = new EksportDoCSV();

            string csv = eksport.Eksportuj(budzet.Wydatki);
            Console.WriteLine("\n=== Eksport CSV ===");
            Console.WriteLine(csv);
            Console.WriteLine("\n(Uwaga: W tej wersji CSV jest wyświetlane w konsoli. Zapisywanie do pliku można łatwo dodać.)");
            Console.WriteLine("Naciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }
    }
}

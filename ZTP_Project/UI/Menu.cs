using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Decorators;
using ZTP_Project.FactoryMethod;
using ZTP_Project.Singleton;
using ZTP_Project.Strategies;

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
                Console.WriteLine("5. Eksportuj do CSV z Data");
                Console.WriteLine("6. Generuj Raport ");
                Console.WriteLine("7. Wyjście");
                Console.Write("Wybierz opcję: ");

                string wybor = Console.ReadLine();
                switch (wybor)
                {
                    case "1":
                        WyswietlSaldo();
                        break;
                    case "2":
                        DodajWydatek(new WydatekFactory());
                        break;
                    case "3":
                        WyswietlWydatki();
                        break;
                    case "4":
                        EksportujDoCSV();
                        break;
                    case "5":
                        EksportujDoCSVZData();
                        break;
                    case "6":
                        GenerujRaport();
                        break;
                    case "7":
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

        private static void DodajWydatek(IWydatekFactory factory)
        {
            Console.Write("\nPodaj nazwę wydatku: ");
            string nazwa = Console.ReadLine();
            Console.Write("Podaj kwotę wydatku: ");
            decimal kwota = decimal.Parse(Console.ReadLine());
            Console.Write("Podaj kategorię wydatku: ");
            string kategoria = Console.ReadLine();

            var budzet = GlobalnyBudzet.GetInstance().Budzet;
            budzet.DodajWydatek(factory, nazwa, kwota, kategoria, DateTime.Now);

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
        private static void EksportujDoCSVZData()
        {
            var budzet = GlobalnyBudzet.GetInstance().Budzet;
            var eksport = new EksportDoCSV();

            // Dekorowanie eksportu do CSV, aby dodać datę
            EksportBase eksportZData = new EksportZDataDecorator(eksport);

            // Eksport z datą
            string csv = eksportZData.Eksportuj(budzet.Wydatki);
            Console.WriteLine("\n=== Eksport CSV z datą ===");
            Console.WriteLine(csv);
            Console.WriteLine("\n(Naciśnij Enter, aby kontynuować...)");
            Console.ReadLine();
        }
        private static void GenerujRaport()
        {

            var budzet = GlobalnyBudzet.GetInstance().Budzet;

            Console.WriteLine("Wybierz rodzaj raportu:");
            Console.WriteLine("1. Miesięczny raport");
            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            IRaportStrategy raportStrategy = wybor switch
            {
                "1" => new MiesiecznyRaportStrategy(),
                _ => throw new ArgumentException("Nieznany typ raportu")
            };

            string raport = budzet.GenerujRaport(raportStrategy);

            Console.WriteLine("\n=== Raport ===");
            Console.WriteLine(raport);
            Console.WriteLine("\nNaciśnij Enter, aby kontynuować...");
            Console.ReadLine();
        }
    }
}

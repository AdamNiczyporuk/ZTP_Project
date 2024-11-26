using ZTP_Project.Decorators;
using ZTP_Project.FactoryMethod;
using ZTP_Project.Observers;
using ZTP_Project.Singleton;

class Program
{
    static void Main(string[] args)
    {
        var budzet = GlobalnyBudzet.GetInstance().Budzet;
        var powiadomienie = new LimitPowiadomienie();

        budzet.Przychody = 5000;
        budzet.Limit = 4000;

        var wydatek1 = WydatekFactory.UtworzWydatek("Jedzenie", 1000, "Jedzenie");
        var wydatek2 = WydatekFactory.UtworzWydatek("Transport", 500, "Transport");

        budzet.DodajWydatek(wydatek1);
        budzet.DodajWydatek(wydatek2);

        powiadomienie.Powiadom(budzet.Wydatki.Sum(w => w.Kwota), budzet.Limit);

        var eksport = new EksportDoCSV();
        Console.WriteLine("Eksport do CSV:\n" + eksport.Eksportuj(budzet.Wydatki));
    }
}
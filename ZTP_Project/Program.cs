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

        // Dodanie wydatków
        var wydatek1 = WydatekFactory.UtworzWydatek("Jedzenie", 1000, "Jedzenie");
        var wydatek2 = WydatekFactory.UtworzWydatek("Transport", 500, "Transport");

        budzet.DodajWydatek(wydatek1);
        budzet.DodajWydatek(wydatek2);

        if (budzet.Limit < budzet.Wydatki.Sum(x => x.Kwota))
            powiadomienie.Powiadom("Przekroczono limit!");

        Console.WriteLine("Budżet gotowy!");
    }
}
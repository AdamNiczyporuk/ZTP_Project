using ZTP_Project.Decorators;
using ZTP_Project.FactoryMethod;
using ZTP_Project.Models;
using ZTP_Project.Observers;
using ZTP_Project.Singleton;
using ZTP_Project.UI;

class Program
{
    static void Main(string[] args)
    {
        // Inicjalizacja budżetu
        var budzet = GlobalnyBudzet.GetInstance().Budzet;
        budzet.Przychody = 5000;
        budzet.Limit = 4000;
       

        // Uruchomienie menu
        Menu.Start();
    }
}
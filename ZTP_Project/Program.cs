
using ZTP_Project.Controllers;
using ZTP_Project.Models;



class Program
{
    static void Main(string[] args)
    {
        var mainController = new MainController();
        mainController.StartMainMenu();

    }
}
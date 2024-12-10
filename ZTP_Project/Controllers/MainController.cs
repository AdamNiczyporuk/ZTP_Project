using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models.Singleton;
using ZTP_Project.Views;

namespace ZTP_Project.Controllers
{
    public class MainController
    {
        private HomeBudget homeBudget;
        private MainView mainView;
        public MainController()
        {
            homeBudget = HomeBudget.GetInstance();
            mainView = new MainView();
        }
        public void StartMainMenu()
        {
            var option = mainView.DisplayMainMenu();
        }
    }
}

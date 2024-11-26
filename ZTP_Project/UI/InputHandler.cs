using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.UI
{
    public static class InputHandler
    {
        public static decimal GetDecimalInput(string prompt)
        {
            Console.Write(prompt);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie.");
                Console.Write(prompt);
            }
            return result;
        }

        public static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    public interface IScreen
    {
        public abstract static void GetAllScreen();
        public abstract static void GetByIDScreen();
        public abstract static void UpdateScreen();
        public abstract static void DeleteScreen();
        public abstract static void AddNewScreen();

    }
    public static class Screen
    {
        public static void ClearScreen()
        {
            Console.Write("Press any key to return to the menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Clock()
        {
            Console.WriteLine($"\t   {DateTime.Now}");
        }
        public static void Draw(string message)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 60));
            Clock();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"\t\t{message}");
            Console.WriteLine(new string('-', 60));
        }
    }
}

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
            Console.Write("Press to any key to clear screen");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Clock()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"\t   {DateTime.Now}");
            Console.WriteLine(new string('-', 60));

        }
        public static void Draw(string message)
        {
            Clock();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"\t\t{message}");
            Console.WriteLine(new string('-', 60));

        }
    }
}

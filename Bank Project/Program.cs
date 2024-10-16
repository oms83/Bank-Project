using Bank_Project.Person;

namespace Bank_Project
{
    public class Program
    {
        public static void PeopleMenue()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New Person: ");
            Console.WriteLine("\t[2] Update Person: ");
            Console.WriteLine("\t[3] Delete Person: ");
            Console.WriteLine("\t[4] List All People: ");
            Console.WriteLine("\t[5] Main Menue: ");
            Console.WriteLine(new string('-', 60));
        }

        public static void MainScreen()
        {

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Manage People: ");
            Console.WriteLine("\t[2] Manage Users: ");
            Console.WriteLine("\t[3] Manage Clients: ");
            Console.WriteLine("\t[4] Manage Countries: ");
            Console.WriteLine("\t[5] Logout: ");
            Console.WriteLine(new string('-', 60));
        }
        public static void Start()
        {
            int Choice = clsValidation.GetEnterBetweenNM(1, 5);

        }
        public static void Main(string[] args)
        {
            Screen.Clock();
            Screen.ClearScreen();
            clsPersonView.GetAllScreen();
            
        }
    }
}
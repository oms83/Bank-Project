using Bank_Project.Person;
using Bank_Project.Repository;

namespace Bank_Project
{
    public class Program
    {
        public enum enMenuChoices { PeopleMenu=1, UsersMenu, ClientsMenu, CountriesMenu, Login };
        public enum enChoices { AddNew=1, Update, Delete, ListAll, Find, MainMenu }
        public static void PeopleMenu()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New Person: ");
            Console.WriteLine("\t[2] Update Person: ");
            Console.WriteLine("\t[3] Delete Person: ");
            Console.WriteLine("\t[4] List All People: ");
            Console.WriteLine("\t[5] Get Person By ID: ");
            Console.WriteLine("\t[6] Main Menue: ");
            Console.WriteLine(new string('-', 60));

            int Choice;
            Choice = clsValidation.GetEnterBetweenNM(1, 6);

            switch (Choice)
            {
                case (int)enChoices.AddNew:
                    clsPersonView.AddNewScreen();
                    break;
                case (int)enChoices.Update:
                    clsPersonView.UpdateScreen(); 
                    break;
                case (int)enChoices.Delete:
                    clsPersonView.DeleteScreen();
                    break;
                case (int)enChoices.ListAll:
                    clsPersonView.GetAllScreen();
                    break;
                case (int)enChoices.Find:
                    clsPersonView.GetByIDScreen();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void UsersMenu()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New User: ");
            Console.WriteLine("\t[2] Update User: ");
            Console.WriteLine("\t[3] Delete User: ");
            Console.WriteLine("\t[4] List All Users: ");
            Console.WriteLine("\t[5] Get User By ID: ");
            Console.WriteLine("\t[6] Main Menu: ");
            Console.WriteLine(new string('-', 60));

            int choice = clsValidation.GetEnterBetweenNM(1, 6);

            switch (choice)
            {
                case (int)enChoices.AddNew:
                    clsUserView.AddNewScreen();
                    break;
                case (int)enChoices.Update:
                    clsUserView.UpdateScreen();
                    break;
                case (int)enChoices.Delete:
                    clsUserView.DeleteScreen();
                    break;
                case (int)enChoices.ListAll:
                    clsUserView.GetAllScreen();
                    break;
                case (int)enChoices.Find:
                    clsUserView.GetByIDScreen();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void ClientsMenu()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New Client: ");
            Console.WriteLine("\t[2] Update Client: ");
            Console.WriteLine("\t[3] Delete Client: ");
            Console.WriteLine("\t[4] List All Clients: ");
            Console.WriteLine("\t[5] Get Client By ID: ");
            Console.WriteLine("\t[6] Main Menu: ");
            Console.WriteLine(new string('-', 60));

            int choice = clsValidation.GetEnterBetweenNM(1, 6);

            switch (choice)
            {
                case (int)enChoices.AddNew:
                    clsClientView.AddNewScreen();
                    break;
                case (int)enChoices.Update:
                    clsClientView.UpdateScreen();
                    break;
                case (int)enChoices.Delete:
                    clsClientView.DeleteScreen();
                    break;
                case (int)enChoices.ListAll:
                    clsClientView.GetAllScreen();
                    break;
                case (int)enChoices.Find:
                    clsClientView.GetByIDScreen();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void CountriesMenu()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New Country: ");
            Console.WriteLine("\t[2] Update Country: ");
            Console.WriteLine("\t[3] Delete Country: ");
            Console.WriteLine("\t[4] List All Countries: ");
            Console.WriteLine("\t[5] Get Country By ID: ");
            Console.WriteLine("\t[6] Main Menu: ");
            Console.WriteLine(new string('-', 60));

            int choice = clsValidation.GetEnterBetweenNM(1, 6);

            switch (choice)
            {
                case (int)enChoices.AddNew:
                    clsCountryView.AddNewScreen();
                    break;
                case (int)enChoices.Update:
                    clsCountryView.UpdateScreen();
                    break;
                case (int)enChoices.Delete:
                    clsCountryView.DeleteScreen();
                    break;
                case (int)enChoices.ListAll:
                    clsCountryView.GetAllScreen();
                    break;
                case (int)enChoices.Find:
                    clsCountryView.GetByIDScreen();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void LoginScreen()
        {

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
            int Choice;

            do
            {
                Choice = clsValidation.GetEnterBetweenNM(1, 5);

                switch (Choice)
                {
                    case (int)enMenuChoices.PeopleMenu:
                        Console.Clear();
                        PeopleMenu();
                        break;

                    case (int)enMenuChoices.UsersMenu:
                        Console.Clear();
                        UsersMenu();
                        break;

                    case (int)enMenuChoices.ClientsMenu:
                        Console.Clear();
                        ClientsMenu();
                        break;

                    case (int)enMenuChoices.CountriesMenu:
                        Console.Clear();
                        CountriesMenu();
                        break;

                    case (int)enMenuChoices.Login:
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(1000);
                        LoginScreen();
                        break;
                }

            } while (Choice != 0);
        }
        public static void Main(string[] args)
        {
            clsRepository.PersonClusteredID = clsRepository.lstPeople.Count;
            clsRepository.UserClusteredID = clsRepository.lstUsers.Count;
            clsRepository.ClientClusteredID = clsRepository.lstClients.Count;
            clsRepository.CountryClusteredID = clsRepository.lstCountries.Count;

            MainScreen();


        }
    }
}
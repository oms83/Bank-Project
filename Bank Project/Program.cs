using Bank_Project.Person;
using Bank_Project.Repository;

namespace Bank_Project
{
    public class Program
    {
        public enum enMenuChoices { PeopleMenu=1, UsersMenu, ClientsMenu, CountriesMenu, Login };
        public enum enChoices { AddNew=1, Update=2, Delete=3, ListAll=4, Find=5, MainMenu=6, Deposit=7, Withdraw=8 }
        public static void PeopleMenu()
        {
            Screen.Draw("Manage People Menu");
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
                    Screen.ClearScreen();
                    PeopleMenu();
                    break;
                case (int)enChoices.Update:
                    clsPersonView.UpdateScreen();
                    Screen.ClearScreen();
                    PeopleMenu();
                    break;
                case (int)enChoices.Delete:
                    clsPersonView.DeleteScreen();
                    Screen.ClearScreen();
                    PeopleMenu();
                    break;
                case (int)enChoices.ListAll:
                    clsPersonView.GetAllScreen();
                    Screen.ClearScreen();
                    PeopleMenu();
                    break;
                case (int)enChoices.Find:
                    clsPersonView.GetByIDScreen();
                    Screen.ClearScreen();
                    PeopleMenu();
                    break;
                case (int)enChoices.MainMenu:
                    Console.Clear();
                    MainScreen();
                    break;
            }
        }

        public static void UsersMenu()
        {
            Screen.Draw("Manage Users Menu");

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
                    Screen.ClearScreen();
                    UsersMenu();
                    break;
                case (int)enChoices.Update:
                    clsUserView.UpdateScreen();
                    Screen.ClearScreen();
                    UsersMenu();
                    break;
                case (int)enChoices.Delete:
                    clsUserView.DeleteScreen();
                    Screen.ClearScreen();
                    break;
                case (int)enChoices.ListAll:
                    clsUserView.GetAllScreen();
                    Screen.ClearScreen();
                    UsersMenu();
                    break;
                case (int)enChoices.Find:
                    clsUserView.GetByIDScreen();
                    Screen.ClearScreen();
                    UsersMenu();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void ClientsMenu()
        {
            Screen.Draw("Manage Clients Menu");

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("\t[1] Add New Client: ");
            Console.WriteLine("\t[2] Update Client: ");
            Console.WriteLine("\t[3] Delete Client: ");
            Console.WriteLine("\t[4] List All Clients: ");
            Console.WriteLine("\t[5] Get Client By ID: ");
            Console.WriteLine("\t[6] Main Menu: ");
            Console.WriteLine("\t[7] Deposit: ");
            Console.WriteLine("\t[8] Withdraw: ");
            Console.WriteLine(new string('-', 60));

            int choice = clsValidation.GetEnterBetweenNM(1, 8);

            switch (choice)
            {
                case (int)enChoices.AddNew:
                    clsClientView.AddNewScreen();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.Update:
                    clsClientView.UpdateScreen();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.Delete:
                    clsClientView.DeleteScreen();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.ListAll:
                    clsClientView.GetAllScreen();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.Find:
                    clsClientView.GetByIDScreen();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.Deposit:
                    clsClientView.Deposit();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.Withdraw:
                    clsClientView.Withdraw();
                    Screen.ClearScreen();
                    ClientsMenu();
                    break;
                case (int)enChoices.MainMenu:
                    MainScreen();
                    break;
            }
        }

        public static void CountriesMenu()
        {
            Screen.Draw("Manage Countries Menu");

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
                    Screen.ClearScreen();
                    CountriesMenu();
                    break;
                case (int)enChoices.Update:
                    clsCountryView.UpdateScreen();
                    Screen.ClearScreen();
                    CountriesMenu();
                    break;
                case (int)enChoices.Delete:
                    clsCountryView.DeleteScreen();
                    Screen.ClearScreen();
                    CountriesMenu();
                    break;
                case (int)enChoices.ListAll:
                    clsCountryView.GetAllScreen();
                    Screen.ClearScreen();
                    CountriesMenu();
                    break;
                case (int)enChoices.Find:
                    clsCountryView.GetByIDScreen();
                    Screen.ClearScreen();
                    CountriesMenu();
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
            Screen.Draw("Main Menu");

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
using Bank_Project.Client;
using Bank_Project.Country;
using Bank_Project.Person;
using Bank_Project.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Repository
{
    public class clsRepository
    {
        public static int PersonClusteredID;

        public static int UserClusteredID;

        public static int ClientClusteredID;

        public static int CountryClusteredID;

        public static List<PersonDTO> lstPeople = new List<PersonDTO>()
            {
                new PersonDTO { PersonID = 1, FirstName = "Ömer",   LastName = "MEMES",  DateOfBirth = new DateTime(2000, 3, 8),   CountryID = 1 },
                new PersonDTO { PersonID = 2, FirstName = "Ahmet",  LastName = "YILMAZ", DateOfBirth = new DateTime(1995, 5, 20),  CountryID = 1 },
                new PersonDTO { PersonID = 3, FirstName = "Ali",    LastName = "KAYA",   DateOfBirth = new DateTime(1998, 12, 15), CountryID = 2 },
                new PersonDTO { PersonID = 4, FirstName = "Fatma",  LastName = "DEMIR",  DateOfBirth = new DateTime(1990, 7, 10),  CountryID = 3 },
                new PersonDTO { PersonID = 5, FirstName = "Leyla",  LastName = "CAN",    DateOfBirth = new DateTime(2002, 1, 25),  CountryID = 1 },
                new PersonDTO { PersonID = 6, FirstName = "Mehmet", LastName = "UZUN",   DateOfBirth = new DateTime(1988, 6, 30),  CountryID = 4 },
                new PersonDTO { PersonID = 7, FirstName = "Elif",   LastName = "KOÇ",    DateOfBirth = new DateTime(1993, 8, 5),   CountryID = 5 },
                new PersonDTO { PersonID = 8, FirstName = "Yusuf",  LastName = "ÖZTÜRK", DateOfBirth = new DateTime(1997, 3, 18),  CountryID = 2 },
                new PersonDTO { PersonID = 9, FirstName = "Zeynep", LastName = "ÇETIN",  DateOfBirth = new DateTime(1992, 10, 28), CountryID = 3 },
                new PersonDTO { PersonID = 10, FirstName = "Hasan", LastName = "SAHIN",  DateOfBirth = new DateTime(1985, 2, 14),  CountryID = 4 }
            };

        public static List<UserDTO> lstUsers = new List<UserDTO>()
        {
            new UserDTO { UserID = 1, UserName = "oms83", Password = "0000", PersonID = 1 },
            new UserDTO { UserID = 2, UserName = "ali20", Password = "0000", PersonID = 2 },
        };

        public static List<CountryDTO> lstCountries = new List<CountryDTO>()
        {
            new CountryDTO { CountryID = 1, CountryName = "Turkey" },
            new CountryDTO { CountryID = 2, CountryName = "Syria" },
            new CountryDTO { CountryID = 3, CountryName = "Lebanon" },
            new CountryDTO { CountryID = 4, CountryName = "Jordan" },
            new CountryDTO { CountryID = 5, CountryName = "Iraq" },
            new CountryDTO { CountryID = 6, CountryName = "Egypt" },
            new CountryDTO { CountryID = 7, CountryName = "Libya" },
            new CountryDTO { CountryID = 8, CountryName = "Tunisia" },
            new CountryDTO { CountryID = 9, CountryName = "Algeria" },
            new CountryDTO { CountryID = 10, CountryName = "Morocco" }
        };

        public static List<ClientDTO> lstClients = new List<ClientDTO>()
        {
            new ClientDTO { ClientID = 1, AccountNumber = "ACC10001", Balance = 1500m, PersonID = 1 },
            new ClientDTO { ClientID = 2, AccountNumber = "ACC10002", Balance = 2500m, PersonID = 2 },
            new ClientDTO { ClientID = 3, AccountNumber = "ACC10003", Balance = 3500m, PersonID = 3 },
            new ClientDTO { ClientID = 4, AccountNumber = "ACC10004", Balance = 4500m, PersonID = 4 },
            new ClientDTO { ClientID = 5, AccountNumber = "ACC10005", Balance = 5500m, PersonID = 5 },
            new ClientDTO { ClientID = 6, AccountNumber = "ACC10006", Balance = 6500m, PersonID = 6 },
            new ClientDTO { ClientID = 7, AccountNumber = "ACC10007", Balance = 7500m, PersonID = 7 },
            new ClientDTO { ClientID = 8, AccountNumber = "ACC10008", Balance = 8500m, PersonID = 8 },
            new ClientDTO { ClientID = 9, AccountNumber = "ACC10009", Balance = 9500m, PersonID = 9 },
            new ClientDTO { ClientID = 10, AccountNumber = "ACC10010", Balance = 10500m, PersonID = 10 }
        };
    }
}

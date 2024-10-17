using Bank_Project.Repository;
using Bank_Project.Validation;

namespace Bank_Project.Person
{
    public class clsPersonView : IScreen
    {
        public static void DeleteScreen()
        {
            Screen.Draw("Delete Person By ID");
            clsPerson person = _GetPersonByID();
            clsPerson.DeletePersonByID(person.PersonID);
        }
        public static void GetAllScreen()
        {
            Screen.Draw("List All People");

            Console.WriteLine($"{"ID".PadRight(8)} {"First Name".PadRight(15)} {"Last Name".PadRight(20)} {"Date of Birth".PadRight(15)}");
            Console.WriteLine(new string('-', 60)); 

            foreach (var person in clsRepository.lstPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private static clsPerson _GetPersonByID()
        {
            int personID = default;

            personID = clsValidation.GetPositiveNumber("Enter person id: ");

            PersonDTO? person = null;

            while ((person = clsRepository.lstPeople.Find(p => p.PersonID == personID)) is null)
            {
                personID = clsValidation.GetPositiveNumber("Enter person id: ");
            }

            return new clsPerson(person, clsPerson.enMode.Update);
        }
        public static void GetByIDScreen()
        {
            Screen.Draw("Get Person By ID");

            clsPerson person = _GetPersonByID();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"ID".PadRight(8)} {"First Name".PadRight(15)} {"Last Name".PadRight(20)} {"Date of Birth".PadRight(15)}");
            Console.WriteLine(person.personDTO.ToString());
            Console.WriteLine(new string('-', 60));

        }
        private static PersonDTO _GetPersonInfo()
        {
            PersonDTO person = new PersonDTO();
            person.FirstName = clsValidation.GetString("Enter your first name: ");
            person.LastName = clsValidation.GetString("Enter your last name: ");
            person.DateOfBirth = clsValidation.GetDate("Please enter your date of birth(yyyy - mm - dd) :");
            int countryID;

            do
            {
                countryID = clsValidation.GetPositiveNumber("Enter your country id: ");

            } while (!clsRepository.lstCountries.Exists(country => country.CountryID == countryID));

            person.CountryID = countryID;

            return person;
        }
        public static void UpdateScreen()
        {
            Screen.Draw("Update Person Info");

            clsPerson person = _GetPersonByID();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"ID".PadRight(8)} {"First Name".PadRight(15)} {"Last Name".PadRight(20)} {"Date of Birth".PadRight(15)}");
            Console.WriteLine(person.personDTO.ToString());
            Console.WriteLine(new string('-', 60));

            PersonDTO updatedPerson = _GetPersonInfo();

            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;
            person.DateOfBirth = updatedPerson.DateOfBirth;
            person.CountryID = updatedPerson.CountryID;

            person.Save();

        }

        public static void AddNewScreen()
        {
            Screen.Draw("Add Person New");

            PersonDTO person = _GetPersonInfo();

            clsPerson insertedPerson = new clsPerson(person, clsPerson.enMode.AddNew);
            
            insertedPerson.Save();

            person.PersonID = insertedPerson.PersonID;

        }
    }
}

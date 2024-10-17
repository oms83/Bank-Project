using Bank_Project.Repository;
using System;
using System.Globalization;
using static Bank_Project.Person.clsPerson;

namespace Bank_Project.Person
{
    public class PersonDTO
    {
        public PersonDTO(int personID, string? firstName, string? lastName, DateTime? dateOfBirth, int countryID)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
        }
        public PersonDTO()
        {
            
        }
        public int PersonID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public short Age => Convert.ToInt16(DateTime.Now.Year - DateOfBirth?.Year);

        public override string ToString()
        {
            return $"{PersonID.ToString().PadRight(8)} {FirstName?.PadRight(15)} {LastName?.PadRight(20)} {DateOfBirth?.ToString("yyyy-MM-dd").PadRight(15)}";
        }

    }

    public class clsPersonData
    {
        public static List<PersonDTO>? GetAllPersonData()
        {
            return clsRepository.lstPeople.Count == 0 ? clsRepository.lstPeople : null;
        }

        public static PersonDTO? GetPersonByIDData(int id)
        {
            return clsRepository.lstPeople.FirstOrDefault(person => person.PersonID == id);
        }

        public static int AddNewPersonData(PersonDTO personDTO)
        {
            personDTO.PersonID = clsRepository.lstPeople.Count == 0 ? 1 : (clsRepository.PersonClusteredID += 1);

            clsRepository.lstPeople.Add(personDTO);
            
            return personDTO.PersonID;
        }

        public static bool UpdatePersonData(int id, PersonDTO dto)
        {
            PersonDTO? person = clsRepository.lstPeople.FirstOrDefault(p => p.PersonID == id);
            
            if (person is null)
            {
                return false;
            }

            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.DateOfBirth = dto.DateOfBirth;
            person.CountryID = dto.CountryID;
            
            return true;
        }

        public static bool DeletePersonData(int id)
        {
            PersonDTO? person = GetPersonByIDData(id);

            if (person is null)
            {
                return false;
            }

            return clsRepository.lstPeople.Remove(person);
        }

    }
}

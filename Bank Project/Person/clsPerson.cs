using Bank_Project.Country;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Bank_Project.Person
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        public int PersonID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public short Age => Convert.ToInt16(DateTime.Now.Year - DateOfBirth?.Year);

        public clsCountry? Nationality;
        public PersonDTO personDTO
        {
            get
            {
                return new PersonDTO(PersonID, FirstName, LastName, DateOfBirth, CountryID);
            }
        }
        public clsPerson(PersonDTO personDTO, enMode mode = enMode.AddNew)
        {
            this.PersonID = personDTO.PersonID;
            this.FirstName = personDTO.FirstName;
            this.LastName = personDTO.LastName;
            this.DateOfBirth = personDTO.DateOfBirth;
            this.CountryID = personDTO.CountryID;

            Nationality = clsCountry.GetCountryByID(this.CountryID);

            this._Mode = mode;
        }
        public clsPerson()
        {
            
        }
        public static bool DeletePersonByID(int id)
        {
           return clsPersonData.DeletePersonData(id);
        }
        public static clsPerson? GetPersonByID(int id)
        {
            PersonDTO? dto = clsPersonData.GetPersonByIDData(id);

            if (dto is not null)
            {
                return new clsPerson(dto, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPersonData(this.personDTO);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePersonData(this.PersonID, this.personDTO);
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }
        
    }
}

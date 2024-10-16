using System;

namespace Bank_Project.Country
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        public int CountryID { get; set; }
        public string? CountryName { get; set; }

        public CountryDTO CountryDTO
        {
            get
            {
                return new CountryDTO(CountryID, CountryName);
            }
        }

        public clsCountry(CountryDTO countryDTO, enMode mode = enMode.AddNew)
        {
            this.CountryID = countryDTO.CountryID;
            this.CountryName = countryDTO.CountryName;
            this._Mode = mode;
        }
        public clsCountry()
        {
            
        }
        public static bool DeleteCountryByID(int id)
        {
            return clsCountryData.DeleteCountryData(id);
        }
        public static clsCountry? GetCountryByID(int id)
        {
            CountryDTO? dto = clsCountryData.GetCountryByIDData(id);

            if (dto is not null)
            {
                return new clsCountry(dto, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryData.AddNewCountryData(this.CountryDTO);
            return this.CountryID != -1;
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountryData(this.CountryID, this.CountryDTO);
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCountry();
            }

            return false;
        }
    }
}

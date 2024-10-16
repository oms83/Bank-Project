using Bank_Project.Repository;
using System;

namespace Bank_Project.Country
{
    public class CountryDTO
    {
        public CountryDTO(int countryID, string? countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }
        public CountryDTO()
        {
        }

        public int CountryID { get; set; }
        public string? CountryName { get; set; }
        public override string ToString()
        {
            return $"{CountryID.ToString().PadRight(10)} {CountryName?.PadRight(30)}";
        }
    }

    public static class clsCountryData
    {
        public static List<CountryDTO>? GetAllCountryData()
        {
            return clsRepository.lstCountries.Count == 0 ? null : clsRepository.lstCountries;
        }

        public static CountryDTO? GetCountryByIDData(int id)
        {
            return clsRepository.lstCountries.FirstOrDefault(country => country.CountryID == id);
        }

        public static int AddNewCountryData(CountryDTO country)
        {
            country.CountryID = clsRepository.lstCountries.Count == 0 ? 1 : (clsRepository.CountryClusteredID += 1);
            clsRepository.lstCountries.Add(country);
            return country.CountryID;
        }

        public static bool UpdateCountryData(int id, CountryDTO updatedCountry)
        {
            CountryDTO? country = GetCountryByIDData(id);

            if (country == null) return false;

            country.CountryName = updatedCountry.CountryName;

            return true;
        }

        public static bool DeleteCountryData(int id)
        {
            CountryDTO? country = GetCountryByIDData(id);
            return country != null && clsRepository.lstCountries.Remove(country);
        }
    }

}

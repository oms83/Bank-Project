using Bank_Project.Country;
using Bank_Project.Repository;
using Bank_Project;
using System.Collections.Specialized;

public class clsCountryView : IScreen
{
    public static void DeleteScreen()
    {
        Screen.Draw("Delete Country By ID");
        clsCountry country = _GetCountryByID();
        clsCountry.DeleteCountryByID(country.CountryID);
    }

    public static void GetAllScreen()
    {
        Screen.Draw("List All Countries");

        Console.WriteLine($"{"Country ID".PadRight(10)} {"Country Name".PadRight(30)}");
        Console.WriteLine(new string('-', 40));

        foreach (var country in clsRepository.lstCountries)
        {
            Console.WriteLine(country.ToString());
        }
    }

    private static clsCountry _GetCountryByID()
    {
        int countryID = default;

        countryID = clsValidation.GetPositiveNumber("Enter country id: ");

        CountryDTO? country = null;

        while ((country = clsRepository.lstCountries.Find(c => c.CountryID == countryID)) is null)
        {
            countryID = clsValidation.GetPositiveNumber("Enter country id: ");
        }

        return new clsCountry(country, clsCountry.enMode.Update);
    }

    public static void GetByIDScreen()
    {
        Screen.Draw("Get Country By ID");

        clsCountry country = _GetCountryByID();

        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"{"Country ID".PadRight(10)} {"Country Name".PadRight(30)}");
        Console.WriteLine(country.CountryDTO.ToString());
        Console.WriteLine(new string('-', 40));
    }

    private static CountryDTO _GetCountryInfo()
    {
        CountryDTO country = new CountryDTO();
        country.CountryName = clsValidation.GetString("Enter country name: ");

        return country;
    }

    public static void UpdateScreen()
    {
        Screen.Draw("Update Country Info");

        clsCountry country = _GetCountryByID();

        Console.WriteLine(new string('-', 40));

        CountryDTO updatedCountry = _GetCountryInfo();

        country.CountryName = updatedCountry.CountryName;


        country.Save();
    }

    public static void AddNewScreen()
    {
        Screen.Draw("Add New Country");

        CountryDTO country = _GetCountryInfo();

        clsCountry insertedCountry = new clsCountry(country, clsCountry.enMode.AddNew);

        insertedCountry.Save();
    }
}

using Bank_Project.Country;
using Bank_Project.Repository;
using Bank_Project;

public class clsCountryView : IScreen
{
    public static void DeleteScreen()
    {
        Screen.Draw("Delete Country By ID");
        CountryDTO country = _GetCountryByID();
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

    private static CountryDTO _GetCountryByID()
    {
        int countryID = default;

        countryID = clsValidation.GetPositiveNumber("Enter country id: ");

        CountryDTO? country = null;

        while ((country = clsRepository.lstCountries.Find(c => c.CountryID == countryID)) is null)
        {
            countryID = clsValidation.GetPositiveNumber("Enter country id: ");
        }

        return country;
    }

    public static void GetByIDScreen()
    {
        Screen.Draw("Get Country By ID");

        CountryDTO country = _GetCountryByID();

        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"{"Country ID".PadRight(10)} {"Country Name".PadRight(30)}");
        Console.WriteLine(country.ToString());
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

        CountryDTO country = _GetCountryByID();

        Console.WriteLine(new string('-', 40));

        CountryDTO countryNewInfo = _GetCountryInfo();

        clsCountry updatedCountry = new clsCountry(countryNewInfo, clsCountry.enMode.Update);

        updatedCountry.Save();
    }

    public static void AddNewScreen()
    {
        Screen.Draw("Add New Country");

        CountryDTO country = _GetCountryInfo();

        clsCountry insertedCountry = new clsCountry(country, clsCountry.enMode.AddNew);

        insertedCountry.Save();
    }
}

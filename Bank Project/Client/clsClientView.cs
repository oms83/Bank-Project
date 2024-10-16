using Bank_Project.Client;
using Bank_Project.Repository;
using Bank_Project;

public class clsClientView : IScreen
{
    public static void DeleteScreen()
    {
        Screen.Draw("Delete Client By ID");
        ClientDTO client = _GetClientByID();
        clsClient.DeleteClientByID(client.ClientID);
    }

    public static void GetAllScreen()
    {
        Screen.Draw("List All Clients");

        Console.WriteLine($"{"Client ID".PadRight(10)} {"Account Number".PadRight(20)} {"Balance".PadRight(15)}");
        Console.WriteLine(new string('-', 50));

        foreach (var client in clsRepository.lstClients)
        {
            Console.WriteLine(client.ToString());
        }
    }

    private static ClientDTO _GetClientByID()
    {
        int clientID = default;

        clientID = clsValidation.GetPositiveNumber("Enter client id: ");

        ClientDTO? client = null;

        while ((client = clsRepository.lstClients.Find(c => c.ClientID == clientID)) is null)
        {
            clientID = clsValidation.GetPositiveNumber("Enter client id: ");
        }

        return client;
    }

    public static void GetByIDScreen()
    {
        Screen.Draw("Get Client By ID");

        ClientDTO client = _GetClientByID();

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"Client ID".PadRight(10)} {"Account Number".PadRight(20)} {"Balance".PadRight(15)}");
        Console.WriteLine(client.ToString());
        Console.WriteLine(new string('-', 50));
    }

    private static ClientDTO _GetClientInfo()
    {
        Console.WriteLine("Enter new client details:");
        ClientDTO client = new ClientDTO();
        client.AccountNumber = clsValidation.GetString("Enter account number: ");
        client.Balance = clsValidation.GetMultiplesOfFive("Enter balance: ");

        return client;
    }

    public static void UpdateScreen()
    {
        Screen.Draw("Update Client Info");

        ClientDTO client = _GetClientByID();

        Console.WriteLine(new string('-', 50));

        ClientDTO clientNewInfo = _GetClientInfo();

        clsClient updatedClient = new clsClient(clientNewInfo, clsClient.enMode.Update);

        updatedClient.Save();
    }

    public static void AddNewScreen()
    {
        Screen.Draw("Add New Client");

        ClientDTO client = _GetClientInfo();

        clsClient insertedClient = new clsClient(client, clsClient.enMode.AddNew);

        insertedClient.Save();
    }
}

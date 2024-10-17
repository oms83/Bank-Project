using Bank_Project.Client;
using Bank_Project.Repository;
using Bank_Project;
using Bank_Project.User;

public class clsClientView : IScreen
{
    public static void DeleteScreen()
    {
        Screen.Draw("Delete Client By ID");
        clsClient client = _GetClientByID();
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
    private static void _ClientInfo(clsClient client)
    {
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"Client ID".PadRight(10)} {"Account Number".PadRight(20)} {"Balance".PadRight(15)}");
        Console.WriteLine(client.ClientDTO.ToString());
        Console.WriteLine(new string('-', 50));
    }
    private static clsClient _GetClientByID()
    {
        int clientID = default;

        clientID = clsValidation.GetPositiveNumber("Enter client id: ");

        ClientDTO? client = null;

        while ((client = clsRepository.lstClients.Find(c => c.ClientID == clientID)) is null)
        {
            clientID = clsValidation.GetPositiveNumber("Enter client id: ");
        }

        return new clsClient(client, clsClient.enMode.Update);
    }

    public static void GetByIDScreen()
    {
        Screen.Draw("Get Client By ID");

        clsClient client = _GetClientByID();

        _ClientInfo(client); 
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

        clsClient client = _GetClientByID();

        _ClientInfo(client);

        ClientDTO updatedClient = _GetClientInfo();

        client.AccountNumber = updatedClient.AccountNumber;
        client.Balance = updatedClient.Balance;

        client.Save();
    }

    public static void Deposit()
    {
        clsClient client = _GetClientByID();
        
        _ClientInfo(client);

        int amount = clsValidation.GetMultiplesOfFive("Enter amount in multiples of five: ");

        client.Deposit(amount);

        Console.WriteLine($"Balance after update: {client.Balance}");
    }

    public static void Withdraw()
    {
        clsClient client = _GetClientByID();

        _ClientInfo(client);

        int amount = clsValidation.GetMultiplesOfFive("Enter amount in multiples of five: ");

        client.Withdraw(amount);

        Console.WriteLine($"Balance after update: {client.Balance}");
    }
    public static void AddNewScreen()
    {
        Screen.Draw("Add New Client");

        ClientDTO client = _GetClientInfo();

        clsClient insertedClient = new clsClient(client, clsClient.enMode.AddNew);

        insertedClient.Save();
    }
}

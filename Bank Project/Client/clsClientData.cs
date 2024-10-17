using Bank_Project.Repository;
using Bank_Project.Utility;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bank_Project.Client
{
    public class ClientDTO
    {
        public ClientDTO(int clientID, string accountNumber, decimal balance)
        {
            ClientID = clientID;
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public ClientDTO()
        {
            
        }
        public int ClientID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int PersonID { get; set; }
        public override string ToString()
        {
            return $"{ClientID.ToString().PadRight(10)} {AccountNumber.PadRight(20)} {Balance.ToString("C").PadRight(15)}";
        }
    }
    public static class clsClientData
    {
        public static List<ClientDTO>? GetAllClientData()
        {
            return clsRepository.lstClients.Count == 0 ? null : clsRepository.lstClients;
        }

        public static ClientDTO? GetClientByIDData(int id)
        {
            return clsRepository.lstClients.FirstOrDefault(client => client.ClientID == id);
        }

        public static int AddNewClientData(ClientDTO client)
        {
            client.ClientID = clsRepository.lstClients.Count == 0 ? 1 : (clsRepository.ClientClusteredID += 1);
            clsRepository.lstClients.Add(client);
            return client.ClientID;
        }

        public static bool UpdateClientData(int id, ClientDTO updatedClient)
        {
            ClientDTO? client = clsRepository.lstClients.FirstOrDefault(c => c.ClientID == id);

            if (client == null) return false;

            client.AccountNumber = updatedClient.AccountNumber;
            client.Balance = updatedClient.Balance;
            client.PersonID = updatedClient.PersonID;

            return true;
        }

        public static bool DeleteClientData(int id)
        {
            ClientDTO? client = GetClientByIDData(id);
            return client != null && clsRepository.lstClients.Remove(client);
        }
    }
}

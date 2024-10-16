using Bank_Project.Person;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank_Project.Client
{
    public class clsClient
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        public int ClientID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int PersonID { get; set; }
        public ClientDTO ClientDTO
        {
            get
            {
                return new ClientDTO(ClientID, AccountNumber, Balance);
            }
        }

        public clsPerson? Person;

        public clsClient(ClientDTO clientDTO, enMode mode = enMode.AddNew)
        {
            this.ClientID = clientDTO.ClientID;
            this.AccountNumber = clientDTO.AccountNumber;
            this.Balance = clientDTO.Balance;

            this.Person = clsPerson.GetPersonByID(PersonID);

            this._Mode = mode;
        }
        public clsClient()
        {
                
        }
        public static bool DeleteClientByID(int id)
        {
            return clsClientData.DeleteClientData(id);
        }
        public static clsClient? GetClientByID(int id)
        {
            ClientDTO? dto = clsClientData.GetClientByIDData(id);
            return dto is not null ? new clsClient(dto, enMode.Update) : null;
        }

        private bool _AddNewClient()
        {
            this.ClientID = clsClientData.AddNewClientData(this.ClientDTO);
            return this.ClientID != -1;
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClientData(this.ClientID, this.ClientDTO);
        }

        public bool Withdraw(int amount)
        {
            this.Balance -= amount;

            return _UpdateClient();
        }

        public bool Deposit(int amount)
        {
            this.Balance += amount;

            return _UpdateClient();
        }

        public bool Save()
        {
            return _Mode switch
            {
                enMode.AddNew => _AddNewClient() ? (_Mode = enMode.Update) != 0 : false,
                enMode.Update => _UpdateClient(),
                _ => false
            };
        }
    }
}

using Bank_Project.Person;
using System;

namespace Bank_Project.User
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int PersonID { get; set; }

        public UserDTO UserDTO
        {
            get
            {
                return new UserDTO(UserID, UserName, Password, PersonID);
            }
        }

        public clsPerson? Person;

        public clsUser(UserDTO userDTO, enMode mode = enMode.AddNew)
        {
            this.UserID = userDTO.UserID;
            this.UserName = userDTO.UserName;
            this.Password = userDTO.Password;
            this.PersonID = userDTO.PersonID;

            this.Person = clsPerson.GetPersonByID(PersonID);
            
            this._Mode = mode;
        }
        public clsUser()
        {
            
        }
        public static bool DeleteUserByID(int id)
        {
            return clsUserData.DeleteUserData(id);
        }
        public static clsUser? GetUserByID(int id)
        {
            UserDTO dto = clsUserData.GetUserByIDData(id);
            if (dto is not null)
            {
                return new clsUser(dto, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUserData(this.UserDTO);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUserData(this.UserID, this.UserDTO);
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
    }
}

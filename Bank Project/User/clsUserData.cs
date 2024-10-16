using Bank_Project.Repository;
using System.Collections.Generic;

namespace Bank_Project.User
{
    public class UserDTO
    {
        public UserDTO(int userID, string? userName, string? password, int personID)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            PersonID = personID;
        }
        public UserDTO()
        {
            
        }
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int PersonID { get; set; }
        public override string ToString()
        {
            return $"{UserID.ToString().PadRight(10)} {UserName.PadRight(20)} {PersonID.ToString().PadRight(15)}";
        }
    }

    public static class clsUserData
    {
        public static List<UserDTO>? GetAllUserData()
        {
            return clsRepository.lstUsers.Count == 0 ? null : clsRepository.lstUsers;
        }

        public static UserDTO? GetUserByIDData(int id)
        {
            return clsRepository.lstUsers.FirstOrDefault(user => user.UserID == id);
        }

        public static int AddNewUserData(UserDTO user)
        {
            user.UserID = clsRepository.lstUsers.Count == 0 ? 1 : (clsRepository.UserClusteredID += 1);
            clsRepository.lstUsers.Add(user);
            return user.UserID;
        }

        public static bool UpdateUserData(int id, UserDTO updatedUser)
        {
            UserDTO? user = GetUserByIDData(id);

            if (user == null) return false;

            user.UserName = updatedUser.UserName;
            user.Password = updatedUser.Password;
            user.PersonID = updatedUser.PersonID;

            return true;
        }

        public static bool DeleteUserData(int id)
        {
            UserDTO? user = GetUserByIDData(id);
            return user != null && clsRepository.lstUsers.Remove(user);
        }
    }
}

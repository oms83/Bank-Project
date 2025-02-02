﻿using Bank_Project.Repository;
using Bank_Project.User;
using Bank_Project;
using Bank_Project.Validation;

public class clsUserView : IScreen
{
    public static void DeleteScreen()
    {
        Screen.Draw("Delete User By ID");
        clsUser user = _GetUserByID();
        clsUser.DeleteUserByID(user.UserID);
    }

    public static void GetAllScreen()
    {
        Screen.Draw("List All Users");

        Console.WriteLine($"{"User ID".PadRight(10)} {"User Name".PadRight(20)} {"Person ID".PadRight(15)}");
        Console.WriteLine(new string('-', 50));

        foreach (var user in clsRepository.lstUsers)
        {
            Console.WriteLine(user.ToString());
        }
    }

    private static clsUser _GetUserByID()
    {
        int userID = default;

        userID = clsValidation.GetPositiveNumber("Enter user id: ");

        UserDTO? user = null;

        while ((user = clsRepository.lstUsers.Find(u => u.UserID == userID)) is null)
        {
            userID = clsValidation.GetPositiveNumber("Enter user id: ");
        }

        return new clsUser(user, clsUser.enMode.Update);
    }

    public static void GetByIDScreen()
    {
        Screen.Draw("Get User By ID");

        clsUser user = _GetUserByID();

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"User ID".PadRight(10)} {"User Name".PadRight(20)} {"Person ID".PadRight(15)}");
        Console.WriteLine(user.UserDTO.ToString());
        Console.WriteLine(new string('-', 50));
    }

    private static UserDTO _GetUserInfo()
    {
        UserDTO user = new UserDTO();
        user.UserName = clsValidation.GetString("Enter user name: ");
        user.Password = clsValidation.GetString("Enter password: ");
        user.PersonID = clsValidation.GetPositiveNumber("Enter person ID: ");

        return user;
    }

    public static void UpdateScreen()
    {
        Screen.Draw("Update User Info");

        clsUser user = _GetUserByID();

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"User ID".PadRight(10)} {"User Name".PadRight(20)} {"Person ID".PadRight(15)}");
        Console.WriteLine(user.UserDTO.ToString());
        Console.WriteLine(new string('-', 50));

        UserDTO updatedUser = _GetUserInfo();

        user.UserName = updatedUser.UserName;
        user.Password = updatedUser.Password;

        user.Save();
    }

    public static void AddNewScreen()
    {
        Screen.Draw("Add New User");

        UserDTO user = _GetUserInfo();

        clsUser insertedUser = new clsUser(user, clsUser.enMode.AddNew);

        insertedUser.Save();
    }
}

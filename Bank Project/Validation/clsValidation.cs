using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bank_Project.Validation
{
    public class clsValidation
    {
        public static int GetPositiveNumber(string Message)
        {
            int Number = default;
            do
            {
                Console.Write(Message);
                Number = Convert.ToInt32(Console.ReadLine());

            } while (Number < 0);

            return Number;
        }

        public static int GetMultiplesOfFive(string Message)
        {
            int Number = default;
            do
            {
                Number = GetPositiveNumber(Message);
            } while (Number % 5 != 0);

            return Number;
        }

        public static string GetString(string Message)
        {
            Console.Write(Message);
            return Console.ReadLine().Trim();
        }
        public static DateTime GetDate(string message)
        {
            Console.Write(message);

            string input = Console.ReadLine();
            //Please enter your date of birth(yyyy-mm - dd): 
            DateTime dt = DateTime.Now;

            while (!DateTime.TryParse(input, out DateTime dateOfBirth))
            {
                Console.Write(message);
                input = Console.ReadLine();
            }

            return Convert.ToDateTime(input);
        }
        public static int GetEnterBetweenNM(int min, int max)
        {
            int Number = default;

            do
            {
                Number = GetPositiveNumber($"Enter Number Between {min} and {max}: ");

            } while (Number < min || Number > max);

            return Number;
        }
    }
}

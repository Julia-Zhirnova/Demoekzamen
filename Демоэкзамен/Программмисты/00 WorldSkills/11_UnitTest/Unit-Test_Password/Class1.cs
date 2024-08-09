using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPassword
{
    public class PasswordChecker
    {
        public static bool validatePassword(string password)
        {
            if (password.Length < 8 || password.Length > 20)   //проверка длины пароля (если меньше 8 и не больше 20)
            {
                return false;
            }

            if (!password.Any(Char.IsLower))    //проверка наличия строчных символов
            {
                return false;
            }

            if (!password.Any(Char.IsUpper))    //проверка наличия заглавных символов
            {
                return false;
            }

            if (!password.Any(Char.IsDigit))    //проверка наличия цифр
            {
                return false;
            }

            if(password.Intersect("#$%^&_").Count() == 0)    //проверка наличия спецсимволов
            {
                return false;
            }

            return true;
        }
    }
}

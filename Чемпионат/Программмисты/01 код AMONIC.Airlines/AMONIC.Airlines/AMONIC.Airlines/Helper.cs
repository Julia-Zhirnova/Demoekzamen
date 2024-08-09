using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AMONIC.Airlines
{
    public class Helper
    {
        public static string Md5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password)))
                .Replace("-", "")
                .ToLower();
        }
        public static user10Entities context = new user10Entities();
        public static Users currentUser;
    }
}

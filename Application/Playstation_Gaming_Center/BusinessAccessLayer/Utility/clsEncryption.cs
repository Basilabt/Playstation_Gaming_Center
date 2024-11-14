using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace BusinessAccessLayer
{
    public class clsEncryption
    {

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }


    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace RentalManagement.Services
{
    public class Hashing
    {
        public static string HashPass(string userData)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(userData);
                byte[] hashBytes = sHA256.ComputeHash(inputBytes);

                StringBuilder builder1 = new StringBuilder();
                for(int i = 0; i< hashBytes.Length; i++)
                {
                    builder1.Append(hashBytes[i].ToString("x2"));
                }

                return builder1.ToString(); 
            }
        }
    }
}

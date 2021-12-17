using System.Text;
using System.Security.Cryptography;

namespace KravMagaAPI.Securities
{
    public class HashPassword
    {
        public static string Hash(string password)
        {
            //Guid salt = Guid.NewGuid();
            //byte[] bytes = Encoding.UTF8.GetBytes((salt.ToString() ?? "") + password + (salt.ToString() ?? ""));
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] encoded = SHA512.Create().ComputeHash(bytes);
            return Encoding.UTF8.GetString(encoded);
        }
    }
}

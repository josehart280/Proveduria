using System.Security.Cryptography;
using System.Text;
namespace Proveduria.Recursos
{
    public class Utilidades
    {

        public static string EncriptarClave(string contrasena)
        {
            if (string.IsNullOrEmpty(contrasena))
            {
                throw new ArgumentNullException(nameof(contrasena));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }




    }
}

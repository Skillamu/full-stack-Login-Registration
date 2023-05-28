using System.Security.Cryptography;

namespace full_stack_Login_Registration
{
    public static class PBKDF2
    {
        public static string HashPassword(string password, byte[] salt)
        {
            var iterations = 600000;
            var hashAlgorithm = HashAlgorithmName.SHA512;
            var outputLength = 64;

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, outputLength);

            return Convert.ToHexString(hash);
        }
    }
}
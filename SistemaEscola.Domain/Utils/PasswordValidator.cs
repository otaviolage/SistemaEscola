namespace SistemaEscola.Domain.Utils
{
    public class PasswordValidator
    {
        public static bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            string specialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";
            if (!password.Any(specialCharacters.Contains))
                return false;

            return true;
        }
    }
}
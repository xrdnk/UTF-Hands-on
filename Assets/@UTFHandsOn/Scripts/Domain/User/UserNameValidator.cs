using System.Text.RegularExpressions;

namespace Denity.UTFHandsOn.Domain.User
{
    public static class UserNameValidator
    {
        public static bool Validate(string name)
        {
            var regex = new Regex(@"^[a-zA-Z]{1,10}$");
            return regex.IsMatch(name);
        }
    }
}
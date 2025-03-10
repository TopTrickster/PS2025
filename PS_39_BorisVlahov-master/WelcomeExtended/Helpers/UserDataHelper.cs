using WelcomeExtended.Data;
using Welcome.Model;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Helpers
{
    public static class UserDataHelper
    {
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (name.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The name cannot be empty");
            }
            if (password.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The password cannot be empty");
            }
            return userData.ValidateUser(name, password);
        }
        public static User ValidateAndGetUser(this UserData userData, string name, string password)
        {
            if (!userData.ValidateCredentials(name, password))
            {
                userData.Logger.LogError($"User {name} failed to log in at {DateTime.Now.ToString()}");
                throw new ArgumentOutOfRangeException("User credentials not found.");
            }
            userData.Logger.LogInformation($"User {name} logged successfully at {DateTime.Now.ToString()}");
            return userData.GetUser(name, password);
        }
    }
}

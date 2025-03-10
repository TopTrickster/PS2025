using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private readonly List<User> _users;
        private int _nextId;
        private ILogger _logger;
        public ILogger Logger
        {
            get => _logger;
        }
        public UserData(ILogger logger)
        {
            _nextId = 0;
            _users = [];
            _logger = logger;
        }
        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }
        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password).FirstOrDefault() != null;
        }
        public bool ValidateUserLinq(string name, string password)
        {
            return (from user in _users
                      where user.Name == name && user.Password == password
                      select user.Id) != null;
        }
        public User? GetUser(string name, string password)
        {
            return (from user in _users
                           where user.Name == name && user.Password == password
                           select user).FirstOrDefault();
        }
        public void SetActive(string name, DateTime expires)
        {
            User? requestedUser = (from user in _users
                                        where user.Name == name
                                        select user).FirstOrDefault() ?? throw new ArgumentException("User not found.");
            requestedUser.Expires = expires;
        }
        public void AsssignUserRole(string name, UserRolesEnum role)
        {
            User? requestedUser = (from user in _users
                                        where user.Name == name
                                        select user).FirstOrDefault() ?? throw new ArgumentException("User not found.");
            requestedUser.Role = role;
        }
    }
}

using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string Name { get; set; }
        // 3. Да се добави прост начин за криптиране/декриптиране на паролата в getter/setter на Password
        private string _password;
        public string Password
        {
            get
            {
                return _password.Substring(_password.Length - 1, 1) + _password.Substring(0, _password.Length - 1);
            }
            set
            {
                _password = value.Substring(1, value.Length - 1) + value.Substring(0, 1);
            }
        }
        public UserRolesEnum Role { get; set; }

        // 1. Да се добавят още данни за потребителите (пример: Факултетен номер, имейл) 
        public string Email { get; set; }
        public string FacultyNumber { get; set; }

        // 2. Да се добавят различни визуализации на данните на потребителя. 
        public string UserData
        {
            get
            {
                return Name + " " + Email + " " + FacultyNumber;
            }
        }
        public string JSONData
        {
            get
            {
                return "{ Name: \"" + Name + "\"" +
                    ", Email: \"" + Email + "\"" +
                    ", FacultyNumber: \"" + FacultyNumber + "\"" +
                    ", Password: \"" + Password + "\"" +
                    ", Role: \"" + Role + "\"" +
                    " }";
            }
        }

        // Exercise 3
        private int id;
        public virtual int Id { get { return id; } set { id = value; } }
        private DateTime expires;
        public DateTime Expires { get { return expires; } set { expires = value; } }


    }
}

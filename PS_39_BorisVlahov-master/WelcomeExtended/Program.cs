using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                // Example 2
                var user = new User
                {

                    Name = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT

                };

                var viewModel = new UserViewModel(user);

                var view = new UserView(viewModel);

                view.Display();

                // Throw error here
                view.DisplayError();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

            // Exercise 3
            try
            {
                UserData userData = new(Delegates.fileLogger);
                User studentUser = new (){ Name = "student", Password = "123", Role = UserRolesEnum.STUDENT };
                User student2User = new (){ Name = "Student2", Password = "123", Role = UserRolesEnum.STUDENT };
                User teacherUser = new (){ Name = "Teacher", Password = "1234", Role = UserRolesEnum.PROFESSOR };
                User adminUser = new (){ Name = "Admin", Password = "12345", Role = UserRolesEnum.ADMIN };
                userData.AddUser(studentUser);
                userData.AddUser(student2User);
                userData.AddUser(teacherUser);
                userData.AddUser(adminUser);

                Console.WriteLine("Please, enter username and password.");
                var input = (Console.ReadLine() ?? throw new NullReferenceException()).Split(" ").ToList();
                User enteredUser = userData.ValidateAndGetUser(input[0], input[1]) ?? throw new NullReferenceException();
                if (enteredUser == null)
                {
                    throw new ArgumentException("User not found.");
                }
                Console.WriteLine(enteredUser.ToString2());
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
        }
    }
}

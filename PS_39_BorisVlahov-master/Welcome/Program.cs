using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main()
        {
            User user = new()
            {
                Name = "Kiro Breika",
                Password = "KiroBreika1234",
                Role = Others.UserRolesEnum.INSPECTOR
            };

            UserViewModel viewModel = new (user);
            UserView view = new (viewModel);

            view.Display();
        }
    }
}

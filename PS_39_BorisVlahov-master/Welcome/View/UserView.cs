using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView(UserViewModel viewModel)
    {
        private readonly UserViewModel _viewModel = viewModel;

        public void Display()
        {
            Console.WriteLine("Welcome\nUser: {0}\nRole: {1}", _viewModel.Name, _viewModel.Role);
        }
        public void DisplayError()
        {
            throw new NotImplementedException();
        }
    }
}

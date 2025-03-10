namespace Welcome.Model
{
    public static class UserHelper
    {
        public static String ToString2(this User user)
        {
            if (user == null)
            {
                return "User is null";
            }
            return $"{user.Name} {user.Password} ({user.Id})";
        }
    }
}

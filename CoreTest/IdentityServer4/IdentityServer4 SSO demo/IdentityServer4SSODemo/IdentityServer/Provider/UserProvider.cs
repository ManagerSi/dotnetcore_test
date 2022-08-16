namespace IdentityServer.Provider
{
    public class UserProvider: IUserProvider
    {
        public List<User> GetList()
        {
            return new List<User>()
            {
                new User() { UserId = 1, Password = "1", Username = "1" },
                new User() { UserId = 2, Password = "1", Username = "1" },
                new User() { UserId = 3, Password = "1", Username = "1" },
                new User() { UserId = 4, Password = "1", Username = "1" },
                new User() { UserId = 5, Password = "1", Username = "1" },
            };
        }
    }
}

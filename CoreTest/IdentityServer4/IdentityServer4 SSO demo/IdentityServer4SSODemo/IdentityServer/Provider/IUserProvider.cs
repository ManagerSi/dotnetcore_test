namespace IdentityServer.Provider
{
    public interface IUserProvider
    {
        List<User> GetList();
    }
}

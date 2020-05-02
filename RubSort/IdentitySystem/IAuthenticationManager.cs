namespace IdentitySystem
{
    public interface IAuthenticationManager<T>
    {
        bool IsRegisteredUser(string userEmail);

        void ChangePassword(string userEmail, string password);

        T Register(string userEmail, string password);

        T Login(string userEmail);
    }
}
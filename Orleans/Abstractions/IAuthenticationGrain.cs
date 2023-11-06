using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IAuthenticationGrain : IGrainWithStringKey
    {
        Task<AuthenticationState?> Get();

        Task Set(AuthenticationState value);

        Task Remove();

        Task<string> GetPasswordHash(Authentication model);

        Task<bool> Authenticate(Authentication model);
    }
}

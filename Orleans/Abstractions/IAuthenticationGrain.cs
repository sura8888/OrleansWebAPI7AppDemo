using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IAuthenticationGrain : IGrainWithStringKey
    {
        Task<Authentication?> Get();

        Task Set(Authentication value);

        Task Remove();

        Task<string> GetPasswordHash(Authentication model);
    }
}

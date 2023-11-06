using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface ISessionGrain : IGrainWithGuidKey
    {
        Task<Session?> Get();

        Task Set(Session value);

        Task Remove();
    }
}

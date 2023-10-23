using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IAccountItemGrain : IGrainWithStringKey
    {
        Task<AccountItem?> Get();

        Task Set(AccountItem value);

        Task Remove();
    }
}

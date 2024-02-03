using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IMemoGrain : IGrainWithIntegerKey
    {
        Task<Memo?> GetMemo();
        Task AddMemo(string content);
        Task DeleteMemo(int memoId);
    }
}
using OrleansWebAPI7AppDemo.Models.Accounting;
using System.Threading.Tasks;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IMemoGrain : IGrainWithIntegerKey
    {
        Task<int> AddMemo(string content);

        Task<MemoState> GetMemoState();

        Task<Memo> GetMemo(int id);

        Task DeleteMemo(int id);
    }
}
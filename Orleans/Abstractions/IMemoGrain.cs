using OrleansWebAPI7AppDemo.Models.Accounting;
using System.Threading.Tasks;
using Orleans;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface IMemoGrain : IGrainWithIntegerKey
    {
        Task<Memo?> Get();

        Task Set(string content);

    }
}

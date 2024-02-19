using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface ITestMemoGrain : IGrainWithStringKey
    {
        Task<TestMemo?> Get();

        Task Set(TestMemo value);

        Task Remove();
    }
}

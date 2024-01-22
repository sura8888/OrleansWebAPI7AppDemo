using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansCodeGen.Orleans.Serialization.Codecs;
namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    [GenerateSerializer]
    public class MemoState
    {
        [Id(0)]
        public List<Memo> Memos { get; set; } = new List<Memo>();
        [Id(1)]
        public int NextId { get; set; } = 1;
    }
}
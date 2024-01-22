// Memo.cs
using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    [GenerateSerializer]
    public class Memo
    {
        [Id(0)]
        public int Id { get; set; }
        [Id(1)]
        public string Content { get; set; }
        [Id(2)]
        public DateTime Day { get; set; }
    }
}

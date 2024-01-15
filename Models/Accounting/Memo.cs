using OrleansCodeGen.Orleans.Serialization.Codecs;
using System;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{

    /// <summary>
    /// ‰ïĞî•ñ
    /// </summary>
    [GenerateSerializer]
    public class Memo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

using OrleansCodeGen.Orleans.Serialization.Codecs;

namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    /// <summary>
    /// セッションモデル
    /// </summary>
    [GenerateSerializer]
    public class Session
    {
        [Id(0)]
        // 
        public bool Enabled { get; set; } = false;
        [Id(1)]
        // 
        public DateTime Expired { get; set; } = DateTime.MinValue;
        [Id(2)]
        // 
        public string UserId { get; set; } = String.Empty;
    }

}
